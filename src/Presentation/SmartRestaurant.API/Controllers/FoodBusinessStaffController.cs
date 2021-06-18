using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.FoodBusiness.Commands;

namespace SmartRestaurant.API.Controllers
{
    [Authorize]
    [Route("api/foodbusinessstaff")]
    [ApiController]
    public class FoodBusinessStaffController : ApiController
    {
        [Route("{userId:Guid}/foodbusinessstaff/{foodBusinessId:Guid}/role/{role}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<ActionResult> AddOrUpdateEmployeeRoleInOrganization([FromRoute] Guid foodBusinessId,
            [FromRoute] Guid userId, [FromRoute] string role)
        {
            var validationResult = await SendAsync(new AddOrUpdateEmployeeRoleInOrganizationCommand
                {UserId = userId, Role = role, FoodBusinessId = foodBusinessId});
            return ApiCustomResponse(validationResult);
        }

        [Route("{userId:Guid}/foodbusinessstaff/{foodBusinessId:Guid}")]
        [HttpGet]
        [Authorize(Roles = "FoodBusinessAdministrator")]
        public async Task<ActionResult> RemoveStaffFromInOrganization([FromRoute] Guid foodBusinessId,
            [FromRoute] Guid userId, [FromRoute] int roleId)
        {
            var validationResult = await SendAsync(new RemoveStaffFromInOrganizationCommand
                {UserId = userId, FoodBusinessId = foodBusinessId});
            return ApiCustomResponse(validationResult);
        }
    }
}