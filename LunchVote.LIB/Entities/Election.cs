using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text;

namespace LunchVote.LIB.Entities
{
    public class Election
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        public DateTime ElectionDate { get; set; }

        public List<Vote> Votes { get; set; }

        public EnumElectionStatus Status { get; set; }

        public Guid WinnerRestaurantId { get; set; }
    }

    public enum EnumElectionStatus
    {
        open,
        closed
    }
}
