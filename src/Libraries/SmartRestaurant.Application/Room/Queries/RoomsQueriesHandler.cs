using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Hotels.Queries.FilterStrategy;
using SmartRestaurant.Application.Rooms.Queries.FilterStrategy;

namespace SmartRestaurant.Application.Rooms.Queries
{
    public class RoomsQueriesHandler :
        IRequestHandler<GetAllRoomsByBuildingId,PagedListDto<RoomDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public RoomsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       

        public async Task<PagedListDto<RoomDto>> Handle(GetAllRoomsByBuildingId request, CancellationToken cancellationToken)
        {
            var filter = RoomStrategies.GetFilterStrategy(request.CurrentFilter);
            DateTime currentDate = DateTime.Now;

            var query = filter.FetchData(_context.Rooms, request);

            var data = _mapper.Map<List<RoomDto>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            foreach (RoomDto room in data)
            {
                var isBooked = (currentDate < room.DateCheckout);
                room.AvailableForCheckin = (!isBooked && room.Cleaned); // check if room available for checkin
                room.IsBooked = isBooked;
            }


            return new PagedListDto<RoomDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);



          
        }
    }
}