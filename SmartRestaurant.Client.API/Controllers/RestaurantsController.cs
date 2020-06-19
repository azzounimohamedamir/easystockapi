using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Restaurants.Restaurants.Commands.Update;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Restaurants.Queries.GetById;
using SmartRestaurant.Application.Services.Models;
using SmartRestaurant.Application.Services.Queries;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Client.API.Controllers
{

    public class RestaurantsController : SRBaseController
    {
        private readonly IGetRestaurantByIdQuery getRestaurantById;
        private readonly IGetAllRestaurantsQuery getAllRestaurants;
        private readonly IGetServiceByRestaurantIdQuery getServiceByRestaurantId;

        public RestaurantsController(IGetRestaurantByIdQuery getRestaurantById
            , IGetAllRestaurantsQuery getAllRestaurants,
            IGetServiceByRestaurantIdQuery getServiceByRestaurantId)
        {
            this.getRestaurantById = getRestaurantById;
            this.getAllRestaurants = getAllRestaurants;
            this.getServiceByRestaurantId = getServiceByRestaurantId;
        }

        [HttpGet]
        public ActionResult<List<RestaurantItemModel>> GetAll()
        {
            try
            {
                var result = getAllRestaurants.Execute();
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("{id}")]
        public ActionResult<UpdateRestaurantModel> Get(string id)
        {
            try
            {
                var result = getRestaurantById.Execute(id);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{restaurantId}/services")]
        public ActionResult<ServiceModel> GetService(string restaurantId)
        {
            try
            {
                var result = getServiceByRestaurantId.Execute(restaurantId);
                if (result == null) return NotFound();
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}