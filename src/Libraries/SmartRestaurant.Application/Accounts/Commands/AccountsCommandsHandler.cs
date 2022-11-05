using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using FluentValidation.Results;
using SmartRestaurant.Application.Common.Configuration;
using SmartRestaurant.Application.Common.Configuration.SocialMedia;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq;
using SmartRestaurant.Application.Email;

namespace SmartRestaurant.Application.Accounts.Commands
{
    public class AccountsCommandsHandler : 
        IRequestHandler<ForgetPasswordCommand, NoContent>,
        IRequestHandler<ResetPasswordCommand, NoContent>,
        IRequestHandler<AuthenticateViaSocialMediaCommand, LoginResponseDto>,
        IRequestHandler<SendEmailConfirmationCommand, NoContent>,
        IRequestHandler<ConfirmEmailCommad, NoContent>
    {
        private readonly IOptions<EmailTemplates> _emailTemplates;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<WebPortal> _webPortal;
        private readonly IUserService _userService;
        private readonly IOptions<Authentication> _authentication;
        private readonly IMemoryCache _cache;
        private readonly IEmailSender _emailSender;
        public AccountsCommandsHandler(UserManager<ApplicationUser> userManager,
            IOptions<WebPortal> webPortal, IOptions<EmailTemplates> emailTemplates, IUserService userService,
            IOptions<Authentication> authentication, IMemoryCache cache,IEmailSender emailSender)
        {
            _userManager = userManager;
            _webPortal = webPortal;
            _emailTemplates = emailTemplates;
            _userService = userService;
            _authentication = authentication;
            _cache = cache;
            _emailSender = emailSender;
        }

        #region Forget password handler
        public async Task<NoContent> Handle(ForgetPasswordCommand request, CancellationToken cancellationToken)
        {
            var validator = new ForgetPasswordCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var user = await _userManager.FindByEmailAsync(request.Email).ConfigureAwait(false);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.Email);

            var token = await _userManager.GeneratePasswordResetTokenAsync(user).ConfigureAwait(false); ;
            SendResetPasswordEmail(user, token);
            
            return default;
        }

       

        private void SendResetPasswordEmail(ApplicationUser user, string token)
        {   
            var webPortalHost = _webPortal.Value.host;
            var webPortalPathToResetPassword = _webPortal.Value.pathToResetPassword
                .Replace("{id}", user.Id)
                .Replace("{token}", HexaDecimalHelper.ToHexString(token))
                .Replace("{fullName}", user.FullName);
            var linkToResetPasswordWebPage = $"{webPortalHost}{webPortalPathToResetPassword}";

            var userLanguage = _userService.GetUserLanguage();
            var emailSubject = _emailTemplates.Value.resetPassword.SelectLanguage(userLanguage).Subject;
            var emailTemplate = _emailTemplates.Value.resetPassword.SelectLanguage(userLanguage).Template
                .Replace("{linkToResetPasswordWebPage}", linkToResetPasswordWebPage)
                .Replace("{fullName}", user.FullName);
            _emailSender.SendEmail(user.Email, emailSubject, emailTemplate);
        }
        #endregion

        #region Reset password handler
        public async Task<NoContent> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var validator = new ResetPasswordCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var user = await _userManager.FindByIdAsync(request.Id).ConfigureAwait(false);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.Id);

            var passwordResetResult = await _userManager.ResetPasswordAsync(user, HexaDecimalHelper.FromHexString(request.Token), request.Password)
                .ConfigureAwait(false);
            if (!passwordResetResult.Succeeded)
                throw new UserManagerException(passwordResetResult.Errors);

            return default;
        }
        #endregion

        #region Authenticate via social media handler
        public async Task<LoginResponseDto> Handle(AuthenticateViaSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if(user != null && (user.EmailConfirmed == false || user.IsActive == false))
            {
                throw new UnauthorizedException();
            }
            else if (user == null)
            {
                user = new ApplicationUser
                {
                    Id = Guid.NewGuid().ToString(),
                    UserName = request.Email,
                    Email = request.Email,
                    FullName = request.Name,
                    IsActive = true
                };

                using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var userCreationResult = await _userManager.CreateAsync(user);
                    if (!userCreationResult.Succeeded)
                        throw new AccountCreationException(userCreationResult.Errors);

                    var AddRolesToUserResult = await _userManager.AddToRoleAsync(user, Roles.Diner.ToString()).ConfigureAwait(false);
                    if (!AddRolesToUserResult.Succeeded)
                        throw new UserManagerException(AddRolesToUserResult.Errors);

                    var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user).ConfigureAwait(false);
                    SendConfirmEmail(user, emailToken);

                    transaction.Complete();
                }
            }

            var token = await TokenGenerator.Generate(user, _userManager, _authentication.Value.Jwt);
            var roles = await _userManager.GetRolesAsync(user);
            return new LoginResponseDto
            {
                Id = user.Id,
                UserName = user.UserName,
                Roles = (List<string>)roles,
                Token = token,
                EmailConfirmed = user.EmailConfirmed
            };
        }

        private void SendConfirmEmail(ApplicationUser user, string token)
        {
            var webPortalHost = _webPortal.Value.host;
            var webPortalPathToConfirmEmail = _webPortal.Value.pathToConfirmEmail
                .Replace("{id}", user.Id)
                .Replace("{token}", HexaDecimalHelper.ToHexString(token))
                .Replace("{fullName}", HexaDecimalHelper.ToHexString(user.FullName));
            var linkToConfirmEmailWebPage = $"{webPortalHost}{webPortalPathToConfirmEmail}";

            var userLanguage = _userService.GetUserLanguage();
            var emailSubject = _emailTemplates.Value.ConfirmEmail.SelectLanguage(userLanguage).Subject;
            var emailTemplate = _emailTemplates.Value.ConfirmEmail.SelectLanguage(userLanguage).Template
                .Replace("{linkToConfirmEmailWebPage}", linkToConfirmEmailWebPage)
                .Replace("{fullName}", user.FullName);
            _emailSender.SendEmail(user.Email, emailSubject, emailTemplate);
        }

        public Task<NoContent> Handle(SendEmailConfirmationCommand request, CancellationToken cancellationToken)
        {
            SendConfirmEmail(request.User, request.token);
            return default;
        }


        #endregion
        
        #region Confirmation Email
        public async Task<NoContent> Handle(ConfirmEmailCommad request, CancellationToken cancellationToken)
        {
            var validator = new ConfirmEmailCommadValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var user = await _userManager.FindByIdAsync(request.UserId).ConfigureAwait(false);
            if (user == null)
                throw new NotFoundException("User",HexaDecimalHelper.FromHexString(request.FullName));
            var convertedTocken = Application.Common.Tools.HexaDecimalHelper.FromHexString(request.Token);
            var Confirmresult = await _userManager.ConfirmEmailAsync(user, convertedTocken).ConfigureAwait(false);
            if (!Confirmresult.Succeeded && Confirmresult.Errors.Any())
            {
                throw new ValidationException(new ValidationResult(Confirmresult.Errors.Select(x => new ValidationFailure(x.Code, x.Description))));
            }
            return default;
        }

        protected Task SendPassword(string email, string password)
        {
           _emailSender.SendEmail(email, "Password", $"Please use this Password: {password} to sign in to your account");
           return default;
        }
        #endregion

    }
}
