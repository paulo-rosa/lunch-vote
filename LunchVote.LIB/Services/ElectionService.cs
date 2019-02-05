using LunchVote.LIB.Entities;
using LunchVote.LIB.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LunchVote.LIB.Services
{
    public class ElectionService : IHostedService, IDisposable
    {
        private readonly ILogger _logger;
        private Timer _timer;
        private readonly IServiceScopeFactory _scopeFactory;

        public ElectionService(ILogger<ElectionService> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is starting.");
            
            double current = DateTime.Now.TimeOfDay.TotalMilliseconds;
            double scheduledTime = new TimeSpan(12, 0, 0).TotalMilliseconds;
            double intervalPeriod = new TimeSpan(24, 0, 0).TotalMilliseconds;
            double firstExecution = current > scheduledTime ? intervalPeriod - (current - scheduledTime) : scheduledTime - current;

            _timer = new Timer(DoWork, null, Convert.ToInt32(firstExecution), Convert.ToInt32(intervalPeriod));

            return Task.CompletedTask;
        }

        private async void DoWork(object state)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<LunchVoteContext>();

                var voteRepository = new VoteRepository(dbContext);

                var todaysElection = await voteRepository.GetTodaysElectionAsync();

                if (todaysElection != null && todaysElection.WinnerRestaurantId == Guid.Empty)
                {
                    var winnerRestaurant = todaysElection.Votes
                        .GroupBy(v => v.RestaurantId).Select(r => new { Value = r.Key, Count = r.Count() })
                        .OrderByDescending(o => o.Count);

                    if (winnerRestaurant.FirstOrDefault() != null)
                    {
                        voteRepository.FinishElection(todaysElection.Id, winnerRestaurant.FirstOrDefault().Value);
                    }
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
