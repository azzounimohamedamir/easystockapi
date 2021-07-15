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
        public async Task<ActionResult> AddEmployeeInOrganization(AddEmployeeInOrganizationCommand command)
        {
            var validationResult = await SendAsync(command);
            return ApiCustomResponse(validationResult);
        }

        [HttpPut]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<ActionResult> UpdateEmployeeRoleInOrganization(
            UpdateEmployeeRoleInOrganizationCommand command)
        {
            var validationResult = await SendAsync(command);
            return ApiCustomResponse(validationResult);
        }

        [HttpDelete]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<ActionResult> RemoveStaffFromOrganization(RemoveStaffFromOrganizationCommand command)
        {
            var validationResult = await SendAsync(command);
            return ApiCustomResponse(validationResult);
        }
    }
}