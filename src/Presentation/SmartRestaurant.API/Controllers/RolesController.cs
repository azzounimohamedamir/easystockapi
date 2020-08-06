using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Helpers;
using SmartRestaurant.API.Models;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Infrastructure.Identity.Enums;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [Authorize(Roles = "SupportAgent,SuperAdmin,FoodBusinessAdministrator")]
        [HttpPost("UpdateUserRoles")]
        public async Task<IActionResult> UpdateUserRoles(UpdateUserRolesModel model)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(model.UserId);
            foreach (var role in Enum.GetNames(typeof(Roles)))
            {
                if (model.Roles.Exists(x => x == role))
                {
                    await _userManager.AddToRoleAsync(user, role);
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user, role);
                }
            }
            return Ok(HttpResponseHelper.Respond(ResponseType.OK));
        }

        [HttpGet("GetRoles")]
        public IActionResult GetRoles()
        {
            var roles = _roleManager.Roles.Select(x => x.Name).ToList();
            return Ok(roles);
        }
    }
}
