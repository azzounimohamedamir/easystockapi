using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Dishes.Commands
{
    public class DishesCommandsHandler : IRequestHandler<CreateDishCommand, Created>,
        IRequestHandler<UpdateDishCommand, NoContent>,
        IRequestHandler<DeleteDishCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public DishesCommandsHandler(IApplicationDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Created> Handle(CreateDishCommand request, CancellationToken cancellationToken)
        {
            if (request.Supplements == null)
                request.Supplements = new List<DishSupplementCreateDto>();

            var validator = new CreateDishCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
            if (foodBusiness == null) 
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);
            
            var dish = _mapper.Map<Dish>(request);
            dish.EnergeticValue = await CalculateEnergeticValue(request.Ingredients).ConfigureAwait(false);
            dish.CreatedBy = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            dish.CreatedAt = DateTime.Now;

            _context.Dishes.Add(dish);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

        public async Task<NoContent> Handle(DeleteDishCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteDishCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var dish = await _context.Dishes.FindAsync(Guid.Parse(request.Id)).ConfigureAwait(false);
            if (dish == null) throw new NotFoundException(nameof(Dish), request.Id);

            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

        public async Task<NoContent> Handle(UpdateDishCommand request, CancellationToken cancellationToken)
        {
            if (request.Supplements == null)
                    request.Supplements = new List<DishSupplementCreateDto>();

            var validator = new UpdateDishCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var dish = await _context.Dishes
                  .Include(x => x.Ingredients)
                  .ThenInclude(x => x.Ingredient)
                  .Include(x => x.Supplements)
                  .ThenInclude(x => x.Supplement)
                  .Include(x => x.Specifications)
                  .Where(u => u.DishId == Guid.Parse(request.Id))
                  .FirstOrDefaultAsync()
                  .ConfigureAwait(false);
            if (dish == null)
                throw new NotFoundException(nameof(Dishes), request.Id);

            _mapper.Map(request, dish);
            dish.EnergeticValue = await CalculateEnergeticValue(request.Ingredients).ConfigureAwait(false);
            dish.LastModifiedBy = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            dish.LastModifiedAt = DateTime.Now;

            _context.Dishes.Update(dish);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

        private async Task<float> CalculateEnergeticValue(List<DishIngredientCreateDto> dishIngredients)
        {
            if (dishIngredients != null)
            {
                List<float> energeticValues = new List<float>();
                var listOfIngredientsIds = dishIngredients.Select(x => Guid.Parse(x.IngredientId)).ToList();
                var ingredients = await _context.Ingredients.Where(x => listOfIngredientsIds.Contains(x.IngredientId))
                    .ToListAsync()
                    .ConfigureAwait(false);
                foreach(var ingredient in ingredients)
                {
                    var dishIngredient = dishIngredients.FirstOrDefault(x => x.IngredientId == ingredient.IngredientId.ToString());
                    if (ingredient.EnergeticValue.Amount == 0)
                    {
                        energeticValues.Add(0);
                    }
                    else if (dishIngredient.MeasurementUnits == ingredient.EnergeticValue.MeasurementUnit)
                    {
                        energeticValues.Add(((dishIngredient.InitialAmount * ingredient.EnergeticValue.Energy) / ingredient.EnergeticValue.Amount));
                    }
                    else
                    {
                        switch(dishIngredient.MeasurementUnits)
                        {
                            case MeasurementUnits.Gramme:
                                energeticValues.Add(((dishIngredient.InitialAmount * (ingredient.EnergeticValue.Energy/1000)) / ingredient.EnergeticValue.Amount));

                                break;
                            case MeasurementUnits.KiloGramme:
                                energeticValues.Add(((dishIngredient.InitialAmount * (ingredient.EnergeticValue.Energy * 1000)) / ingredient.EnergeticValue.Amount));
                                break;
                            case MeasurementUnits.MilliLiter:
                                energeticValues.Add(((dishIngredient.InitialAmount * (ingredient.EnergeticValue.Energy / 1000)) / ingredient.EnergeticValue.Amount));

                                break;
                            case MeasurementUnits.Liter:
                                energeticValues.Add(((dishIngredient.InitialAmount * (ingredient.EnergeticValue.Energy * 1000)) / ingredient.EnergeticValue.Amount));
                                break;
                        }
                    }
                }
                return energeticValues.Sum(x => x);
            }
            return 0;
        }
    }
}