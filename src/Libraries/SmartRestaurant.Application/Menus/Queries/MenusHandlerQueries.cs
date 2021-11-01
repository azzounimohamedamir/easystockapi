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
using SmartRestaurant.Application.Menus.Queries.FilterStrategy;

namespace SmartRestaurant.Application.Menus.Queries
{
    public class MenusHandlerQueries :
        IRequestHandler<GetMenusListQuery, PagedListDto<MenuDto>>,
        IRequestHandler<GetMenuByIdQuery, MenuDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MenusHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MenuDto> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _context.Menus.FindAsync(request.MenuId).ConfigureAwait(false);
            return _mapper.Map<MenuDto>(query);
        }

        public async Task<PagedListDto<MenuDto>> Handle(GetMenusListQuery request, CancellationToken cancellationToken)
        {
            //var result = _context
            //    .Menus
            //    .Where(m => m.FoodBusinessId == request.FoodBusinessId)
            //    .GetPaged(request.Page, request.PageSize);
            //var data = _mapper.Map<List<MenuDto>>(
            //    await result.Data.ToListAsync(cancellationToken).ConfigureAwait(false));
            //var pagedResult = new PagedListDto<MenuDto>(result.CurrentPage, result.PageCount, result.PageSize,
            //    result.RowCount, data);
            //return pagedResult;

            var validator = new GetMenusListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            var filter = MenuStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Menus, request);

            var data = _mapper.Map<List<MenuDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<MenuDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);

        }
    }
}