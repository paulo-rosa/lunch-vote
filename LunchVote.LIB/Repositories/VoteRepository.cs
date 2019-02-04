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

        public async Task<Vote> GetTodaysUserVote(Guid professionalId)
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
            var restList = await _context.Elections.Where(r => r.ElectionDate.Day > DateTime.Now.Day)
                .ToListAsync();

            return restList.Where(r => r.Id == restaurantId).Count() > 0;
        }
    }
}
