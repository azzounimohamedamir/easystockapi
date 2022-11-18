using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using MediatR;
using AutoMapper;
using System.Threading.Tasks;
using System.Threading;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.HotelSections.Commands
{
    public class HotelSectionCommandsHandlercs :
        IRequestHandler<CreateHotelSectionCommand, Created>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public HotelSectionCommandsHandlercs(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateHotelSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateHotelSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var section = _mapper.Map<HotelSection>(request);
            _context.HotelSections.Add(section);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}
