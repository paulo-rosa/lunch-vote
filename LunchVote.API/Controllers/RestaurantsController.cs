using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using LunchVote.API.Models;
using LunchVote.LIB.Entities;
using LunchVote.LIB.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LunchVote.API.Controllers
{
    [Route("restaurants")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IMapper mapper, IRestaurantService restaurantService)
        {
            _mapper = mapper;
            _restaurantService = restaurantService;
        }

        /// <summary>
        /// Get restaurants
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerOperation(Tags = new[] { "Restaurants" })]
        [SwaggerResponse(200, Type = typeof(IEnumerable<string>))]
        public async Task<ActionResult<List<RestaurantForRetrieveDto>>> Get()
        {
            var response = await _restaurantService.GetRestaurantsAsync();

            return Mapper.Map<List<RestaurantForRetrieveDto>>(response);
        }
    }
}
