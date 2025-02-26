using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SmartRestaurant.Application.Common.Configuration;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace SmartRestaurant.Application.FoodBusinessEmployee.Commands
{
    public class FoodBusinessEmployeeCommandsHandler :
        IRequestHandler<InviteUserToJoinOrganizationCommand, Created>,
        IRequestHandler<UpdateProfilUserCommand, NoContent>,

        IRequestHandler<UserAcceptsInvitationToJoinOrganizationCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityContext _identcontext;

        private readonly IOptions<EmailTemplates> _emailTemplates;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<WebPortal> _webPortal;
        private readonly IUserService _userService;
        private readonly IEmailSender _emailSender;

        public FoodBusinessEmployeeCommandsHandler(IApplicationDbContext context, IIdentityContext identityContext, IEmailSender emailSender,
            UserManager<ApplicationUser> userManager, IMapper mapper,
            IOptions<WebPortal> webPortal, IOptions<EmailTemplates> emailTemplates, IUserService userService)
        {
            _identcontext = identityContext;
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _webPortal = webPortal;
            _emailTemplates = emailTemplates;
            _userService = userService;
            _emailSender = emailSender;
        }







        #region UserAcceptsInvitationToJoinOrganizationHandler

        public async Task<NoContent> Handle(UserAcceptsInvitationToJoinOrganizationCommand request,
            CancellationToken cancellationToken)
        {
            await ChecksHelper.CheckValidation_ThrowExceptionIfQueryIsInvalid
                <UserAcceptsInvitationToJoinOrganizationValidator, UserAcceptsInvitationToJoinOrganizationCommand>
                (request, cancellationToken).ConfigureAwait(false);

            var user = await _userManager.FindByIdAsync(request.Id).ConfigureAwait(false);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.Id);

            if (!user.Email.Equals(request.Email, StringComparison.OrdinalIgnoreCase))
                throw new NotFoundException(nameof(ApplicationUser), request.Email);

            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                _mapper.Map(request, user);

                var userUpdateResult = await _userManager.UpdateAsync(user);
                if (!userUpdateResult.Succeeded)
                    throw new UserManagerException(userUpdateResult.Errors);

                var passwordResetResult = await _userManager.ResetPasswordAsync(user, HexaDecimalHelper.FromHexString(request.Token), request.Password);
                if (!passwordResetResult.Succeeded)
                    throw new UserManagerException(passwordResetResult.Errors);

                transaction.Complete();
            }

            return default;
        }

        #endregion

        #region InviteUserToJoinOrganizationHandler

        public async Task<Created> Handle(InviteUserToJoinOrganizationCommand request,
            CancellationToken cancellationToken)
        {
            await ChecksHelper.CheckValidation_ThrowExceptionIfQueryIsInvalid
                <InviteUserToJoinOrganizationCommandValidator, InviteUserToJoinOrganizationCommand>
                (request, cancellationToken).ConfigureAwait(false);
            var newUser = _mapper.Map<ApplicationUser>(request);
            var IsExist = CkeckUserIfExistInApplicationUser(newUser.Email);
            if (!IsExist)
            {
                await CreateUserAndAssignRolesToHim(request, newUser).ConfigureAwait(false);

                await SendConfirmationEmail(newUser);
                return default;
            }
            else
            {
                var newapplicationUser = _identcontext.ApplicationUser.Where(a => a.Email == newUser.Email).FirstOrDefault();
                var newapplicationUserId = newapplicationUser.Id;


                await SendConfirmationEmail(newapplicationUser);

                return default;
            }

        }




        public async Task<NoContent> Handle(UpdateProfilUserCommand request,
           CancellationToken cancellationToken)
        {

            var newUser = _mapper.Map<ApplicationUser>(request);
            var user = _identcontext.ApplicationUser.FirstOrDefault(a => a.Id == request.Id.ToString());


            if (user != null)
                user.FullName = request.FullName;
            user.PhoneNumber = request.PhoneNumber;
            _identcontext.ApplicationUser.Update(user);

            await _identcontext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // update User Fullname in all VC FACTURE , and BL 

            var vcs = _context.VenteComptoirs.Where(full => full.NomCaissier == user.FullName).ToList();
            var facts = _context.Factures.Where(full => full.NomCaissier == user.FullName).ToList();
            var bls = _context.Bls.Where(full => full.NomCaissier == user.FullName).ToList();

            var caisses = _context.Caisses.Where(full => full.UserId.ToString() == user.Id).ToList();
            foreach (var vc in vcs)
            {

                vc.NomCaissier = request.FullName; // Update FullName to specific value
                _context.VenteComptoirs.Update(vc);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);// Save changes to the database

            }
            foreach (var bl in bls)
            {

                bl.NomCaissier = request.FullName; // Update FullName to specific value
                _context.Bls.Update(bl);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);// Save changes to the database

            }
            foreach (var f in facts)
            {

                f.NomCaissier = request.FullName; // Update FullName to specific value
                _context.Factures.Update(f);
                await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);// Save changes to the database

            }
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);// Save changes to the database
            foreach (var c in caisses)
            {

                c.Vendeur = request.FullName; // Update FullName to specific value
                _context.Caisses.Update(c);
            }
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);// Save changes to 







            return default;
        }



        private async Task CreateUserAndAssignRolesToHim(InviteUserToJoinOrganizationCommand request,
            ApplicationUser newUser)
        {
            using (var transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var randomPassword = request.Password;
                newUser.EmailConfirmed = true;
                var userCreationResult = await _userManager.CreateAsync(newUser, randomPassword);
                if (!userCreationResult.Succeeded)
                    throw new AccountCreationException(userCreationResult.Errors);
                await GrantRoles(request.Roles, newUser).ConfigureAwait(false);
                transaction.Complete();
            }
        }


        private bool CkeckUserIfExistInApplicationUser(string email)
        {
            var checkInApplicationUser = _identcontext.ApplicationUser.Where(a => a.Email.ToUpper() == email.ToUpper()).FirstOrDefault();
            if (checkInApplicationUser != null)
            {
                return true;
            }
            return false;

        }

        private async Task GrantRoles(List<string> roles, ApplicationUser user)
        {
            foreach (var role in roles) await _userManager.AddToRoleAsync(user, role).ConfigureAwait(false);
        }

        private async Task SendConfirmationEmail(ApplicationUser user)
        {
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var webPortalHost = _webPortal.Value.host;
            var webPortalPathToEmployeeAcceptInvitation = _webPortal.Value.pathToEmployeeAcceptInvitation
                .Replace("{id}", user.Id)
                .Replace("{token}", HexaDecimalHelper.ToHexString(token));
            var linkToAcceptInvitationWebPage = $"{webPortalHost}{webPortalPathToEmployeeAcceptInvitation}";

            var userLanguage = _userService.GetUserLanguage();
            var emailSubject = _emailTemplates.Value.InvitationToJoinOrganization.SelectLanguage(userLanguage).Subject;
            var emailTemplate = _emailTemplates.Value.InvitationToJoinOrganization.SelectLanguage(userLanguage).Template
                .Replace("{linkToAcceptInvitationWebPage}", linkToAcceptInvitationWebPage);
            _emailSender.SendEmail(user.Email, emailSubject, emailTemplate);
        }

        #endregion


    }
}