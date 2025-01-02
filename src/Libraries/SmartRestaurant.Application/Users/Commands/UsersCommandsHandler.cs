using System.IO;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.Users.Queries;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;

namespace SmartRestaurant.Application.Users.Commands
{
    public class UsersCommandsHandler :
                IRequestHandler<SetNewPasswordForFoodBusinessAdministratorCommand, NoContent>,
                IRequestHandler<UpdateUserCommand, NoContent>,
                IRequestHandler<UpdateProfileCommand, NoContent>,
                IRequestHandler<UpdateProfileImageCommand, NoContent>

    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public UsersCommandsHandler(UserManager<ApplicationUser> userManager, IUserService userService, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userService = userService;

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

        #region Update user acoount
        public async Task<NoContent> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await ChecksHelper.CheckValidation_ThrowExceptionIfQueryIsInvalid<UpdateUserCommandValidator, UpdateUserCommand>
                (request, cancellationToken).ConfigureAwait(false);

            var user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
                throw new NotFoundException(nameof(user), request.Id);

            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var oldRoles = await _userManager.GetRolesAsync(user);
                foreach(var role in oldRoles)
                {
                    var removeRoleResult = await _userManager.RemoveFromRoleAsync(user, role);
                    if (!removeRoleResult.Succeeded)
                        throw new UserManagerException(removeRoleResult.Errors);
                }

                foreach (var role in request.Roles)
                {
                    var addRoleResult = await _userManager.AddToRoleAsync(user, role);
                    if (!addRoleResult.Succeeded)
                        throw new UserManagerException(addRoleResult.Errors);
                }

                 _mapper.Map(request, user);
                var userUpdateResult = await _userManager.UpdateAsync(user);
                if (!userUpdateResult.Succeeded)
                    throw new UserManagerException(userUpdateResult.Errors);

                transaction.Complete();
            }

            return default;
        }
        #endregion


        #region Profile Update
        public async Task<NoContent> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            await ChecksHelper.CheckValidation_ThrowExceptionIfQueryIsInvalid<UpdateProfileCommandValidator, UpdateProfileCommand>
                (request, cancellationToken).ConfigureAwait(false);

            var user_id = _userService.GetUserId();

            var user = await _userManager.FindByIdAsync(user_id);
            if (user == null)
                throw new NotFoundException(nameof(user), user_id);

            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _mapper.Map(request, user);
                var userUpdateResult = await _userManager.UpdateAsync(user);
                if (!userUpdateResult.Succeeded)
                    throw new UserManagerException(userUpdateResult.Errors);

                transaction.Complete();
            }

            return default;
        }
        #endregion

        #region Profile Image Update
        public async Task<NoContent> Handle(UpdateProfileImageCommand request, CancellationToken cancellationToken)
        {
            await ChecksHelper.CheckValidation_ThrowExceptionIfQueryIsInvalid<UpdateProfileImageCommandValidator, UpdateProfileImageCommand>
                (request, cancellationToken).ConfigureAwait(false);

            var user_id = _userService.GetUserId();

            var user = await _userManager.FindByIdAsync(user_id);
            if (user == null)
                throw new NotFoundException(nameof(user), user_id);

            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _mapper.Map(request, user);
                //user.Picture = request.Picture;
                //using (var ms = new MemoryStream())
                //{
                //    request.Picture.CopyTo(ms);
                //    user.Picture = ms.ToArray();
                //}
                var userUpdateResult = await _userManager.UpdateAsync(user);
                if (!userUpdateResult.Succeeded)
                    throw new UserManagerException(userUpdateResult.Errors);

                transaction.Complete();
            }

            return default;
        }
        #endregion
    }
}