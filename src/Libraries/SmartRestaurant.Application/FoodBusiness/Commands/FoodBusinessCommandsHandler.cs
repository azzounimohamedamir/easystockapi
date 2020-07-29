using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class FoodBusinessCommandHandler :
    IRequestHandler<CreateFoodBusinessCommand, ValidationResult>,
    IRequestHandler<UpdateFoodBusinessCommand, ValidationResult>,
    IRequestHandler<DeletefoodBusinessCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FoodBusinessCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ValidationResult> Handle(CreateFoodBusinessCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateRestaurantCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var entity = _mapper.Map<Domain.Entities.FoodBusiness>(request);
            _context.FoodBusinesses.Add(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<Unit> Handle(DeletefoodBusinessCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.FoodBusinesses.FindAsync(request.RestaurantId).ConfigureAwait(false);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.FoodBusiness), request.RestaurantId);

            _context.FoodBusinesses.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return Unit.Value;
        }

        public async Task<ValidationResult> Handle(UpdateFoodBusinessCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.FoodBusinesses.FindAsync(request.CmdId).ConfigureAwait(true);

            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.FoodBusiness), request.CmdId);
      
            var validator = new UpdateRestaurantCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            entity = _mapper.Map<Domain.Entities.FoodBusiness>(request);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return default;
        }
    }
}
