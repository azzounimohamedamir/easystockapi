using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.DishIngredients.Commands;
using SmartRestaurant.Application.DishIngredients.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/dishingredients")]
    [ApiController]
    public class DishDishIngredientsController : ApiController
    {
        [Route("dish/{id:guid}")]
        [HttpGet]
        public Task<IActionResult> Get([FromRoute] Guid id, int page, int pageSize)
        {
            return SendWithErrorsHandlingAsync(new GetDishIngredientsByDishIdQuery {DishId = id});
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDishIngredientCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id:Guid}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteDishIngredientCommand {Id = id});
        }
    }
}