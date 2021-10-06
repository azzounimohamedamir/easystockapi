using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Authorize]
    [Route("api/foodbusinessClient")]
    [ApiController]
    public class FoodBusinessClientController : ApiController
    {
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> Create(CreateFoodBusinessClientCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{id}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager,FoodBusinessAdministrator,SupportAgent,SuperAdmin")]
        public async Task<IActionResult> Update([FromRoute] string id, UpdateFoodBusinessClientCommand command)
        {
            command.Id = id;
            return await SendWithErrorsHandlingAsync(command);
        }
    }
}
