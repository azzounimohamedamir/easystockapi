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

namespace SmartRestaurant.Application.Reservations.Queries
{
    public class ReservationsQueriesHandler :
        IRequestHandler<GetReservationsListByReservationDateTimeIntervalQuery, PagedListDto<ReservationDto>>,
        IRequestHandler<GetClientReservationsHistoryQuery, PagedListDto<ReservationClientDto>>,
        IRequestHandler<GetReservationByIdQuery, ReservationDto>,
        IRequestHandler<GetClientNonExpiredReservationsQuery, PagedListDto<ReservationClientDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ReservationsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedListDto<ReservationClientDto>> Handle(GetClientNonExpiredReservationsQuery request,
            CancellationToken cancellationToken)
        {
            var query =
                _context.Reservations
                    .Where(reservation => reservation.CreatedBy == request.UserId
                                          && reservation.ReservationDate >= DateTime.Now)
                    .OrderBy(reservation => reservation.ReservationDate)
                    .Include(reservation => reservation.FoodBusiness)
                    .GetPaged(request.Page, request.PageSize);

            var data = _mapper.Map<List<ReservationClientDto>>(await query.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));

            var pagedResult = new PagedListDto<ReservationClientDto>(query.CurrentPage, query.PageCount, query.PageSize,
                query.RowCount, data);
            return pagedResult;
        }

        public async Task<PagedListDto<ReservationClientDto>> Handle(GetClientReservationsHistoryQuery request,
            CancellationToken cancellationToken)
        {
            var query =
                _context.Reservations
                    .Where(reservation => reservation.CreatedBy == request.UserId
                                          && reservation.ReservationDate <= DateTime.Now)
                    .OrderBy(reservation => reservation.ReservationDate)
                    .Include(reservation => reservation.FoodBusiness)
                    .GetPaged(request.Page, request.PageSize);

            var data = _mapper.Map<List<ReservationClientDto>>(await query.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));

            var pagedResult = new PagedListDto<ReservationClientDto>(query.CurrentPage, query.PageCount, query.PageSize,
                query.RowCount, data);
            return pagedResult;
        }

        public async Task<ReservationDto> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var query = await _context.Reservations.FindAsync(request.ReservationId).ConfigureAwait(false);
            return _mapper.Map<ReservationDto>(query);
        }

        public async Task<PagedListDto<ReservationDto>> Handle(
            GetReservationsListByReservationDateTimeIntervalQuery request,
            CancellationToken cancellationToken)
        {
            var query =
                _context.Reservations
                    .Where(reservation => reservation.FoodBusinessId == request.FoodBusinessId
                                          && reservation.ReservationDate >= request.TimeIntervalStart
                                          && reservation.ReservationDate <= request.TimeIntervalEnd)
                    .OrderBy(reservation => reservation.ReservationDate)
                    .GetPaged(request.Page, request.PageSize);

            var data = _mapper.Map<List<ReservationDto>>(await query.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));

            var pagedResult = new PagedListDto<ReservationDto>(query.CurrentPage, query.PageCount, query.PageSize,
                query.RowCount, data);
            return pagedResult;
        }
    }
}