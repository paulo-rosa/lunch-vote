using LunchVote.LIB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunchVote.LIB.Repositories
{
    public class ProfessionalRepository: IProfessionalRepository
    {
        LunchVoteContext _context;

        public ProfessionalRepository(LunchVoteContext context)
        {
            _context = context;
        }

        public async Task<List<Professional>> GetProfessionalsAsync()
        {
            return await _context.Professionals.ToListAsync();
        }
    }
}
