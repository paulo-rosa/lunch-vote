using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LunchVote.LIB.Entities
{
    public class Vote
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public Guid ProfessionalId { get; set; }

        [ForeignKey("ProfessionalId")]
        public Professional Professional { get; set; }

        public Guid RestaurantId { get; set; }

        [ForeignKey("RestaurantId")]
        public Restaurant Restaurant { get; set; }

        public Guid ElectionId { get; set; }

        [ForeignKey("ElectionId")]
        public Election Election { get; set; }

        public DateTime VoteDate { get; set; }
    }
}
