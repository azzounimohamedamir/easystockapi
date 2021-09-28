using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SmartRestaurant.Application.Common.Configuration.SocialMedia;
using SmartRestaurant.Domain.Identity.Entities;

namespace SmartRestaurant.Application.Common.Tools
{
    public static class TokenGenerator
    {
        public static async Task<string> Generate(ApplicationUser user, UserManager<ApplicationUser> _userManager, Jwt jwt)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.JwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(jwt.JwtExpireDays));
            var token = new JwtSecurityToken(
                jwt.JwtIssuer,
                jwt.JwtIssuer,
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}