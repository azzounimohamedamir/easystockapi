using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Infrastructure.Identity.Enums;

namespace SmartRestaurant.API.Controllers
{
    [Route("api/seed")]
    [ApiController]
    public class SeedController : ApiController
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        
        [HttpGet]
        public async Task<IActionResult> Seed()
        {
            try
            {
                var superAdmin = await _userManager.FindByEmailAsync("SuperAdmin@SmartRestaurant.io");
                await _userManager.AddToRoleAsync(superAdmin, Roles.SuperAdmin.ToString());
                
                var supportAgent = await _userManager.FindByEmailAsync("SupportAgent@SmartRestaurant.io");
                await _userManager.AddToRoleAsync(supportAgent, Roles.SupportAgent.ToString());
                
                var waiter = await _userManager.FindByEmailAsync("Waiter@SmartRestaurant.io");
                await _userManager.AddToRoleAsync(waiter, Roles.Waiter.ToString());
                
                var foodAdmin = await _userManager.FindByEmailAsync("FoodAdmin@SmartRestaurant.io");
                await _userManager.AddToRoleAsync(foodAdmin, Roles.FoodBusinessAdministrator.ToString());
                
                return Ok("Done");
            }
            catch
            {
                return Ok("Done with issues");
            }
        }
    }
}