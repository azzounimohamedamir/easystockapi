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

namespace SmartRestaurant.Application.FoodBusiness.Queries
{
    public class FoodBusinessQueriesHandler :
        IRequestHandler<GetFoodBusinessListQuery, PagedListDto<FoodBusinessDto>>,
        IRequestHandler<GetFoodBusinessByIdQuery, FoodBusinessDto>,
        IRequestHandler<GetFoodBusinessListByAdmin, List<FoodBusinessDto>>,
        IRequestHandler<GetUsersByFoodBusinessIdQuery, string[]>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IIdentityContext _identityContext;
        private readonly IMapper _mapper;

        public FoodBusinessQueriesHandler(IApplicationDbContext applicationDbContext, IMapper mapper,
            IIdentityContext identityContext)
        {
            _applicationDbContext = applicationDbContext;
            _identityContext = identityContext;
            _mapper = mapper;
        }


        public async Task<FoodBusinessDto> Handle(GetFoodBusinessByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.FoodBusinesses.FindAsync(request.FoodBusinessId)
                .ConfigureAwait(false);

            if (entity == null) throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);
            var foodBusinessDto = _mapper.Map<FoodBusinessDto>(entity);
            await GetFoodBusinessImagesAsync(foodBusinessDto, cancellationToken).ConfigureAwait(false);
            return foodBusinessDto;
        }

        public async Task<List<FoodBusinessDto>> Handle(GetFoodBusinessListByAdmin request,
            CancellationToken cancellationToken)
        {
            if (request.FoodBusinessAdministratorId == string.Empty ||
                string.IsNullOrWhiteSpace(request.FoodBusinessAdministratorId))
                throw new InvalidOperationException("FoodBusinessAdministratorId shouldn't be null or  empty");

            var foodBusinesses = await _applicationDbContext.FoodBusinesses
                .Where(x => x.FoodBusinessAdministratorId == request.FoodBusinessAdministratorId)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return _mapper.Map<List<FoodBusinessDto>>(foodBusinesses);
        }

        public async Task<PagedListDto<FoodBusinessDto>> Handle(GetFoodBusinessListQuery request,
            CancellationToken cancellationToken)
        {
            var result = _applicationDbContext.FoodBusinesses.GetPaged(request.Page, request.PageSize);
            var data = _mapper.Map<List<FoodBusinessDto>>(await result.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));
            foreach (var foodBusinessDto in data)
                await GetFoodBusinessImagesAsync(foodBusinessDto, cancellationToken).ConfigureAwait(false);

            var pagedResult = new PagedListDto<FoodBusinessDto>(result.CurrentPage, result.PageCount, result.PageSize,
                result.RowCount, data);
            return pagedResult;
        }

        public Task<string[]> Handle(GetUsersByFoodBusinessIdQuery request, CancellationToken cancellationToken)
        {
            return _applicationDbContext.FoodBusinessUsers.Where(x => x.FoodBusinessId == request.FoodBusinessId)
                .Select(x => x.ApplicationUserId).ToArrayAsync(cancellationToken);
        }

        private async Task GetFoodBusinessImagesAsync(FoodBusinessDto foodBusinessDto,
            CancellationToken cancellationToken)
        {
            var images = await _applicationDbContext.FoodBusinessImages
                .Where(x => x.EntityId == foodBusinessDto.FoodBusinessId)
                .Select(x => x.ImageBytes).ToListAsync(cancellationToken).ConfigureAwait(false);

            if (images.Any())
                foodBusinessDto.Images.AddRange(images.Select(Convert.ToBase64String));
        }
    }
}