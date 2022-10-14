using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Hotels.Queries.FilterStrategy;

namespace SmartRestaurant.Application.Hotels.Queries
{
    public class HotelsQueriesHandler :
        IRequestHandler<GetHotelsListQuery, PagedListDto<HotelDto>>,
        IRequestHandler<GetHotelsListByAdmin, List<HotelDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IIdentityContext _identityContext;


        public HotelsQueriesHandler(IIdentityContext identityContext, IApplicationDbContext context, IMapper mapper,IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
            _identityContext = identityContext;
        }

        public async Task<List<HotelDto>> Handle(GetHotelsListByAdmin request,
             CancellationToken cancellationToken)
        {
            var foodBusinessAdministratorId =
                ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            await ChecksHelper
                .CheckUserExistence_ThrowExceptionIfUserNotFound(_identityContext, foodBusinessAdministratorId)
                .ConfigureAwait(false);

            var hotels = await _context.Hotels
                .Where(x => x.FoodBusinessAdministratorId == foodBusinessAdministratorId)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);

            return _mapper.Map<List<HotelDto>>(hotels);
        }

        public async Task<PagedListDto<HotelDto>> Handle(GetHotelsListQuery request, CancellationToken cancellationToken)
        {

            var filter = HotelsStrategies.GetFilterStrategy(request.CurrentFilter);

            var query = filter.FetchData(_context.Hotels, request);

            var data = _mapper.Map<List<HotelDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));


            return new PagedListDto<HotelDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }
    }
}