using System.Security.Claims;
using SmartRestaurant.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace SmartRestaurant.Web.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
        }
        public string UserId { get; }
    }
}
