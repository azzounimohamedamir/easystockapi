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
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.FoodBusiness.Queries
{
    public class FoodBusinessQueriesHandler :
        IRequestHandler<GetFoodBusinessListQuery, PagedListDto<FoodBusinessDto>>,
        IRequestHandler<GetFoodBusinessByIdQuery, FoodBusinessDto>,
        IRequestHandler<GetFoodBusinessListByAdmin, List<FoodBusinessDto>>,
        IRequestHandler<GetUsersByFoodBusinessIdQuery, string[]>,
        IRequestHandler<GetAllFoodBusinessByFoodBusinessManagerQuery, List<FoodBusinessDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IIdentityContext _identityContext;

        public FoodBusinessQueriesHandler(IApplicationDbContext applicationDbContext, IMapper mapper,
            IUserService userService, IIdentityContext identityContext)
        {
            _applicationDbContext = applicationDbContext;
            _userService = userService;
            _mapper = mapper;
            _identityContext = identityContext;
        }

        public async Task<List<FoodBusinessDto>> Handle(GetAllFoodBusinessByFoodBusinessManagerQuery request,
            CancellationToken cancellationToken)
        {
            var foodBusinessManagerUserId = _userService.GetUserId();

            if (foodBusinessManagerUserId == string.Empty || string.IsNullOrWhiteSpace(foodBusinessManagerUserId))
                throw new InvalidOperationException("FoodBusinessManager UserId shouldn't be null or  empty");


            var listOfFoodBusinessIds = _applicationDbContext.FoodBusinessUsers
                .Where(foodBusinessUser => foodBusinessUser.ApplicationUserId == foodBusinessManagerUserId)
                .Select(foodBusinessUser => foodBusinessUser.FoodBusinessId)
                .Distinct()
                .ToList();

            var foodBusinesses = await _applicationDbContext.FoodBusinesses
                .Where(foodBusiness => listOfFoodBusinessIds.Contains(foodBusiness.FoodBusinessId))
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return _mapper.Map<List<FoodBusinessDto>>(foodBusinesses);
        }


        public async Task<FoodBusinessDto> Handle(GetFoodBusinessByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.FoodBusinesses.FindAsync(request.FoodBusinessId)
                .ConfigureAwait(false);

            if (entity == null) throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);
            var foodBusinessDto = _mapper.Map<FoodBusinessDto>(entity);
            await GetFoodBusinessImagesAsync(foodBusinessDto, cancellationToken).ConfigureAwait(false);
            await GetCountOfZonesTablesAndMenus(foodBusinessDto, cancellationToken).ConfigureAwait(false);
            return foodBusinessDto;
        }

        public async Task<List<FoodBusinessDto>> Handle(GetFoodBusinessListByAdmin request,
            CancellationToken cancellationToken)
        {
            string foodBusinessAdministratorId = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            await ChecksHelper.CheckUserExistence_ThrowExceptionIfUserNotFound(_identityContext, foodBusinessAdministratorId).ConfigureAwait(false);

            var foodBusinesses = await _applicationDbContext.FoodBusinesses
                .Where(x => x.FoodBusinessAdministratorId == foodBusinessAdministratorId)
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
            /*
            var images = await _applicationDbContext.FoodBusinessImages
                .Where(x => x.EntityId == foodBusinessDto.FoodBusinessId)
                .Select(x => x.ImageBytes).ToListAsync(cancellationToken);

            if (images.Any())
                foodBusinessDto.Images.AddRange(images.Select(Convert.ToBase64String));
                */
        }

        private async Task GetCountOfZonesTablesAndMenus(FoodBusinessDto foodBusinessDto,
            CancellationToken cancellationToken)
        {
            var zonesIds = await _applicationDbContext.Zones
                .Where(zone => zone.FoodBusinessId == foodBusinessDto.FoodBusinessId)
                .Select(zone => zone.ZoneId)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            var tablesCount = await _applicationDbContext.Tables
                .Where(table => zonesIds.Contains(table.ZoneId))
                .Select(table => table.TableNumber)
                .SumAsync(cancellationToken)
                .ConfigureAwait(false);

            var menusCount = await _applicationDbContext.Menus
                .Where(menu => menu.FoodBusinessId == foodBusinessDto.FoodBusinessId)
                .CountAsync(cancellationToken)
                .ConfigureAwait(false);

            foodBusinessDto.zonesCount = zonesIds.Count;
            foodBusinessDto.tablesCount = tablesCount;
            foodBusinessDto.menusCount = menusCount;
        }
    }
}