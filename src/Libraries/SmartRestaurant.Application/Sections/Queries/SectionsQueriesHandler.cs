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

namespace SmartRestaurant.Application.Sections.Queries
{
    public class SectionsQueriesHandler :
        IRequestHandler<GetSectionsListQuery, PagedListDto<SectionDto>>,
        IRequestHandler<GetAllSectionsListQuery, List<SectionDto>>,

        IRequestHandler<GetSectionByIdQuery, SectionDto>,
        IRequestHandler<GetSectionMenuItemsQuery, PagedListDto<MenuItemDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SectionsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedListDto<SectionDto>> Handle(GetSectionsListQuery request,
            CancellationToken cancellationToken)
        {
            var query = _context.Sections.Where(s => s.MenuId == request.MenuId).OrderBy(s=>s.Order)
                .GetPaged(request.Page, request.PageSize);
            var data = _mapper.Map<List<SectionDto>>(await query.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));
            var pagedResult = new PagedListDto<SectionDto>(query.CurrentPage, query.PageCount, query.PageSize,
                query.RowCount, data);
            return pagedResult;
        }

        public async Task<List<SectionDto>> Handle(GetAllSectionsListQuery request,
            CancellationToken cancellationToken)
        {
            var list = from m in _context.Menus 
                       join s in _context.Sections on m.MenuId equals s.MenuId
                        where m.FoodBusinessId.ToString() == request.FoodBusinessId
                        select s;

                
            var data = _mapper.Map<List<SectionDto>>(await list.ToListAsync(cancellationToken)
                .ConfigureAwait(false));
          
            return data;
        }
        public async Task<SectionDto> Handle(GetSectionByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetSectionByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var section = await _context.Sections.FindAsync(Guid.Parse(request.Id)).ConfigureAwait(false);
            if(section == null)
                throw new NotFoundException(nameof(Section), request.Id);

            return _mapper.Map<SectionDto>(section);
        }

        public async Task<PagedListDto<MenuItemDto>> Handle(GetSectionMenuItemsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetSectionMenuItemsQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var section = await _context.Sections.FindAsync(Guid.Parse(request.SectionId)).ConfigureAwait(false);
            if (section == null)
                throw new NotFoundException(nameof(Section), request.SectionId);

            var query = await _context.Sections
              .Include(x => x.Products)
              .Include(x => x.Dishes)
              .Where(x => x.SectionId == Guid.Parse(request.SectionId))
              .Select(x => new
              {
                  ProductsId = x.Products.Select(x => x.ProductId).ToList(),
                  DishesId = x.Dishes.Select(x => x.DishId).ToList()
              })
              .FirstOrDefaultAsync()
              .ConfigureAwait(false);

            var searchKey = string.IsNullOrWhiteSpace(request.SearchKey) ? "" : request.SearchKey;

            var products = _context.Products.Where(product => query.ProductsId.Contains(product.ProductId) && product.Name.Contains(searchKey))
                    .OrderBy(product => product.Name)
                    .GetPaged(request.Page, request.PageSize);

            var dishes = _context.Dishes.Where(dish => query.DishesId.Contains(dish.DishId) && dish.Name.Contains(searchKey))
                    .OrderBy(dish => dish.Name)
                    .GetPaged(request.Page, request.PageSize);

            var menuItemsDto = new List<MenuItemDto>();
            menuItemsDto.AddRange(_mapper.Map<List<MenuItemDto>>(await products.Data.ToListAsync(cancellationToken).ConfigureAwait(false)));
            menuItemsDto.AddRange(_mapper.Map<List<MenuItemDto>>(await dishes.Data.ToListAsync(cancellationToken).ConfigureAwait(false)));

            return new PagedListDto<MenuItemDto>(request.Page, products.PageCount + dishes.PageCount, request.PageSize, menuItemsDto.Count, menuItemsDto);
        }
    }
}