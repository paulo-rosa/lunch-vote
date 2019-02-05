using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LunchVote.LIB.Entities;
using Microsoft.EntityFrameworkCore;

namespace LunchVote.LIB.Repositories
{
    public class VoteRepository : IVoteRepository
    {
        LunchVoteContext _context;

        public VoteRepository(LunchVoteContext context)
        {
            _context = context;
        }

        public async Task<List<Vote>> GetVotesAsync(Guid professionalId)
        {
            return await _context.Votes.Where(v => v.ProfessionalId == professionalId).ToListAsync();
        }

        public async Task<Vote> GetTodaysUserVoteAsync(Guid professionalId)
        {
            return await _context.Votes.Where(v => v.ProfessionalId == professionalId &&
                                                    v.VoteDate.Day >= DateTime.Now.Day).FirstOrDefaultAsync();
        }

        public async Task<Vote> PostVoteAsync(Vote vote)
        {
            await _context.AddAsync(vote);

            await _context.SaveChangesAsync();

            vote = await _context.Votes
                .Include(p => p.Professional)
                .Include(r => r.Restaurant)
                .Where(v => v.Id == vote.Id)
                .FirstOrDefaultAsync();

            return vote;
        }

        public async Task<bool> RestaurantAlreadySelected(Guid restaurantId)
        {
            var restList = await _context.Elections.Where(r => r.ElectionDate.Date > DateTime.Now.Date)
                .ToListAsync();

            return restList.Where(r => r.Id == restaurantId).Count() > 0;
        }

        public async Task<Election> GetTodaysElectionAsync()
        {
            var todaysElection = await _context.Elections
                .Include(e => e.Votes)
                    .ThenInclude(v => v.Professional)
                .Include(e => e.Votes)
                    .ThenInclude(v => v.Restaurant)
                .Where(e => e.ElectionDate.Date == DateTime.Now.Date).FirstOrDefaultAsync();

            if (todaysElection == null)
            {
                todaysElection = new Election()
                {
                    ElectionDate = DateTime.Now,
                    Status = EnumElectionStatus.open
                };

                _context.Elections.Add(todaysElection);

                _context.SaveChanges();
            }

            return todaysElection;
        }

        public async Task<List<Election>> GetWeekElectionsAsync()
        {
            DateTime startDayOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek));
            DateTime endDayOfWeek = DateTime.Today.AddDays(6 - (int)DateTime.Today.DayOfWeek);

            var result = await _context.Elections.Include(i => i.Votes)
                                                     .ThenInclude(v => v.Restaurant)
                                                 .Include(i => i.Votes)
                                                     .ThenInclude(v => v.Professional)
                                                 .Where(e => e.ElectionDate > startDayOfWeek && e.ElectionDate < endDayOfWeek)
                                                 .ToListAsync();
            return result;
        }

        public void FinishElection(Guid electionId, Guid winnerRestaurantId)
        {
            var election = _context.Elections.Where(e => e.Id == electionId).FirstOrDefault();
            election.WinnerRestaurantId = winnerRestaurantId;
            election.Status = EnumElectionStatus.closed;
            _context.SaveChanges();
        }
    }
}
