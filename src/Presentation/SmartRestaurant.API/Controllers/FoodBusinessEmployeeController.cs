using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.FoodBusinessEmployee.Commands;

namespace SmartRestaurant.API.Controllers
{
    [Authorize]
    [Route("api/foodbusinessstaff")]
    [ApiController]
    public class FoodBusinessEmployeeController : ApiController
    {
        [HttpPost]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<IActionResult> AddEmployeeInOrganization(AddEmployeeInOrganizationCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<IActionResult> UpdateEmployeeRoleInOrganization(
            UpdateEmployeeRoleInOrganizationCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }

        [HttpDelete]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<IActionResult> RemoveEmployeeFromOrganization(RemoveEmployeeFromOrganizationCommand command)
        {
            return await SendWithErrorsHandlingAsync(command);
        }
    }
}