using LunchVote.LIB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchVote.API.Models
{
    public class ElectionForRetrieveDto
    {
        public DateTime ElectionDate { get; set; }

        public List<VoteForRetrieveDto> Votes { get; set; }

        public EnumElectionStatus Status { get; set; }

        public Guid WinnerRestaurantId { get; set; }

        public string WinnerRestaurantName {
            get
            {
                var vote = Votes.Where(v => v.RestaurantId == WinnerRestaurantId).FirstOrDefault();
                if (vote != null)
                {
                    return vote.RestaurantName;
                }

                return string.Empty;
            }
        }

        public bool Closed {
            get
            {
                return Status == EnumElectionStatus.closed;
            }
        }
    }
}
