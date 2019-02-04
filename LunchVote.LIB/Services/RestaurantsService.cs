using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LunchVote.LIB.Entities;
using LunchVote.LIB.Repositories;

namespace LunchVote.LIB.Services
{
    public class RestaurantService : IRestaurantService
    {
        IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<List<Restaurant>> GetRestaurantsAsync()
        {
            return await _restaurantRepository.GetRestaurantsAsync();
        }
    }
}
