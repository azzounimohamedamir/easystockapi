using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Common.Services
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
