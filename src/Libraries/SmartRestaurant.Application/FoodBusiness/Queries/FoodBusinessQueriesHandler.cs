using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SmartRestaurant.Application.Common.Extensions;

namespace SmartRestaurant.Application.FoodBusiness.Queries
{
    public class FoodBusinessQueriesHandler :
        IRequestHandler<GetFoodBusinessListQuery, PagedListDto<FoodBusinessDto>>,
        IRequestHandler<GetFoodBusinessByIdQuery, FoodBusinessDto>,
        IRequestHandler<GetFoodBusinessListByAdmin, List<FoodBusinessDto>>,
        IRequestHandler<GetUsersByFoodBusinessIdQuery, string []>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FoodBusinessQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedListDto<FoodBusinessDto>> Handle(GetFoodBusinessListQuery request, CancellationToken cancellationToken)
        {
            var  result =  _context.FoodBusinesses.GetPaged(request.Page, request.PageSize);
            var data = _mapper.Map<List<FoodBusinessDto>>(await result.Data.ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false));
            foreach (var foodBusinessDto in data)
            {
                var images =await _context.FoodBusinessImages.Where(x => x.EntityId == foodBusinessDto.FoodBusinessId).Select(x=>x.ImageBytes).ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                
                if(images.Any())
                    foodBusinessDto.Images.AddRange(images.Select(Convert.ToBase64String));
            }
            var pagedResult = new PagedListDto<FoodBusinessDto>(result.CurrentPage, result.PageCount, result.PageSize, result.RowCount, data);
            return pagedResult;
        }

        public async Task<FoodBusinessDto> Handle(GetFoodBusinessByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.FoodBusinesses.FindAsync(request.FoodBusinessId).ConfigureAwait(false);

            if (entity == null)
            {
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);
            }
            return _mapper.Map<FoodBusinessDto>(entity);
        }

        public async Task<List<FoodBusinessDto>> Handle(GetFoodBusinessListByAdmin request, CancellationToken cancellationToken)
        {
            if (request.FoodBusinessAdministratorId == String.Empty || string.IsNullOrWhiteSpace(request.FoodBusinessAdministratorId))
                throw new InvalidOperationException("FoodBusinessAdministratorId shouldn't be null or  empty");

            List<Domain.Entities.FoodBusiness> foodBusinesses = await _context.FoodBusinesses
                .Where(x => x.FoodBusinessAdministratorId == request.FoodBusinessAdministratorId).ToListAsync(cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return _mapper.Map<List<FoodBusinessDto>>(foodBusinesses);
        }


        public Task<string[]> Handle(GetUsersByFoodBusinessIdQuery request, CancellationToken cancellationToken)
        {
            return _context.FoodBusinessUsers.Where(x => x.FoodBusinessId == request.FoodBusinessId)
                .Select(x => x.ApplicationUserId).ToArrayAsync(cancellationToken: cancellationToken);
        }
    }
}
