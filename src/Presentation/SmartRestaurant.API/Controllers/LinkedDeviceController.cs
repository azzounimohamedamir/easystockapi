using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.LinkedDevice.Commands;
using SmartRestaurant.Application.LinkedDevice.Queries;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/LinkedDevice")]
    [ApiController]
    public class LinkedDeviceController : ApiController
    {
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager,Diner")]
        public async Task<IActionResult> Create(CreateLinkedDeviceCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [Route("{IdentifierDevice}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,Diner")]
        public Task<IActionResult> Get([FromRoute]string IdentifierDevice)
        {
            return SendWithErrorsHandlingAsync(new GetLinkedDeviceByIdQuery { IdentifierDevice = IdentifierDevice });
        }
    }
}
