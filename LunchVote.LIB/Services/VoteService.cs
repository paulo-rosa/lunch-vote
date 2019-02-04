using LunchVote.LIB.Entities;
using LunchVote.LIB.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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

        public async Task<List<Vote>> GetVotesAsync(Guid professionalId)
        {
            return await _voteRepository.GetVotesAsync(professionalId);
        }

        public async Task<Vote> PostVoteAsync(Vote vote)
        {
            // Usuário não pode votar mais de uma vez no dia
            var todayUserVote = await _voteRepository.GetTodaysUserVote(vote.ProfessionalId);            
            if (todayUserVote != null)
            {
                throw new ValidationException("Você já votou no dia de hoje. Por favor, volte amanhã.");
            }
            return await _voteRepository.PostVoteAsync(vote);
        }
    }
}
