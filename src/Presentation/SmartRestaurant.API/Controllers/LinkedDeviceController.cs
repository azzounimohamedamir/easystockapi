using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.DeviceID.Commands;
using SmartRestaurant.Application.DeviceID.Queries;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/DeviceID")]
    [ApiController]
    public class LinkedDeviceController : ApiController
    {
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager,Diner")]
        public async Task<IActionResult> Create(CreateDeviceIDCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        
        [HttpGet]
        [Authorize(Roles = "FoodBusinessManager,Diner")]
        public Task<IActionResult> Get(string DeviceID)
        {
            return SendWithErrorsHandlingAsync(new GetDeviceIDByIdQuery { IdentifierDevice = DeviceID });
        }
    }
}
