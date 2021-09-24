using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Dishes.Commands;
using SmartRestaurant.Application.Dishes.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/dishes")]
    [ApiController]
    public class DishesController : ApiController
    {
        [Route("foodbusiness/{id:Guid}")]
        [HttpGet]
        public Task<IActionResult> GetByFoodBusinessId([FromRoute] Guid id, int page, int pageSize)
        {
            return SendWithErrorsHandlingAsync(new GetDishesByFoodBusinessIdQuery
                {FoodBusinessId = id, Page = page, PageSize = pageSize});
        }

        [Route("menu/{id:Guid}")]
        [HttpGet]
        public Task<IActionResult> GetByMenuId([FromRoute] Guid id, int page, int pageSize)
        {
            return SendWithErrorsHandlingAsync(new GetDishesByMenuIdQuery
                {MenuId = id, Page = page, PageSize = pageSize});
        }

        [Route("section/{id:Guid}")]
        [HttpGet]
        public Task<IActionResult> GetBySectionId([FromRoute] Guid id, int page, int pageSize)
        {
            return SendWithErrorsHandlingAsync(new GetDishesBySectionIdQuery
                {SectionId = id, Page = page, PageSize = pageSize});
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public Task<IActionResult> Get([FromRoute] Guid id)
        {
            return SendWithErrorsHandlingAsync(new GetDishByIdQuery {DishId = id});
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateDishCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateDishCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id:Guid}")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            return await SendWithErrorsHandlingAsync(new DeleteDishCommand {Id = id});
        }
    }
}