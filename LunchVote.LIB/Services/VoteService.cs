using LunchVote.LIB.Entities;
using LunchVote.LIB.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LunchVote.LIB.Services
{
    public class VoteService: IVoteService
    {
        IVoteRepository _voteRepository;

        public VoteService(IVoteRepository voteRepository)
        {
            _voteRepository = voteRepository;
        }

        public async Task<Vote> PostVoteAsync(Vote vote)
        {
            return await _voteRepository.PostVoteAsync(vote);
        }
    }
}
