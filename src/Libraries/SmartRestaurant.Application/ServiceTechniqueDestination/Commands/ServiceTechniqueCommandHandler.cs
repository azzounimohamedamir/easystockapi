using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.TypeReclamation.Commands;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.ServiceTechniqueDestination.Commands
{
    public class ServiceTechniqueCommandHandler :
        IRequestHandler<CreateServiceTechniqueCommand, Created>,
        IRequestHandler<UpdateServiceTechniqueCommand, NoContent>,
        IRequestHandler<DeleteServiceTechniqueCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ServiceTechniqueCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateServiceTechniqueCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateServiceTechniqueCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var serviceTechnique = _mapper.Map<ServiceTechnique>(request);
            _context.ServiceTechniques.Add(serviceTechnique);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteServiceTechniqueCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteServiceTechniqueCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var servicetech = await _context.ServiceTechniques.FindAsync(request.Id).ConfigureAwait(false);
            if (servicetech == null)
                throw new NotFoundException(nameof(ServiceTechnique), request.Id);
            _context.ServiceTechniques.Remove(servicetech);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateServiceTechniqueCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateServiceTechniqueCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var servicetech = await _context.ServiceTechniques.AsNoTracking()
                .FirstOrDefaultAsync(s => s.ServiceTechniqueId == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (servicetech == null)
                throw new NotFoundException(nameof(ServiceTechnique), request.Id);
            var entity = _mapper.Map<ServiceTechnique>(request);
            _context.ServiceTechniques.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }


    } 
}