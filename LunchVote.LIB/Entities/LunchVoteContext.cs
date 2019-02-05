using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace LunchVote.LIB.Entities
{
    public class LunchVoteContext: DbContext
    {
        public LunchVoteContext(DbContextOptions<LunchVoteContext> options) : base(options)
        {
            Database.Migrate();
        }

        public override Task AddRangeAsync(params object[] entities)
        {
            try
            {
                return base.AddRangeAsync(entities);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public DbSet<Professional> Professionals { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<Election> Elections { get; set; }
    }
}
