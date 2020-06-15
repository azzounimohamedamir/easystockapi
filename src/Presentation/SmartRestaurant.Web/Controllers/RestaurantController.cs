using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Restaurants.Commands.CreateRestaurant;
using SmartRestaurant.Application.Restaurants.Commands.DeleteRestaurant;
using SmartRestaurant.Application.Restaurants.Commands.UpdateRestaurant;
using SmartRestaurant.Application.Restaurants.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Web.Controllers
{
    public class TodoItemsController : ApiController
    {
        [HttpGet]
        public async Task<List<RestaurantDto>> Get()
        {
            return await Mediator.Send(new GetRestaurantsListQuery());
        }

        [HttpGet("{id}")]
        public async Task<RestaurantDto> GetNyId(Guid Id)
        {
            return await Mediator.Send(new GetRestaurantByIdQuery { RestaurantId = Id});
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(CreateRestaurantCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(Guid id, UpdateRestaurantCommand command)
        {
            if (id != command.RestaurantId)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteRestaurantCommand { Id = id });

            return NoContent();
        }
    }
}
