using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.il.Queries.FilterStrategy;
using SmartRestaurant.Application.Illness.Queries.FilterStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Illness.Queries
{
    public class IllnessesQueriesHandler :
        IRequestHandler<GetIllnessesListQuery, PagedListDto<IllnessDto>>,
        IRequestHandler<GetIllnessByIdQuery, IllnessDto>,
        IRequestHandler<GetIlnessessbyUserQuery, PagedListDto<IllnessUserDto>>,

        IRequestHandler<GetDishesIllnessQuery, IList<DishIllnessDto>>,
        IRequestHandler<GetWarningIngredientOfOrderWithIllnessQuery, WarningIngredientOfOrder>,
        IRequestHandler<GetWarningIngredientOfOrderWithIllnessWebQuery, WarningIngredientOfOrder>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public IllnessesQueriesHandler(IApplicationDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<PagedListDto<IllnessDto>> Handle(GetIllnessesListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetIllnessesListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = IllnessStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Illnesses, request);

            var data = _mapper.Map<List<IllnessDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<IllnessDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

        public async Task<IllnessDto> Handle(GetIllnessByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetIllnessByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var Illness = await _context.Illnesses
               .Include(x => x.IngredientIllnesses)
               .ThenInclude(x => x.Ingredient)
               .Where(u => u.IllnessId == Guid.Parse(request.Id))
               .FirstOrDefaultAsync()
               .ConfigureAwait(false);
            if (Illness == null)
                throw new NotFoundException(nameof(Illness), request.Id);
            var IllnessDto = _mapper.Map<IllnessDto>(Illness);
            return IllnessDto;
        }



        public async Task<PagedListDto<IllnessUserDto>> Handle(GetIlnessessbyUserQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetIlnessessbyUserQueryValidator();

            var userconnected = _userService.GetUserId();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = IllnessUserStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.ilnessUsers, request);

            var data = _mapper.Map<List<IllnessUserDto>>(await query.Data.Where(a=>a.ApplicationUserId==userconnected).ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<IllnessUserDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
             
        }

        public async Task<IList<DishIllnessDto>> Handle(GetDishesIllnessQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetDishesIllnessQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var deshes = _context.Dishes.AsNoTracking().Where(x => request.disheIds.Contains(x.DishId.ToString()))
                .Include(xx => xx.Ingredients).ThenInclude(xx => xx.Ingredient).
                ThenInclude(xx=>xx.IngredientIllnesses).ThenInclude(x=>x.Illness).ToList();
            if (deshes == null)
                return new List<DishIllnessDto>();
            return deshes.Where(x => x.Ingredients != null && x.Ingredients.Count != 0)
            .Select(desh=> 
            {
                return new DishIllnessDto()
                {
                    IdDishe = desh.DishId.ToString(),
                    IllnessIngredients = desh.Ingredients.Select(ingredient => 
                    {
                        return new IllnessIngredientCorrespondingDto() {

                            IngredientId = ingredient.Ingredient.IngredientId.ToString(),
                            Illness = ingredient.Ingredient.IngredientIllnesses.
                            Where(x=> request.illnesIds.Contains(x.IllnessId.ToString())).
                            Select(xx => new IllnessDto() { IllnessId = xx.IllnessId, Name = xx.Illness.Name }).ToList()
                        };
                    }).ToList() 
                };
            }).ToList();
        }
        public class ElementToProcessWarning
        {
            public string IdIngredient { get; set; }
            public string IdDishe { get; set; }
            public float Quantity { get; set; }
            public bool InSupplement { get; set; }
        }
        public async Task<WarningIngredientOfOrder> Handle(GetWarningIngredientOfOrderWithIllnessQuery request, CancellationToken cancellationToken)
        {
            var summaryIngredientIlnessess = GetSummaryIngredientsList(request.SummaryIllness, request.SummaryIngredients);

            return summaryIngredientIlnessess;
        }

        public WarningIngredientOfOrder GetSummaryIngredientsList(List<string> summaryIlnessess, List<SummaryQteIngredientOfDishDto> summaryIngredients)
        {
            var losteElementToProcesse =summaryIngredients.SelectMany(
           summaryItem =>
                   summaryItem.IngredientDishes.
                   Select(x => new ElementToProcessWarning()
                   {
                       IdDishe = summaryItem.IdDish,
                       IdIngredient = x.IdIngredient,
                       Quantity = x.Quantity * summaryItem.QteDish,
                       InSupplement = false,
                   }).Union(
                       summaryItem.IdSupplement.SelectMany(
                           supp =>
                           {
                               return
                               _context.Dishes.AsNoTracking()
                               .Include(xx => xx.Ingredients).ThenInclude(xx => xx.Ingredient).
                               FirstOrDefault(x => x.DishId == Guid.Parse(supp)).Ingredients.
                               Select(x => new ElementToProcessWarning()
                               {
                                   IdDishe = summaryItem.IdDish,
                                   IdIngredient = x.IngredientId.ToString(),
                                   Quantity = x.InitialAmount * summaryItem.QteDish,
                                   InSupplement = true,
                               }).ToList();
                           }
                       ))
                   ).ToList();
            WarningIngredientOfOrder result = new WarningIngredientOfOrder();
            result.SummaryIngredientIllness = losteElementToProcesse
            .GroupBy(x => x.IdIngredient).Select(x =>
            {
                var SumQte = x.Sum(y => y.Quantity);
                var warning = new WarningIngredientOfOrderWithIllness()
                {
                    IngredientId = x.Key,
                    Ingredient = _mapper.Map<IngredientDto>(_context.Ingredients.AsNoTracking().FirstOrDefault(ing => ing.IngredientId.ToString().Equals(x.Key))),
                    Dishes = x.Select(t => new DisheInSupplement()
                    {
                        IdDish = t.IdDishe,
                        Dish = _mapper.Map<DishDto>(_context.Dishes.AsNoTracking().FirstOrDefault(ing => ing.DishId.ToString().Equals(t.IdDishe))),
                        InSuplement = t.InSupplement
                    }).ToList(),
                    Quantity = SumQte,
                    Illness = _mapper.Map<List<CriticalQteIllnessIngredientDto>>(
                    _context.IngredientIllnesses.AsNoTracking().
                    Include(x => x.Illness).
                    Where(
                        y =>
                        y.IngredientId.ToString().Equals(x.Key) &&
                        summaryIlnessess.Contains(y.IllnessId.ToString()) &&
                        y.Quantity <= SumQte
                    )
                    .ToList())
                };
                return warning;
            }

            ).ToList();

            result.SummaryIngredientIllness.RemoveAll(s => s.Illness == null || s.Illness.Count == 0);
            return result;

        }



        public async Task<WarningIngredientOfOrder> Handle(GetWarningIngredientOfOrderWithIllnessWebQuery request, CancellationToken cancellationToken)
        {
            var userconnected = _userService.GetUserId();
            List<string> summaryIlnesses = new List<string>();
           var IlnessOfCurrentUser =   _context.ilnessUsers.Where(a=>a.ApplicationUserId==userconnected).ToList();
            IlnessOfCurrentUser.ForEach(ilnessuser =>
            {
                summaryIlnesses.Add(ilnessuser.IllnessId.ToString());
            }
            );
           var  summaryIngredientIlnessess=GetSummaryIngredientsList(summaryIlnesses,request.SummaryIngredients);
           return summaryIngredientIlnessess;
        }
    }
}
