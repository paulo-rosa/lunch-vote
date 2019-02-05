using LunchVote.LIB.Entities;
using LunchVote.LIB.Repositories;
using LunchVote.LIB.Services;
using LunchVote.Tests.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace LunchVote.Tests
{
    public class RestaurantsServiceUnitTest
    {
        [Fact]
        public async void Get_RestaurantList_ReturnsListOfrestaurants()
        {
            var restaurant = VoteMock.RestaurantList;

            var mock = new Mock<IRestaurantRepository>();
            IRestaurantService restaurantService = new RestaurantService(mock.Object);

            mock.Setup(p => p.GetRestaurantsAsync()).ReturnsAsync(restaurant);
            
            var result = await restaurantService.GetRestaurantsAsync();
            
            Assert.NotNull(result);

            Assert.Equal("Prédio 40", restaurant.FirstOrDefault().Name);
        }
    }
}
