using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.FoodBusiness.Queries.FilterStrategy;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;

namespace SmartRestaurant.Application.FoodBusiness.Queries
{
    public class FoodBusinessQueriesHandler :
        IRequestHandler<GetFoodBusinessListQuery, PagedListDto<FoodBusinessDto>>,
        IRequestHandler<GetFoodBusinessByIdQuery, FoodBusinessDto>,
        IRequestHandler<GetFourDigitCodeFoodBusinessByIdQuery, FoodBusinessDto>,
        IRequestHandler<GetFoodBusinessListByAdmin, List<FoodBusinessDto>>,
        IRequestHandler<GetUsersByFoodBusinessIdQuery, string[]>,
        IRequestHandler<GetAllFoodBusinessAccpetsImportationQuery, PagedListDto<FoodBusinessDto>>,
        IRequestHandler<GetAllFoodBusinessByFoodBusinessManagerQuery, List<FoodBusinessDto>>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly IIdentityContext _identityContext;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public FoodBusinessQueriesHandler(IApplicationDbContext applicationDbContext, IMapper mapper,
            IUserService userService, IIdentityContext identityContext,UserManager<ApplicationUser> userManager)
        {
            _applicationDbContext = applicationDbContext;
            _userService = userService;
            _mapper = mapper;
            _identityContext = identityContext;
            _userManager = userManager;
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

            var result = await PopulatDtoWithFoodBuisenessLogos(foodBusinesses, cancellationToken).ConfigureAwait(false);
            return result;

        }
        public async Task<PagedListDto<FoodBusinessDto>> Handle(GetAllFoodBusinessAccpetsImportationQuery request,
            CancellationToken cancellationToken)
        {

            var validator = new GetAllFoodBusinessAccpetsImportationQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = FoodBusinessStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchDataFbAcceptDelivery(_applicationDbContext.FoodBusinesses, request);

            var data = _mapper.Map<List<FoodBusinessDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<FoodBusinessDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

        private async Task<List<FoodBusinessDto>> PopulatDtoWithFoodBuisenessLogos(List<Domain.Entities.FoodBusiness> foodBusinesses, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<List<FoodBusinessDto>>(foodBusinesses);
            foreach (var foodBusinesse in result)
            {
                var images = await _applicationDbContext.FoodBusinessImages.
                    Where(f => f.EntityId == foodBusinesse.FoodBusinessId && f.IsLogo)
                 .Select(im => im.ImageBytes).ToArrayAsync(cancellationToken).ConfigureAwait(false);
                if (images != null)
                {
                    foodBusinesse.Logo = images.Select(Convert.ToBase64String).FirstOrDefault();
                }
            }
            return result;
        }

        public async Task<FoodBusinessDto> Handle(GetFoodBusinessByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.FoodBusinesses.Where(u => u.FoodBusinessId == request.FoodBusinessId)
                 .FirstOrDefaultAsync().ConfigureAwait(false);

            
            if (entity == null) throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);
            var foodBusinessDto = _mapper.Map<FoodBusinessDto>(entity);
            foodBusinessDto.CurrentUserRating = await getCurrentUserRating(request.FoodBusinessId);
            await GetFoodBusinessImagesAsync(foodBusinessDto, cancellationToken).ConfigureAwait(false);
            await GetCountOfZonesTablesAndMenus(foodBusinessDto, cancellationToken).ConfigureAwait(false);
            return foodBusinessDto;
        }

        public async Task<List<FoodBusinessDto>> Handle(GetFoodBusinessListByAdmin request,
            CancellationToken cancellationToken)
        {
            var foodBusinessAdministratorId =
                ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            await ChecksHelper
                .CheckUserExistence_ThrowExceptionIfUserNotFound(_identityContext, foodBusinessAdministratorId)
                .ConfigureAwait(false);

            var foodBusinesses = await _applicationDbContext.FoodBusinesses
                .Where(x => x.FoodBusinessAdministratorId == foodBusinessAdministratorId)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return _mapper.Map<List<FoodBusinessDto>>(foodBusinesses);
        }

        public async Task<PagedListDto<FoodBusinessDto>> Handle(GetFoodBusinessListQuery request,
            CancellationToken cancellationToken)
        {
            var validator = new GetFoodBusinessListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = FoodBusinessStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_applicationDbContext.FoodBusinesses, request);

            var data = _mapper.Map<List<FoodBusinessDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<FoodBusinessDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

        async Task<FoodBusinessDto> IRequestHandler<GetFourDigitCodeFoodBusinessByIdQuery, FoodBusinessDto>.Handle(
            GetFourDigitCodeFoodBusinessByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _applicationDbContext.FoodBusinesses.FindAsync(request.FoodBusinessId)
                .ConfigureAwait(false);
            return _mapper.Map<FoodBusinessDto>(query);
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
                .Select(x => x.ImageBytes).ToListAsync(cancellationToken);

            if (images.Any())
                foodBusinessDto.Images.AddRange(images.Select(Convert.ToBase64String));              
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
                .CountAsync(cancellationToken)
                .ConfigureAwait(false);

            var menusCount = await _applicationDbContext.Menus
                .Where(menu => menu.FoodBusinessId == foodBusinessDto.FoodBusinessId)
                .CountAsync(cancellationToken)
                .ConfigureAwait(false);

            foodBusinessDto.zonesCount = zonesIds.Count;
            foodBusinessDto.tablesCount = tablesCount;
            foodBusinessDto.menusCount = menusCount;
        }


        public async Task<int> getCurrentUserRating(Guid FoodBusinessId)
        {
            var user_id = _userService.GetUserId();

            var user = await _userManager.FindByIdAsync(user_id);
            if (user == null)
                throw new NotFoundException(nameof(user), user_id);


            var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            if (roles.Contains(Roles.Diner.ToString()))
            {
                var ratingObject =await  _applicationDbContext.FoodBusinessUserRatings.Where(ratings => ratings.FoodBusinessId == FoodBusinessId && ratings.ApplicationUserId == Guid.Parse(user_id)).FirstOrDefaultAsync();
                if (ratingObject==null)
                {
                    return 0;
                }
                return ratingObject.Rating;
            }
            else
            {
                return 0;
            }
                
        }
    }
}