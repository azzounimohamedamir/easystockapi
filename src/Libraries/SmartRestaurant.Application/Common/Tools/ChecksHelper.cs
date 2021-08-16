using FluentValidation;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Identity.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Common.Tools
{
    public class ChecksHelper
    {
        public static async Task CheckUserExistence_ThrowExceptionIfUserNotFound(IIdentityContext identityContext, string userId)
        {
            var user = await identityContext.ApplicationUser.FindAsync(userId).ConfigureAwait(false);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), userId);
        }

        public static string GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(IUserService userService)
        {
            string userId = userService.GetUserId();
            if (userId == null || userId == String.Empty)
                throw new InvalidOperationException("Token: UserId shouldn't be null or  empty");
            return userId;
        }

        public static async Task CheckValidation_ThrowExceptionIfQueryIsInvalid<Validator, Request>(Request request, CancellationToken cancellationToken) where Validator : AbstractValidator<Request>, new()
        {
            var validator = new Validator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid)
                throw new Exceptions.ValidationException(result);
        }
    }
}
