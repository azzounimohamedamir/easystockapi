using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Ingredients.Commands;
using SmartRestaurant.Application.Ingredients.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/ingredients")]
    [ApiController]
    public class IngredientsController : ApiController
    {
        [Route("foodbusiness/{id:Guid}")]
        [HttpGet]
        public Task<IActionResult> Get([FromRoute] Guid id, int page, int pageSize)
        {
            return SendWithErrorsHandlingAsync(new GetIngredientsByFoodBusinessIdQuery
                {FoodBusinessId = id, Page = page, PageSize = pageSize});
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            return SendWithErrorsHandlingAsync(new GetIngredientByIdQuery {IngredientId = id});
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateIngredientCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateIngredientCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id:Guid}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteIngredientCommand {Id = id});
        }
    }
}