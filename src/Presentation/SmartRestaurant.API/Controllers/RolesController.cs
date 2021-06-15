using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.API.Helpers;
using SmartRestaurant.API.Models.UserModels;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Infrastructure.Identity.Enums;

namespace SmartRestaurant.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public RolesController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _roleManager.Roles.Select(x => x.Name).ToList();
            return Ok(roles);
        }

        [Authorize(Roles = "SupportAgent,SuperAdmin,FoodBusinessAdministrator")]
        [HttpPut]
        public async Task<IActionResult> UpdateUserRoles(UpdateUserRolesModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            foreach (var role in Enum.GetNames(typeof(Roles)))
                if (model.Roles.Exists(x => x == role))
                    await _userManager.AddToRoleAsync(user, role);
                else
                    await _userManager.RemoveFromRoleAsync(user, role);
            return Ok(HttpResponseHelper.Respond(ResponseType.OK));
        }
    }
}