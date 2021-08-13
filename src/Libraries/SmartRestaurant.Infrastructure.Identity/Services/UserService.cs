using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Infrastructure.Identity.Services
{
    public class UserService : IUserService
    {
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            User = httpContextAccessor.HttpContext.User;
        }

        private ClaimsPrincipal User { get; }
    
        public string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public string GetRoles()
        {
            return User.FindFirst(ClaimTypes.Role).Value;
        }
    }
}