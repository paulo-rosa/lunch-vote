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
        Task<List<Vote>> GetVotesAsync(Guid professionalId);
        Task<Vote> GetTodaysUserVoteAsync(Guid professionalId);
        Task<bool> RestaurantAlreadySelected(Guid restaurantId);
        Task<Election> GetTodaysElectionAsync();
        Task<List<Election>> GetWeekElectionsAsync();
        void FinishElection(Guid electionId, Guid winnerRestaurantId);
    }
}
