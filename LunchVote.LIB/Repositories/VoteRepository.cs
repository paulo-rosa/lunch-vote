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
    }
}
