using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.GestionEmployees.Employees.Clients.Commands;
using Microsoft.Extensions.Options;
using SmartRestaurant.Application.Common.Configuration;
using Microsoft.AspNetCore.Identity;
using SmartRestaurant.Domain.Identity.Entities;
using System.Security;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Permissions.Commands
{
    public class PermissionsCommandsHandler :
        IRequestHandler<AjouterPermRoleCommand, Created>,
        IRequestHandler<UpdatePermRoleCommand, NoContent>
       

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IIdentityContext _identcontext;

        private readonly IOptions<EmailTemplates> _emailTemplates;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IOptions<WebPortal> _webPortal;
        private readonly IUserService _userService;
        private readonly IEmailSender _emailSender;
        public PermissionsCommandsHandler(IApplicationDbContext context, IIdentityContext identityContext, IEmailSender emailSender,
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

    public async Task<Created> Handle(AjouterPermRoleCommand request, CancellationToken cancellationToken)
        {
            var validator = new AjouterPermRoleCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var exist = await _identcontext.Permissions.AsNoTracking()
                           .FirstOrDefaultAsync(m => m.Role == request.Role, cancellationToken)
                           .ConfigureAwait(false);
            if (exist == null)
            {
                var permission = _mapper.Map<Domain.Identity.Entities.Permissions>(request);

                _identcontext.Permissions.Add(permission);
                await _identcontext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            else
            {
                // remove exist record and replaced by new 
                _identcontext.Permissions.Remove(exist);
                await _identcontext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                var permission = _mapper.Map<Domain.Identity.Entities.Permissions>(request);

                _identcontext.Permissions.Add(permission);
                await _identcontext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }

            return default;
        }

      

        public async Task<NoContent> Handle(UpdatePermRoleCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdatePermRoleCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var permission = await _identcontext.Permissions.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (permission == null)
                throw new NotFoundException(nameof(Domain.Identity.Entities.Permissions), request.Id);


            var entity = _mapper.Map<Domain.Identity.Entities.Permissions>(request);
            _identcontext.Permissions.Update(entity);
            await _identcontext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

      

    }
}