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
        IRequestHandler<GetMenusListQuery, List<MenuDto>>,
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

        public async Task<List<MenuDto>> Handle(GetMenusListQuery request, CancellationToken cancellationToken)
        {
            var result = await _context
                .Menus
                .Where(m => m.FoodBusinessId == request.FoodBusinessId)
                .ToListAsync(cancellationToken);

            return _mapper.Map<List<MenuDto>>(result);
        }
    }
}