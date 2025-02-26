using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Interfaces;
using System.Security.Claims;

namespace SmartRestaurant.Infrastructure.Identity.Services
{
    public class UserService : IUserService
    {
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            User = httpContextAccessor.HttpContext.User;
            Headers = httpContextAccessor.HttpContext.Request.Headers;
        }

        private ClaimsPrincipal User { get; }
        private IHeaderDictionary Headers { get; }
        private string oldrole { get; set; }
        public string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public string GetUserLanguage()
        {
            return Headers["Accept-Language"];
        }
        public string GetRoles()
        {
            if (oldrole == null)
            {
                return User.FindFirst(ClaimTypes.Role).Value;
            }
            else
                return oldrole;
        }

        public void SetNewRole(string role)
        {
            oldrole = role;
        }
    }
}