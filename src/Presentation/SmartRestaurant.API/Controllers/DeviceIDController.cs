using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.DeviceID.Commands;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/DeviceID")]
    [ApiController]
    public class DeviceIDController : ApiController
    {
        [HttpPost]
        [Authorize(Roles = "FoodBusinessManager,Diner")]
        public async Task<IActionResult> Create(CreateDeviceIDCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
    }
}
