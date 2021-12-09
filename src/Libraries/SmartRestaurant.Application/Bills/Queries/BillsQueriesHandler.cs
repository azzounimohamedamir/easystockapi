using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Bills.Queries;
using SmartRestaurant.Application.Bills.Queries.FilterStrategy;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.BillDtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Orders.Queries
{
    public class BillsQueriesHandler : IRequestHandler<GetBillsListQuery, PagedListDto<BillDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BillsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PagedListDto<BillDto>> Handle(GetBillsListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetBillsListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusiness = await _context.FoodBusinesses.FindAsync(Guid.Parse(request.FoodBusinessId));
            if (foodBusiness == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            var filter = BillStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Orders, request);

            var queryData = await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false);
            var data = _mapper.Map<List<BillDto>>(queryData);
            //MapBillTables(queryData, data);
            return new PagedListDto<BillDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

        private void MapBillTables(List<Order> queryData, List<BillDto> data)
        {
            foreach (var bill in data)
            {
                var billOrder = queryData.Find(x => x.OrderId == bill.OrderId);
                if (bill.Type == OrderTypes.DineIn)
                {
                    bill.Tables = GetBillTablesForDineInOrder(billOrder);
                }
                else
                {
                    bill.Tables = GetBillTablesForTackoutAndDeliveryOrder(billOrder);
                }
            }
        }

        public List<BillTableDto> GetBillTablesForDineInOrder(Order order) {
            var billTables = new List<BillTableDto>();

            foreach (var product in order.Products)
            {
                CreateBillTableIfNotExist(billTables, product.TableId, product.TableNumber);
                CreateChairTableIfNotExist(billTables, product.TableId, product.ChairNumber);

                var chair = billTables.Find(x => x.TableId == product.TableId)
                    .Chairs.Find(x => x.ChairNumber == product.ChairNumber);
                chair.Products.Add(_mapper.Map<BillProductDto>(product));
                chair.TotalToPay += (product.Quantity * product.UnitPrice);
            }

            foreach (var dish in order.Dishes)
            {
                var billTable = billTables.Find(x => x.TableId == dish.TableId);
                CreateBillTableIfNotExist(billTables, dish.TableId, dish.TableNumber);
                CreateChairTableIfNotExist(billTables, dish.TableId, dish.ChairNumber);


                var chair = billTables.Find(x => x.TableId == dish.TableId)
                    .Chairs.Find(x => x.ChairNumber == dish.ChairNumber);
                chair.Dishes.Add(_mapper.Map<BillDishDto>(dish));
                chair.TotalToPay += (dish.Quantity * dish.UnitPrice);
            }

            return billTables;
   }

        private static void CreateChairTableIfNotExist(List<BillTableDto> billTables, string tableId , int chairNumber)
        {
            var chair = billTables.Find(x => x.TableId == tableId).Chairs.Find(x => x.ChairNumber == chairNumber);
            if (chair == null)
            {
                billTables.Find(x => x.TableId == tableId)
                .Chairs.Add(new BillChairDto
                {
                    ChairNumber = chairNumber
                });
            }
        }

        private static void CreateBillTableIfNotExist(List<BillTableDto> billTables, string tableId, int tableNumber)
        {
            var billTable = billTables.Find(x => x.TableId == tableId);
            if (billTable == null)
            {
                billTables.Add(new BillTableDto
                {
                    TableId = tableId,
                    TableNumber = tableNumber
                });
            }
        }

        public List<BillTableDto> GetBillTablesForTackoutAndDeliveryOrder(Order order)
        {
            var billTables = new List<BillTableDto> { new BillTableDto() };
            billTables[0].Chairs.Add(new BillChairDto());          
            foreach (var product in order.Products)
            {
                billTables[0].Chairs[0].Products.Add(_mapper.Map<BillProductDto>(product));
            }

            foreach (var dish in order.Dishes)
            {
                billTables[0].Chairs[0].Dishes.Add(_mapper.Map<BillDishDto>(dish));
            }
            return billTables;
        }

    }
}