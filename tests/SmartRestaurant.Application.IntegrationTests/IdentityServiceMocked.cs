using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SmartRestaurant.Application.IntegrationTests
{
    public class IdentityServiceMocked : IUserService
    {
        public IdentityServiceMocked(IHttpContextAccessor httpContextAccessor)
        {
            User = httpContextAccessor.HttpContext.User;
            Headers = httpContextAccessor.HttpContext.Request.Headers;
        }
        public string oldrole { get; set; } = null;

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
      

        public string GetRoles()
        {
            if (oldrole!=null)
            return oldrole;
            else           
            return User.FindFirst(ClaimTypes.Role).Value;

        }

        public void SetNewRole(string role)
        {
            oldrole = role;
        }

    }
}
