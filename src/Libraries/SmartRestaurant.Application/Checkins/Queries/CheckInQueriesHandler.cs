using System;
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
using SmartRestaurant.Domain.Entities;
using Newtonsoft.Json;

namespace SmartRestaurant.Application.Checkins.Queries
{
    public class CheckInQueriesHandler :
        IRequestHandler<GetCheckinsListQuery, PagedListDto<CheckinDto>>,
        IRequestHandler<GetCheckinsListOfClientQuery, PagedListDto<CheckinDto>>


    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;


        public CheckInQueriesHandler( IUserService userService,
        IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<PagedListDto<CheckinDto>> Handle(GetCheckinsListQuery request,
            CancellationToken cancellationToken)
        {
            var query =
                _context.CheckIns
                    .Where(checkin => checkin.hotelId == request.hotelId)
                    .GetPaged(request.Page, request.PageSize);

            var data = _mapper.Map<List<CheckinDto>>(await query.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));

            var pagedResult = new PagedListDto<CheckinDto>(query.CurrentPage, query.PageCount, query.PageSize,
                query.RowCount, data);
            return pagedResult;
        }

        public async Task<PagedListDto<CheckinDto>> Handle(GetCheckinsListOfClientQuery request,
            CancellationToken cancellationToken)
        {
            var userconnected = _userService.GetUserId();
            var query = from c in _context.CheckIns
                        join ro in _context.Rooms on c.RoomId equals ro.Id
                        join b in _context.Buildings on ro.BuildingId equals b.Id
                        join h in _context.Hotels on b.HotelId equals h.Id

                        where c.ClientId == userconnected
                        select new CheckinDto
                        {   
                            Id = c.Id,
                            ClientId = c.ClientId,
                            Email = c.Email,
                            FullName = c.FullName,
                            PhoneNumber = c.PhoneNumber,
                            IsActivate = c.IsActivate,
                            hotelId = c.hotelId,
                            hotelName = h.Name,
                            buildingName = b.Name,
                            RoomId = c.RoomId,
                            RoomNumber = c.RoomNumber,
                            LengthOfStay = c.LengthOfStay,
                            Startdate=c.Startdate
                        };
            
            var pagedquery= query.GetPaged(request.Page, request.PageSize);

            var data = _mapper.Map<List<CheckinDto>>(await pagedquery.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));

            var pagedResult = new PagedListDto<CheckinDto>(pagedquery.CurrentPage, pagedquery.PageCount, pagedquery.PageSize,
                pagedquery.RowCount, data);
            return pagedResult;
        }


    }
}