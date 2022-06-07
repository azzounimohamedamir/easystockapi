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

namespace SmartRestaurant.Application.SubSections.Queries
{
    public class SubSectionsQueriesHandler :
        IRequestHandler<GetSubSectionsListQuery, PagedListDto<SubSectionDto>>,
        IRequestHandler<GetSubSectionByIdQuery, SubSectionDto>,
        IRequestHandler<GetSubSectionMenuItemsQuery, PagedListDto<MenuItemDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SubSectionsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedListDto<SubSectionDto>> Handle(GetSubSectionsListQuery request,
            CancellationToken cancellationToken)
        {
            var query = _context.SubSections.Where(s => s.SectionId == request.SectionId).OrderBy(s => s.Order)
                .GetPaged(request.Page, request.PageSize);
            var data = _mapper.Map<List<SubSectionDto>>(await query.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));
            var pagedResult = new PagedListDto<SubSectionDto>(query.CurrentPage, query.PageCount, query.PageSize,
                query.RowCount, data);
            return pagedResult;
        }

        public async Task<SubSectionDto> Handle(GetSubSectionByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetSubSectionByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var subSections = await _context.SubSections.FindAsync(Guid.Parse(request.Id)).ConfigureAwait(false);
            if (subSections == null)
                throw new NotFoundException(nameof(SubSection), request.Id);

            return _mapper.Map<SubSectionDto>(subSections);
        }

        public async Task<PagedListDto<MenuItemDto>> Handle(GetSubSectionMenuItemsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetSubSectionMenuItemsQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var subSection = await _context.SubSections.FindAsync(Guid.Parse(request.SubSectionId)).ConfigureAwait(false);
            if (subSection == null)
                throw new NotFoundException(nameof(SubSection), request.SubSectionId);

            var query = await _context.SubSections
              .Include(x => x.Products)
              .Include(x => x.Dishes)
              .Where(x => x.SubSectionId == Guid.Parse(request.SubSectionId))
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

            return new PagedListDto<MenuItemDto>(request.Page, products.PageCount + dishes.PageCount, request.PageSize, products.RowCount + dishes.RowCount, menuItemsDto);
        }
    }
}