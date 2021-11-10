using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Illness.Commands
{
    public class IllnessCommandsHandler :
        IRequestHandler<CreateIllnessCommand, Created>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public IllnessCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateIllnessCommand request, CancellationToken cancellationToken)
        {
            if (request.Ingredients == null)
                request.Ingredients = new List<IngredientIllnessDto>();

            var validator = new CreateIllnessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var illness = _mapper.Map<Domain.Entities.Illness>(request);
            _context.Illnesses.Add(illness);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

    }
}
