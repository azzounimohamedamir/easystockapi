using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.LinkedDevice.Commands;
using SmartRestaurant.Application.LinkedDevice.Queries;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/LinkedDevice")]
    [ApiController]
    public class LinkedDeviceController : ApiController
    {
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Create(CreateLinkedDeviceCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{IdentifierDevice}")]
        [HttpGet]
        [AllowAnonymous]
        public Task<IActionResult> Get([FromRoute] string IdentifierDevice)
        {
            return SendWithErrorsHandlingAsync(new GetLinkedDeviceByIdQuery {IdentifierDevice = IdentifierDevice});
        }

        [Route("{IdentifierDevice}")]
        [HttpPut]
        [Authorize(Roles = "FoodBusinessManager")]
        public async Task<IActionResult> Update(UpdateLinkedDeviceCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
    }
}