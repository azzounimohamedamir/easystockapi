using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;

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
            var result = _context
                .Menus
                .Where(m => m.FoodBusinessId == request.FoodBusinessId)
                .GetPaged(request.Page, request.PageSize);
            var data = _mapper.Map<List<MenuDto>>(
                await result.Data.ToListAsync(cancellationToken).ConfigureAwait(false));
            var pagedResult = new PagedListDto<MenuDto>(result.CurrentPage, result.PageCount, result.PageSize,
                result.RowCount, data);
            return pagedResult;
        }
    }
}