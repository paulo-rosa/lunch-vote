using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchVote.API.Models
{
    public class VoteForInsertDto
    {
        public Guid ProfessionalId { get; set; }
        public Guid RestaurantId { get; set; }
    }
}
