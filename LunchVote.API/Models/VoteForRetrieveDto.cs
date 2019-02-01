using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchVote.API.Models
{
    public class VoteForRetrieveDto
    {
        public string ProfessionalName { get; set; }
        public string RestaurantName { get; set; }
    }
}
