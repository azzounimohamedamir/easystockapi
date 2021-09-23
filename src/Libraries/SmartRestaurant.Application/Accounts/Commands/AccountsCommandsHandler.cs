using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SmartRestaurant.Application.Common.Configuration;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Identity.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Accounts.Commands
{
    public class AccountsCommandsHandler : IRequestHandler<ForgetPasswordCommand, NoContent>
    {
        private readonly IOptions<EmailTemplates> _emailTemplates;
        private readonly IOptions<SmtpConfig> _smtpConfig;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<WebPortal> _webPortal;
        private readonly IUserService _userService;

        public AccountsCommandsHandler(UserManager<ApplicationUser> userManager, IOptions<SmtpConfig> smtpConfig,
            IOptions<WebPortal> webPortal, IOptions<EmailTemplates> emailTemplates, IUserService userService)
        {
            _userManager = userManager;
            _smtpConfig = smtpConfig;
            _webPortal = webPortal;
            _emailTemplates = emailTemplates;
            _userService = userService;
        }

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
            new EmailHelper(_smtpConfig.Value).SendEmail(user.Email, emailSubject, emailTemplate);
        }
    }
}
