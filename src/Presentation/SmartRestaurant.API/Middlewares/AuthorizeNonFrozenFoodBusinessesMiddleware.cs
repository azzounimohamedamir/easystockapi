using Microsoft.AspNetCore.Http;
using SmartRestaurant.Domain.Identity.Enums;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using SmartRestaurant.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Domain.Entities;
using Newtonsoft.Json;

namespace SmartRestaurant.API.Middlewares
{
    public class AuthorizeNonFrozenFoodBusinessesMiddleware
    {
        private readonly RequestDelegate _next;
     
        public AuthorizeNonFrozenFoodBusinessesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IApplicationDbContext _context)
        {        
            if (    IsFoodBusinessUser(context) 
                && !IsAnonymousEndpoint(context) 
                && !IsGetEndpoint(context)
                && !IsFoodBusinessStaffEndpoint(context)
                && !IsFoodBusinessEndpoint(context)
                )
            {
                var foodBusinessId = context.Request.Headers["FoodBusinessId"].ToString();
                if (string.IsNullOrWhiteSpace(foodBusinessId))
                {
                    await ReturnHttpResponse(context, new ValidationException("Important http headers are missing"));
                    return;
                }

                var foodBusiness = await _context.FoodBusinesses.AsNoTracking()
                   .FirstOrDefaultAsync(foodBusinesses => foodBusinesses.FoodBusinessId == Guid.Parse(foodBusinessId))
                   .ConfigureAwait(false);

                if (foodBusiness == null)
                {
                    await ReturnHttpResponse(context, new NotFoundException(nameof(FoodBusiness), foodBusinessId));
                    return;
                }

                if (foodBusiness.IsActivityFrozen)
                {
                    await ReturnHttpResponse(context, new FoodBusinessActivityFrozenException(foodBusiness.Name));
                    return;
                }
            }
            await _next.Invoke(context);
        }
       
        private async Task ReturnHttpResponse(HttpContext context, Exception exception)
        {
            if (exception.GetType().IsSubclassOf(typeof(BaseException)))
            {
                var baseException = (BaseException)exception;

                context.Response.StatusCode = baseException.StatusCode;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync(JsonConvert.SerializeObject(new
                {
                    message = baseException.Message,
                    errors = baseException.Errors
                }));
            }
        }

        private bool IsAnonymousEndpoint(HttpContext context)
        {
            return context.GetEndpoint()?.Metadata?.GetMetadata<IAllowAnonymous>() is object;
        }

        private bool IsFoodBusinessStaffEndpoint(HttpContext context)
        {
            return context.Request.Path.Value.Contains("api/foodbusinessstaff");
        }

        private bool IsFoodBusinessEndpoint(HttpContext context)
        {
            return context.Request.Path.Value.Contains("api/foodbusiness");
        }
              
        private bool IsGetEndpoint(HttpContext context)
        {
            return context.Request.Method == "GET";
        }

        private bool IsFoodBusinessUser(HttpContext context)
        {
            var access_token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            if(string.IsNullOrWhiteSpace(access_token))
                return false;

            var identity = new JwtSecurityTokenHandler().ReadJwtToken(access_token);
            if (identity != null)
            {
                var role = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value;
                if (role == null)
                    return false;

                var regex =
                    $"^(?:{Roles.FoodBusinessAdministrator.ToString()}" +
                    $"|{Roles.FoodBusinessManager.ToString()}" +
                    $"|{Roles.FoodBusinessOwner.ToString()}" +
                    $"|{Roles.Chef.ToString()}" +
                    $"|{Roles.Cashier.ToString()}" +
                    $"|{Roles.Waiter.ToString()})$";
                return new Regex(regex).Match(role).Success;
            }
            return false; 
        }
    }
}
