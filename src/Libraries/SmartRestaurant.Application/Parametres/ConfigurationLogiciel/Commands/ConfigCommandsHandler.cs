using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.Parametres.SocieteInfo.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Parametres.ConfigurationLogiciel.Commands
{
    public class ConfigCommandsHandler :
        IRequestHandler<CreateDefaultConfigCommand, Created>,
        IRequestHandler<UpdateDefaultConfigCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ConfigCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateDefaultConfigCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDefaultConfigCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var config = _mapper.Map<Domain.Entities.DefaultConfigLog>(request);
            _context.DefaultConfigLogs.Add(config);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }



        public async Task<NoContent> Handle(UpdateDefaultConfigCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDefaultConfigCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var config = await _context.DefaultConfigLogs.AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (config == null)
                throw new NotFoundException(nameof(config), request.Id);


            var entity = _mapper.Map<Domain.Entities.DefaultConfigLog>(request);
            _context.DefaultConfigLogs.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

    }
}