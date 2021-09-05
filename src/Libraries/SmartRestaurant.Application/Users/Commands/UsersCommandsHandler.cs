using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;

namespace SmartRestaurant.Application.Users.Queries
{
    public class UsersCommandsHandler :
                IRequestHandler<SetNewPasswordForFoodBusinessAdministratorCommand, NoContent>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersCommandsHandler(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        #region Set new password for FoodBusinessAdministrator account
        public async Task<NoContent> Handle(SetNewPasswordForFoodBusinessAdministratorCommand request, CancellationToken cancellationToken)
        {
            await ChecksHelper.CheckValidation_ThrowExceptionIfQueryIsInvalid
                <SetNewPasswordForFoodBusinessAdministratorCommandValidator, SetNewPasswordForFoodBusinessAdministratorCommand>
                    (request, cancellationToken).ConfigureAwait(false);

            var user = await _userManager.FindByIdAsync(request.Id).ConfigureAwait(false);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.Id);

            var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            if (!roles.Contains(Roles.FoodBusinessAdministrator.ToString()))
                throw new RolesCheckException("You can set a new password only for FoodBusinessAdministrator account");

            var resetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var passwordResetResult = await _userManager.ResetPasswordAsync(user, resetPasswordToken, request.NewPassword);
            if (!passwordResetResult.Succeeded)
                throw new UserManagerException(passwordResetResult.Errors);

            return default;
        }
        #endregion
    }
}