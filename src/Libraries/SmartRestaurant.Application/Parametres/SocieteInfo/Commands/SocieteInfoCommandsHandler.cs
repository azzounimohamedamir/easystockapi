using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.Parametres.SocieteInfo.Commands
{
    public class SocieteInfoCommandsHandler :
        IRequestHandler<CreateSocieteInfoCommand, Created>,
        IRequestHandler<UpdateSocieteInfoCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SocieteInfoCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateSocieteInfoCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSocieteInfoCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var societeInfo = _mapper.Map<Domain.Entities.SocieteInfo>(request);
            _context.SocieteInfos.Add(societeInfo);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

      

        public async Task<NoContent> Handle(UpdateSocieteInfoCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSocieteInfoCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var soc = await _context.SocieteInfos.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (soc == null)
                throw new NotFoundException(nameof(soc), request.Id);


            var entity = _mapper.Map<Domain.Entities.SocieteInfo>(request);
            _context.SocieteInfos.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

    }
}