using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Dishes.Commands
{
    public class DishesCommandsHandler : IRequestHandler<CreateDishCommand, Created>,
        IRequestHandler<UpdateDishCommand, NoContent>,
        IRequestHandler<DeleteDishCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DishesCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDishCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var foodBusiness = await _context.FoodBusinesses.FindAsync(request.FoodBusinessId);
            if (foodBusiness == null) throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);
            var dish = _mapper.Map<Dish>(request);
            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

        public async Task<NoContent> Handle(DeleteDishCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteDishCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var dish = await _context.Dishes.FindAsync(request.Id);
            if (dish == null) throw new NotFoundException(nameof(Dish), request.Id);
            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

        public async Task<NoContent> Handle(UpdateDishCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDishCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var foodBusiness = await _context.FoodBusinesses.FindAsync(request.FoodBusinessId);
            if (foodBusiness == null) throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);
            var dish = _mapper.Map<Dish>(request);
            _context.Dishes.Update(dish);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}