using LunchVote.LIB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunchVote.Tests.Mocks
{
    public static class VoteMock
    {
        public static List<Professional> ProfessionalList
        {
            get
            {
                return new List<Professional>()
                {
                    new Professional
                    {
                        Id = Guid.NewGuid(),
                        Name = "Dev Senior"
                    },
                    new Professional
                    {
                        Id = Guid.NewGuid(),
                        Name = "Dev Pleno"
                    },
                    new Professional
                    {
                        Id = Guid.NewGuid(),
                        Name = "Estagiário"
                    },
                    new Professional
                    {
                        Id = Guid.NewGuid(),
                        Name = "Tester"
                    },
                    new Professional
                    {
                        Id = Guid.NewGuid(),
                        Name = "G.P."
                    }
                };
            }
        }

        public static List<Restaurant> RestaurantList
        {
            get
            {
                return new List<Restaurant>()
                {
                    new Restaurant
                    {
                        Id = Guid.NewGuid(),
                        Name = "Prédio 40"
                    },
                    new Restaurant
                    {
                        Id = Guid.NewGuid(),
                        Name = "Subway"
                    },
                    new Restaurant
                    {
                        Id = Guid.NewGuid(),
                        Name = "R.U."
                    },
                    new Restaurant
                    {
                        Id = Guid.NewGuid(),
                        Name = "Prédio 11"
                    },
                    new Restaurant
                    {
                        Id = Guid.NewGuid(),
                        Name = "Prédio 50"
                    }
                };
            }
        }

        public static List<Vote> VoteList
        {
            get
            {
                return new List<Vote>()
                {
                    new Vote
                    {
                        Id = Guid.NewGuid(),
                        ProfessionalId = ProfessionalList.First().Id,
                        RestaurantId = RestaurantList.First().Id,
                        VoteDate = DateTime.Now
                    },
                    new Vote
                    {
                        Id = Guid.NewGuid(),
                        ProfessionalId = ProfessionalList.Last().Id,
                        RestaurantId = RestaurantList.First().Id,
                        VoteDate = DateTime.Now
                    }
                };
            }
        }

        public static Election Election
        {
            get
            {
                return new Election()
                {
                    Id = Guid.NewGuid(),
                    ElectionDate = DateTime.Now,
                    Status = EnumElectionStatus.closed,
                    Votes = VoteList,
                    WinnerRestaurantId = VoteList.GroupBy(v => v.RestaurantId).Select(r => new { Value = r.Key, Count = r.Count() })
                        .OrderByDescending(o => o.Count).FirstOrDefault().Value
                };
            }
        }
    }
}
