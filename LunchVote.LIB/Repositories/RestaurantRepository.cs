using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LunchVote.LIB.Entities;
using Microsoft.EntityFrameworkCore;

namespace LunchVote.LIB.Repositories
{
    public class RestaurantRepository : IRestaurantRepository
    {
        LunchVoteContext _context;

        public RestaurantRepository(LunchVoteContext context)
        {
            _context = context;
        }

        public async Task<List<Restaurant>> GetRestaurantsAsync()
        {
            return await _context.Restaurants.ToListAsync();
        }
    }
}
