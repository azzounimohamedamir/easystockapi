using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Interfaces;
using System.Security.Claims;

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
