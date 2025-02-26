using FluentValidation;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = SmartRestaurant.Application.Common.Exceptions.ValidationException;

namespace SmartRestaurant.Application.Common.Tools
{
    public class ChecksHelper
    {
        public static async Task CheckUserExistence_ThrowExceptionIfUserNotFound(IIdentityContext identityContext,
            string userId)
        {
            var user = await identityContext.ApplicationUser.FindAsync(userId).ConfigureAwait(false);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), userId);
        }

        public static string GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(IUserService userService)
        {
            var userId = userService.GetUserId();
            if (userId == null || userId == string.Empty)
                throw new InvalidOperationException("Token: UserId shouldn't be null or  empty");
            return userId;
        }

        public static async Task CheckValidation_ThrowExceptionIfQueryIsInvalid<Validator, Request>(Request request,
            CancellationToken cancellationToken) where Validator : AbstractValidator<Request>, new()
        {
            var validator = new Validator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid)
                throw new ValidationException(result);
        }

        public static bool IsFloatNumber(string text)
        {
            try { float.Parse(text); return true; }
            catch (Exception) { return false; }
        }

        public static bool IsEmptyList<T>(List<T> list)
        {
            if (list == null)
            {
                return true;
            }

            return !list.Any();
        }
    }
}