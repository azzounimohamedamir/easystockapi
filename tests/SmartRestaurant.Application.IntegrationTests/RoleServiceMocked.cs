using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SmartRestaurant.Application.IntegrationTests
{
    public class RoleServiceMocked : IUserService
    {
        public RoleServiceMocked(IHttpContextAccessor httpContextAccessor)
        {
            User = httpContextAccessor.HttpContext.User;
            Headers = httpContextAccessor.HttpContext.Request.Headers;
        }

        private ClaimsPrincipal User { get; }
        private IHeaderDictionary Headers { get; }

        public string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }

        public string GetUserLanguage()
        {
            return Headers["Accept-Language"];
        }
        public string oldrole { get; set; }
      

        public string GetRoles()
        {
            return oldrole;
        }

        public void SetNewRole(string role)
        {
            oldrole = role;
        }

    }
}
