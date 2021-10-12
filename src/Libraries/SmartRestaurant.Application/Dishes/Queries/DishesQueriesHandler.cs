using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Dishes.Queries
{
    public class DishesQueriesHandler : IRequestHandler<GetDishByIdQuery, DishDto>,
        IRequestHandler<GetDishesByFoodBusinessIdQuery, PagedListDto<DishDto>>,
        IRequestHandler<GetDishesByMenuIdQuery, PagedListDto<DishDto>>,
        IRequestHandler<GetDishesBySectionIdQuery, PagedListDto<DishDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DishesQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<DishDto> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
        {
            var dish = await _context.Dishes.FindAsync(request.DishId);
            if (dish == null) throw new NotFoundException(nameof(Dish), request.DishId);
            var dto = _mapper.Map<DishDto>(dish);

            var currency = await GetFoodBusinessDefaultCurrency(dish.FoodBusinessId);

            var dishIngredients = MapDishIngredient(dish.DishId);

            dto.Price = MapPrice(dish, currency);
            dto.DishIngredients = _mapper.Map<List<DishIngredientDto>>(dishIngredients);
            CalculateTotal(dish.FoodBusinessId, dto);

            return dto;
        }

        public async Task<PagedListDto<DishDto>> Handle(GetDishesByFoodBusinessIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = _context.Dishes.AsNoTracking().Where(d => d.FoodBusinessId == request.FoodBusinessId)
                .GetPaged(request.Page, request.PageSize);

            if (result.Data.ToList().Count <= 0) return GetEmptyDishList(result);
            return await GetDishesPagedList(request.FoodBusinessId, result);
        }

        public async Task<PagedListDto<DishDto>> Handle(GetDishesByMenuIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = _context.Dishes.Where(d => d.MenuId == request.MenuId)
                .GetPaged(request.Page, request.PageSize);

            if (result.Data.ToList().Count <= 0) return GetEmptyDishList(result);
            var dish = result.Data.First();
            return await GetDishesPagedList(dish.FoodBusinessId, result);
        }

        public async Task<PagedListDto<DishDto>> Handle(GetDishesBySectionIdQuery request,
            CancellationToken cancellationToken)
        {
            var result = _context.Dishes.Where(d => d.SectionId == request.SectionId)
                .GetPaged(request.Page, request.PageSize);

            if (result.Data.ToList().Count <= 0) return GetEmptyDishList(result);
            var dish = result.Data.First();
            return await GetDishesPagedList(dish.FoodBusinessId, result);
        }

        private List<DishIngredientDto> MapDishIngredient(Guid dishId)
        {
            return _context.DishIngredients.Where(di => di.DishId == dishId).Join(_context.Ingredients,
                dishIngredient => dishIngredient.IngredientId,
                ingredient => ingredient.IngredientId, (dishIngredient, ingredient) => new DishIngredientDto
                {
                    DishIngredientId = dishIngredient.DishIngredientId,
                    IngredientName = ingredient.Names,
                    Quantity = _mapper.Map<QuantityDto>(dishIngredient.Quantity),
                    IsPrimary = dishIngredient.IsPrimary,
                    AmountPerStep = _mapper.Map<QuantityDto>(dishIngredient.AmountPerStep),
                    PricePerStep = dishIngredient.PricePerStep,
                    IngredientId = dishIngredient.IngredientId
                }).AsNoTracking().Distinct().ToList();
        }


        private async Task<CurrencyDto> GetFoodBusinessDefaultCurrency(Guid foodBusinessId)
        {
            var foodBusiness = await _context.FoodBusinesses
                .FirstOrDefaultAsync(d => d.FoodBusinessId == foodBusinessId);
            var currency = await _context.Currencies.FindAsync(foodBusiness.DefaultCurrencyId);
            if (currency != null) return _mapper.Map<CurrencyDto>(currency);

            return new CurrencyDto
            {
                Code = "DZD",
                Name = "Algerian Dinar",
                Symbol = "DZD"
            };
        }

        private async Task<PagedListDto<DishDto>> GetDishesPagedList(Guid foodBusinessId, PagedResultBase<Dish> result)
        {
            var currency = await GetFoodBusinessDefaultCurrency(foodBusinessId);

            return new PagedListDto<DishDto>(result.CurrentPage, result.PageCount, result.PageSize,
                result.RowCount, result.Data.AsEnumerable().Select(d =>
                {
                    var dto = new DishDto
                    {
                        DishId = d.DishId,
                        Name = d.Name,
                        IsSupplement = d.IsSupplement,
                        AveragePreparationTime = new DurationDto
                        {
                            Value = d.AveragePreparationTime.Value,
                            TimeUnits = d.AveragePreparationTime.TimeUnits.ToString()
                        },
                        DishIngredients = MapDishIngredient(d.DishId),
                        Price = MapPrice(d, currency)
                    };
                    CalculateTotal(foodBusinessId, dto);
                    return dto;
                }).ToList());
        }

        private void CalculateTotal(Guid foodBusinessId, DishDto dish)
        {
            //var ingredients = _context.Ingredients.Where(i => i.FoodBusinessId == foodBusinessId).ToList();

            //foreach (var ingredient in dish.DishIngredients.Select(dishIngredient =>
            //    ingredients.FirstOrDefault(i => i.IngredientId == dishIngredient.IngredientId)))
            //{
            //    if (ingredient == null) continue;
            //    dish.TotalFat += ingredient.Fat;
            //    dish.TotalCarbs += ingredient.Carbs;
            //    dish.TotalProtein += ingredient.Protein;
            //    dish.TotalEnergy += ingredient.Energy;
            //}
        }

        private PriceDto MapPrice(Dish dish, CurrencyDto currency)
        {
            return new PriceDto
            {
                Value = dish.PriceAmount,
                Currency = _mapper.Map<CurrencyDto>(currency)
            };
        }

        private static PagedListDto<DishDto> GetEmptyDishList(PagedResultBase<Dish> result)
        {
            return new PagedListDto<DishDto>(result.CurrentPage, result.PageCount, result.PageSize, result.RowCount,
                new List<DishDto>());
        }
    }
}