using LunchVote.LIB.Entities;
using LunchVote.LIB.Repositories;
using LunchVote.LIB.Services;
using LunchVote.Tests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LunchVote.Tests
{
    public class VoteServiceUnitTest
    {
        [Fact]
        public async void Add_VoteForRestaurant_ReturnsVoteConfirmation()
        {
            var vote = VoteMock.VoteList.First();

            var mock = new Mock<IVoteRepository>();
            IVoteService voteService = new VoteService(mock.Object);

            mock.Setup(p => p.PostVoteAsync(vote)).ReturnsAsync(vote);

            mock.Setup(p => p.GetTodaysElectionAsync()).ReturnsAsync(VoteMock.Election);

            var result = await voteService.PostVoteAsync(vote);
            
            //User can vote
            Assert.NotNull(result);

            //Vote is computed for the correct restaurant
            Assert.Equal(result.RestaurantId, vote.RestaurantId);
        }

        [Fact]
        public async void Add_VoteForRestaurant_ReturnsVoteNotAllowed()
        {
            var vote = VoteMock.VoteList.First();
            var mock = new Mock<IVoteRepository>();
            IVoteService voteService = new VoteService(mock.Object);
            
            mock.Setup(p => p.PostVoteAsync(vote)).ReturnsAsync(() => throw new ValidationException("Você já votou no dia de hoje. Por favor, volte amanhã."));            
            
            await Assert.ThrowsAsync<ValidationException>(() => voteService.PostVoteAsync(vote));
        }

        [Fact]
        public async void Get_TodaysElection_ReturnsElection()
        {
            var vote = VoteMock.VoteList.First();
            var mock = new Mock<IVoteRepository>();
            IVoteService voteService = new VoteService(mock.Object);

            mock.Setup(p => p.GetTodaysElectionAsync()).ReturnsAsync(VoteMock.Election);

            var response = await voteService.GetTodaysElectionAsync();

            Assert.NotNull(response);

            //
            Assert.Equal(DateTime.Now.Date, response.ElectionDate.Date);
        }

        [Fact]
        public async void Get_TodaysElection_ElectionIstoday()
        {
            var vote = VoteMock.VoteList.First();
            var mock = new Mock<IVoteRepository>();
            IVoteService voteService = new VoteService(mock.Object);

            mock.Setup(p => p.GetTodaysElectionAsync()).ReturnsAsync(VoteMock.Election);

            var response = await voteService.GetTodaysElectionAsync();

            Assert.NotNull(response);

            //
            Assert.Equal(DateTime.Now.Date, response.ElectionDate.Date);
        }
    }
}
