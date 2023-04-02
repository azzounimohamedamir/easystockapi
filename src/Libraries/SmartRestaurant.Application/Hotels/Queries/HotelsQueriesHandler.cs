using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Hotels.Queries.FilterStrategy;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;

namespace SmartRestaurant.Application.Hotels.Queries
{
    public class HotelsQueriesHandler :
        IRequestHandler<GetHotelsListQuery, PagedListDto<HotelDto>>,
        IRequestHandler<GetHotelsListByAdmin, List<HotelDto>>,
        IRequestHandler<GetAllHotelsByFoodBusinessManagerQuery, List<HotelDto>>,
        IRequestHandler<GetAllHotelsByHotelReceptionistQuery, List<HotelDto>>,

         IRequestHandler<GetHotelByIdQuery, HotelDto>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IIdentityContext _identityContext;
        private readonly IApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;



        public HotelsQueriesHandler(IIdentityContext identityContext, IApplicationDbContext context, IMapper mapper,IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userService = userService;
            _identityContext = identityContext;
            _applicationDbContext=context;
            _userManager = userManager;
        }

        public async Task<List<HotelDto>> Handle(GetHotelsListByAdmin request,
             CancellationToken cancellationToken)
        {
            var foodBusinessAdministratorId =
                ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            await ChecksHelper
                .CheckUserExistence_ThrowExceptionIfUserNotFound(_identityContext, foodBusinessAdministratorId)
                .ConfigureAwait(false);

            var hotels = await _applicationDbContext.Hotels.Include(o => o.DetailsSections)
                .Where(x => x.FoodBusinessAdministratorId == foodBusinessAdministratorId)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return _mapper.Map<List<HotelDto>>(hotels);
        }

        public async Task<List<HotelDto>> Handle(GetAllHotelsByFoodBusinessManagerQuery request,
           CancellationToken cancellationToken)
        {
            var foodBusinessManagerUserId = _userService.GetUserId();

            if (foodBusinessManagerUserId == string.Empty || string.IsNullOrWhiteSpace(foodBusinessManagerUserId))
                throw new InvalidOperationException("FoodBusinessManager UserId shouldn't be null or  empty");


            var listOfHotelsIds = _applicationDbContext.hotelUsers
                
                .Where(hotelUser => hotelUser.ApplicationUserId == foodBusinessManagerUserId)
                .Select(hotelUser => hotelUser.HotelId)
                .Distinct()
                .ToList();

            var hotels = await _applicationDbContext.Hotels
                .Include(o => o.DetailsSections)
                .Where(hotel => listOfHotelsIds.Contains(hotel.Id))
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            var result = _mapper.Map<List<HotelDto>>(hotels);

            return result;

        }


        public async Task<List<HotelDto>> Handle(GetAllHotelsByHotelReceptionistQuery request,
          CancellationToken cancellationToken)
        {
            var hotelReceptionistId = _userService.GetUserId();

            if (hotelReceptionistId == string.Empty || string.IsNullOrWhiteSpace(hotelReceptionistId))
                throw new InvalidOperationException("HotelReceptionist UserId shouldn't be null or  empty");


            var listOfHotelsIds = _applicationDbContext.hotelUsers

                .Where(hotelUser => hotelUser.ApplicationUserId == hotelReceptionistId)
                .Select(hotelUser => hotelUser.HotelId)
                .Distinct()
                .ToList();

            var hotels = await _applicationDbContext.Hotels
                .Include(o => o.DetailsSections)
                .Where(hotel => listOfHotelsIds.Contains(hotel.Id))
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            var result = _mapper.Map<List<HotelDto>>(hotels);

            return result;

        }


        public async Task<PagedListDto<HotelDto>> Handle(GetHotelsListQuery request, CancellationToken cancellationToken)
        {

            var filter = HotelsStrategies.GetFilterStrategy(request.CurrentFilter);

            var query = filter.FetchData(_applicationDbContext.Hotels, request);

            var data = _mapper.Map<List<HotelDto>>(await query.Data.Include(o => o.DetailsSections).ToListAsync(cancellationToken).ConfigureAwait(false));


            return new PagedListDto<HotelDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

            public async Task<HotelDto> Handle(GetHotelByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _applicationDbContext.Hotels.Include(o => o.DetailsSections).Where(u => u.Id == request.Id)
                 .FirstOrDefaultAsync().ConfigureAwait(false);

            var hotelDto = _mapper.Map<HotelDto>(entity);
            hotelDto.CurrentUserRating = await getCurrentUserRating(request.Id);
            return hotelDto;
        }


        public async Task<int> getCurrentUserRating(Guid HotelId)
        {
            var user_id = _userService.GetUserId();

            var user = await _userManager.FindByIdAsync(user_id);
            if (user == null)
                throw new NotFoundException(nameof(user), user_id);


            var roles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            if (roles.Contains(Roles.HotelClient.ToString()))
            {
                var ratingObject = await _applicationDbContext.HotelUserRatings.Where(ratings => ratings.HotelId == HotelId && ratings.ApplicationUserId == Guid.Parse(user_id)).FirstOrDefaultAsync();
                if (ratingObject == null)
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