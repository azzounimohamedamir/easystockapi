using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Clients.Commands;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.GestionEmployees.Employees.Clients.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using SmartRestaurant.Domain.Identity.Entities;

namespace SmartRestaurant.Application.AdminArea.Commands
{
    public class ClientsAppCommandsHandler :
        IRequestHandler<CreateClientAppCommand, Created>,
        IRequestHandler<CreateLicenceCommand, Created>,
        IRequestHandler<UpdateClientAppCommand, NoContent>,
#pragma warning disable CS0535 // 'ClientCommandsHandler' n'implémente pas le membre d'interface 'IRequestHandler<ResetLicenceCommand, NoContent>.Handle(ResetLicenceCommand, CancellationToken)'
        IRequestHandler<ResetLicenceCommand, NoContent>,
#pragma warning restore CS0535 // 'ClientCommandsHandler' n'implémente pas le membre d'interface 'IRequestHandler<ResetLicenceCommand, NoContent>.Handle(ResetLicenceCommand, CancellationToken)'
#pragma warning disable CS0535 // 'ClientCommandsHandler' n'implémente pas le membre d'interface 'IRequestHandler<UpdateLicenceCommand, NoContent>.Handle(UpdateLicenceCommand, CancellationToken)'
      IRequestHandler<UpdateLicenceCommand, NoContent>
#pragma warning restore CS0535 // 'ClientCommandsHandler' n'implémente pas le membre d'interface 'IRequestHandler<UpdateLicenceCommand, NoContent>.Handle(UpdateLicenceCommand, CancellationToken)'

    {
        private readonly IIdentityContext _context;
        private readonly IMapper _mapper;

#pragma warning disable CS1520 // La méthode doit avoir un type de retour
        public ClientsAppCommandsHandler(IIdentityContext context, IMapper mapper)
#pragma warning restore CS1520 // La méthode doit avoir un type de retour
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateClientAppCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateClientAppCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var cl = _mapper.Map<MyClients>(request);           
            _context.MyClients.Add(cl);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

       

        public async Task<Created> Handle(CreateLicenceCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLicenceCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var lic = _mapper.Map<LicenceKeys>(request);
            _context.LicenceKeys.Add(lic);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }


        public async Task<NoContent> Handle(UpdateClientAppCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateClientAppCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var cl = await _context.MyClients.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (cl == null)
                throw new NotFoundException(nameof(Client), request.Id);


            var entity = _mapper.Map<MyClients>(request);
            _context.MyClients.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
        public async Task<NoContent> Handle(UpdateLicenceCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLicenceCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var cl = await _context.LicenceKeys.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (cl == null)
                throw new NotFoundException(nameof(Client), request.Id);


            var entity = _mapper.Map<LicenceKeys>(request);
            _context.LicenceKeys.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(ResetLicenceCommand request, CancellationToken cancellationToken)
        {
            var validator = new ResetLicenceCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var cl = await _context.LicenceKeys.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (cl == null)
                throw new NotFoundException(nameof(Client), request.Id);
           
            _context.LicenceKeys.Update(cl);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

      

    }
}