using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Exceptions;

namespace SmartRestaurant.API.Helpers
{
    public static class TokenUtils
    {
        public const string Claim_Nameidentifier = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier";
        public const string Claim_Name = "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name";
        public const string Claim_Role = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";
        public const string Claim_Exp = "exp";
        public const string Claim_Iss = "iss";
        public const string Claim_Aud = "aud";

        public static string FindClaim(HttpContext httpContext, string claimName)
        {
            var identity = httpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                string claimValue = identity.FindFirst(claimName).Value;
                if (claimValue != string.Empty)
                {
                    return claimValue;
                }
                throw new NotFoundException($"The token claim \"{claimName}\" was not found.");
            }
            throw new NotFoundException($"The list of token claims was not found.");
        }

    }
}