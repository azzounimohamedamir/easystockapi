using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.DishIngredients.Commands
{
    public class DishIngredientsCommandsHandler : IRequestHandler<CreateDishIngredientCommand, Created>,
        IRequestHandler<DeleteDishIngredientCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DishIngredientsCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateDishIngredientCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateDishIngredientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var dish = await _context.Dishes.FindAsync(request.DishId);
            if (dish == null) throw new NotFoundException(nameof(Dish), request.DishId);
            var ingredient = await _context.Ingredients.FindAsync(request.IngredientId);
            if (ingredient == null) throw new NotFoundException(nameof(Ingredient), request.IngredientId);
            IngredientQuantityCheck(request, ingredient);
            var dishIngredient = _mapper.Map<DishIngredient>(request);
            _context.DishIngredients.Add(dishIngredient);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

        public async Task<NoContent> Handle(DeleteDishIngredientCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteDishIngredientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var dishIngredient = await _context.DishIngredients.FindAsync(request.Id);
            if (dishIngredient == null) throw new NotFoundException(nameof(DishIngredient), request.Id);
            _context.DishIngredients.Remove(dishIngredient);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

        private static void IngredientQuantityCheck(CreateDishIngredientCommand request, Ingredient ingredient)
        {
            //if (request.Quantity.MeasurementUnit != ingredient.MaxQuantity.MeasurementUnits.ToString()) return;
            //if (request.Quantity.Amount > ingredient.MaxQuantity.Amount)
            //    throw new QuantityNotAllowedException(ingredient.Name, request.Quantity.Amount,
            //        ingredient.MaxQuantity.Amount,
            //        request.Quantity.MeasurementUnit);
        }
    }
}