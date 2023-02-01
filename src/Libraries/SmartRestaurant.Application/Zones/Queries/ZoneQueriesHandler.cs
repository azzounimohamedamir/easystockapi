using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Zones.Queries
{
    public class ZoneQueriesHandler :
        IRequestHandler<GetZonesListQuery, IEnumerable<ZoneDto>>,
        IRequestHandler<GetZoneByIdQuery, ZoneDto>,
        IRequestHandler<GetZonesListWithTablesQuery, IEnumerable<ZoneWithTablesDto>>,
          IRequestHandler<GetZonesListWithNumberOfOrdersQuery, IEnumerable<ZoneWithNumberOfOrdersDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ZoneQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ZoneDto> Handle(GetZoneByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ZoneDto>(await _context.Zones.FindAsync(request.ZoneId).ConfigureAwait(false));
        }

        public async Task<IEnumerable<ZoneDto>> Handle(GetZonesListQuery request, CancellationToken cancellationToken)
        {
            var query = await _context.Zones
                         .Where(x => x.FoodBusinessId == request.FoodBusinessId)
                         .ToArrayAsync(cancellationToken)
                         .ConfigureAwait(false);
            return _mapper.Map<List<ZoneDto>>(query);
        }

        public async Task<IEnumerable<ZoneWithTablesDto>> Handle(GetZonesListWithTablesQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetZonesListWithTablesQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var queryZone = await _context.Zones
                .Where(x => x.FoodBusinessId == Guid.Parse(request.FoodBusinessId))
                .Include(x => x.Tables)
                .ToArrayAsync(cancellationToken)
                .ConfigureAwait(false);
            var queryZoneDto = _mapper.Map<List<ZoneWithTablesDto>>(queryZone);
            return queryZoneDto;
        }


        public async Task<IEnumerable<ZoneWithNumberOfOrdersDto>> Handle(GetZonesListWithNumberOfOrdersQuery request, CancellationToken cancellationToken)
        {

            var foodBusinessId = request.FoodBusinessId;
            var validator = new GetZonesListWithNumberOfOrdersQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);


         
            var todaysOrders = (from z in _context.Zones
                                join t in _context.Tables on z.ZoneId equals t.ZoneId
                                join oot in _context.OrderOccupiedTables on t.TableId.ToString() equals oot.TableId
                                join o in _context.Orders on oot.OrderId equals o.OrderId
                         
                                where o.CreatedAt.Date == DateTime.Today
                                select new
                                {
                                    FoodBusinessId = z.FoodBusinessId,
                                    ZoneId = z.ZoneId,
                                    Names_AR = z.Names.AR
                                   ,
                                    Names_EN = z.Names.EN
                                   ,
                                    Names_FR = z.Names.FR
                                   ,
                                    Names_RU = z.Names.RU
                                   ,
                                    Names_TR = z.Names.TR,
                                    OrderStatus = o.Status,
                                    ZoneTitle = z.ZoneTitle,
                                    TableId =  t.TableId,
                                       TableNumber = t.TableNumber,
                                          TableState = t.TableState,


                                } into s
                                where s.FoodBusinessId.ToString() == foodBusinessId
                                group s by new
                                {

                                    s.TableNumber,
                                    s.TableId,
                                    s.TableState,
                                    s.ZoneId,
                                    s.OrderStatus,
                                    s.ZoneTitle,
                                    s.Names_AR
                               ,
                                    s.Names_EN
                               ,
                                    s.Names_FR
                               ,
                                    s.Names_RU
                               ,
                                    s.Names_TR


                                } into g

                                select new ZoneWithNumberOfOrdersDto
                                {
                                    TableId = g.Key.TableId,
                                    TableNumber = g.Key.TableNumber,
                                    TableState = g.Key.TableState,
                                    ZoneId = g.Key.ZoneId,
                                    OrderStatus = g.Key.OrderStatus,
                                    ZoneTitle = g.Key.ZoneTitle,
                                    Names = new Names
                                    {
                                        AR = g.Key.Names_AR,
                                        EN = g.Key.Names_EN,
                                        FR = g.Key.Names_FR,
                                        TR = g.Key.Names_TR,
                                        RU = g.Key.Names_RU,
                                    },
                                    NumberOfOrders = g.Count()
                                }).ToList();


            return todaysOrders;


        }


    }
}