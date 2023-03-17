using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Application.CurrencyExchange;
using SmartRestaurant.Application.Dishes.Queries;
using SmartRestaurant.Application.Dishes.Queries.FilterStrategy;
using SmartRestaurant.Application.Products.Commands;
using SmartRestaurant.Application.Products.Queries;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Dishes.Commands
{
    public class DishesCommandsHandler : 
        IRequestHandler<CreateDishCommand, Created>,
        IRequestHandler<UpdateDishCommand, NoContent>,
        IRequestHandler<DeleteDishCommand, NoContent>,
        IRequestHandler<SynchronizeOdooDishesCommand, PagedListDto<DishDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IOdooRepository _saleOrderRepository;

        public DishesCommandsHandler(IApplicationDbContext context, IMapper mapper, IUserService userService, IOdooRepository saleOrderRepository)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _saleOrderRepository = saleOrderRepository;
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
            var odooId = await CreateOdooDish(dish, foodBusiness);
            dish.OdooId= odooId;
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
            //var foodBusiness = await _context.FoodBusinesses.AsNoTracking()
            //      .FirstOrDefaultAsync(r => r.FoodBusinessId == dish.FoodBusinessId, cancellationToken).ConfigureAwait(false);
            //if (foodBusiness == null)
            //    throw new NotFoundException(nameof(FoodBusiness), dish.FoodBusinessId);
            //await DeleteOdooDish(foodBusiness, dish.OdooId);
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
                  .ThenInclude(x=>x.ComboBoxContentTranslation)
                  .Where(u => u.DishId == Guid.Parse(request.Id))
                  .FirstOrDefaultAsync()
                  .ConfigureAwait(false);
            if (dish == null)
                throw new NotFoundException(nameof(Dishes), request.Id);

            _mapper.Map(request, dish);
            dish.EnergeticValue = await CalculateEnergeticValue(request.Ingredients).ConfigureAwait(false);
            dish.LastModifiedBy = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            dish.LastModifiedAt = DateTime.Now;
            var foodBusiness = await _context.FoodBusinesses.FindAsync(dish.FoodBusinessId);
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), dish.FoodBusinessId);
            _context.Dishes.Update(dish);
            var odooId = await UpdateOdooDish(dish, foodBusiness, dish.OdooId);
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

        private async Task<long> CreateOdooDish(Dish dish, SmartRestaurant.Domain.Entities.FoodBusiness foodBusiness)
        {
            var odooId = (long)0;
            if (foodBusiness.Odoo != null)
            {
                var loggedIn = await _saleOrderRepository.Authenticate(foodBusiness.Odoo);
                if (loggedIn)
                {

                    long categoryId = await getDishCategoryId();
                    var data = new Dictionary<string, object>
                    {
                        { "name", dish.Name},
                        { "detailed_type", dish.IsQuantityChecked ? "product" : "consu"},
                        { "list_price", dish.Price},
                        { "pos_categ_id", categoryId},
                        { "available_in_pos", 1},
                        { "image_1920",dish.Picture },
                        { "taxes_id",null }
                    };


                    odooId = await _saleOrderRepository.CreateAsync("product.template", data);
                }
            }
            return odooId;
        }


        private async Task<long> UpdateOdooDish(Dish dish, SmartRestaurant.Domain.Entities.FoodBusiness foodBusiness, long odooId)
        {
            if (foodBusiness.Odoo != null)
            {
                var loggedIn=await _saleOrderRepository.Authenticate(foodBusiness.Odoo);
                if (loggedIn)
                {
                    long categoryId = await getDishCategoryId();


                    var data = new Dictionary<string, object>
                    {
                        { "name", dish.Name},
                        { "detailed_type", dish.IsQuantityChecked ? "product" : "consu"},
                        { "list_price", dish.Price},
                        { "pos_categ_id", categoryId},
                        { "available_in_pos", 1},
                        { "image_1920",dish.Picture },
                        { "taxes_id",null }
                    };

                    return await _saleOrderRepository.UpdateAsync("product.template", odooId, data);
                }
                
            }

            return (long)0;
        }

       

        private async Task<long> getDishCategoryId()
        {
            var result = await _saleOrderRepository.Search<List<int>>("pos.category", "name", "dish", 1);
            long categoryId=0;
            if (result!=null && result.Count > 0)
            {
                categoryId = result[0];
            }
            else
            {
                var categoryData = new Dictionary<string, object>
                {
                    { "name", "dish"}
                };
                categoryId = await _saleOrderRepository.CreateAsync("pos.category", categoryData);
            }

            return categoryId;
        }

        public async Task<PagedListDto<DishDto>> Handle(SynchronizeOdooDishesCommand request, CancellationToken cancellationToken)
        {
            var validator = new SynchronizeOdooDishesCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.AsNoTracking()
                    .FirstOrDefaultAsync(r => r.FoodBusinessId == Guid.Parse(request.FoodBusinessId), cancellationToken).ConfigureAwait(false);
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            if (foodBusiness.Odoo != null)
            {
                var loggedIn = await _saleOrderRepository.Authenticate(foodBusiness.Odoo);
                if (loggedIn)
                {
                    var dishes = _context.Dishes.Where(r => r.FoodBusinessId == Guid.Parse(request.FoodBusinessId));

                    foreach (var dish in dishes)
                    {
                        if (dish.SyncFromOdoo)
                        {
                            if (dish.OdooId != 0)
                            {
                                var p = await _saleOrderRepository.Read<List<Dictionary<string, object>>>("product.template", dish.OdooId);
                                dish.Name = p[0]["name"].ToString();
                                dish.Price = float.Parse(p[0]["list_price"].ToString());
                                dish.IsQuantityChecked = p[0]["detailed_type"].ToString() == "product" ? true : false;
                                dish.Picture = Convert.FromBase64String(p[0]["image_512"].ToString());
                                _context.Dishes.Update(dish);
                            }
                            else
                            {
                                var dishOdooIds = await _saleOrderRepository.Search<List<int>>("product.template", "name", dish.Name, 1);
                                long dishOdooId;
                                if (dishOdooIds.Count > 0)
                                {
                                    dishOdooId = dishOdooIds[0];
                                    var p = await _saleOrderRepository.Read<List<Dictionary<string, object>>>("product.template", dishOdooId);
                                    dish.Name = p[0]["name"].ToString();
                                    dish.Price = float.Parse(p[0]["list_price"].ToString());
                                    dish.IsQuantityChecked = p[0]["detailed_type"].ToString() == "product" ? true : false;
                                    dish.Picture = Convert.FromBase64String(p[0]["image_512"].ToString());
                                    _context.Dishes.Update(dish);
                                }

                            }
                        }
                        else
                        {
                            if (dish.OdooId != 0)
                            {
                                await UpdateOdooDish(dish, foodBusiness, dish.OdooId);
                            }
                            else
                            {
                                var dishOdooIds = await _saleOrderRepository.Search<List<int>>("product.template", "name", dish.Name, 1);
                                long dishOdooId;
                                if (dishOdooIds != null && dishOdooIds.Count > 0)
                                {
                                    dishOdooId = dishOdooIds[0];
                                    await UpdateOdooDish(dish, foodBusiness, dishOdooId);
                                }
                                else
                                {
                                    dishOdooId = await CreateOdooDish(dish, foodBusiness);
                                }
                                dish.OdooId = dishOdooId;
                                _context.Dishes.Update(dish);
                            }
                        }
                    }
                }
                else
                {
                    throw new ConflictException("Sorry,Could not synchronize with Odoo, verify your food business Odoo login informations.");
                }
            }
            else
            {
                throw new ConflictException("Sorry, Could not synchronize with Odoo, verify your food business Odoo login informations.");
            }



            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);


            var filter = DishStrategies.GetFilterStrategy(request.CurrentFilter);
            var newQuery = _mapper.Map<GetDishesListQuery>(request);
            var query = filter.FetchData(_context.Dishes, newQuery);

            var data = _mapper.Map<List<DishDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            foreach (var dish in data)
            {
                dish.CurrencyExchange = CurrencyConverter.GetDefaultCurrencyExchangeList(dish.Price, foodBusiness.DefaultCurrency);
            }
            return new PagedListDto<DishDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);

        }
    }
}