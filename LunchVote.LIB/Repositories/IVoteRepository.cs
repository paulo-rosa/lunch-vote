using LunchVote.LIB.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunchVote.LIB.Repositories
{
    public interface IVoteRepository
    {
        Task<Vote> PostVoteAsync(Vote vote);
    }
}
