using AutoMapper;
using SmartRestaurant.Application.Common.Dtos.BillDtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Mappers
{
    public class BillResolver : IValueResolver<Order, BillDto, List<BillTableDto>>
    {
        public List<BillTableDto> Resolve(Order source, BillDto destination, List<BillTableDto> member, ResolutionContext context)
        {
            if (source.Type == OrderTypes.DineIn)
            {
                return GetBillTablesForDineInOrder(source, context);
            }
            else
            {
                return GetBillTablesForTackoutAndDeliveryOrder(source, context);
            }
        }

        public List<BillTableDto> GetBillTablesForDineInOrder(Order order, ResolutionContext context)
        {
            var billTables = new List<BillTableDto>();

            foreach (var product in order.Products)
            {
                CreateBillTableIfNotExist(billTables, product.TableId, product.TableNumber);
                CreateChairTableIfNotExist(billTables, product.TableId, product.ChairNumber);

                var chair = billTables.Find(x => x.TableId == product.TableId)
                    .Chairs.Find(x => x.ChairNumber == product.ChairNumber);
                chair.Products.Add(context.Mapper.Map<OrderProduct, BillProductDto> (product));
                chair.TotalToPay += BillHelpers.CalculatePriceAfterDiscount((product.Quantity * product.UnitPrice), order.Discount);
            }

            foreach (var dish in order.Dishes)
            {
                var billTable = billTables.Find(x => x.TableId == dish.TableId);
                CreateBillTableIfNotExist(billTables, dish.TableId, dish.TableNumber);
                CreateChairTableIfNotExist(billTables, dish.TableId, dish.ChairNumber);


                var chair = billTables.Find(x => x.TableId == dish.TableId)
                    .Chairs.Find(x => x.ChairNumber == dish.ChairNumber);
                chair.Dishes.Add(context.Mapper.Map<OrderDish, BillDishDto>(dish));
                chair.TotalToPay += BillHelpers.CalculatePriceAfterDiscount((dish.Quantity * dish.UnitPrice), order.Discount);
            }
           
            return billTables;
        }

        private static void CreateChairTableIfNotExist(List<BillTableDto> billTables, string tableId, int chairNumber)
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

        public List<BillTableDto> GetBillTablesForTackoutAndDeliveryOrder(Order order, ResolutionContext context)
        {
            var billTables = new List<BillTableDto> { new BillTableDto() };
            billTables[0].Chairs.Add(new BillChairDto());
            foreach (var product in order.Products)
            {
                billTables[0].Chairs[0].Products.Add(context.Mapper.Map<OrderProduct, BillProductDto>(product));
            }

            foreach (var dish in order.Dishes)
            {
                billTables[0].Chairs[0].Dishes.Add(context.Mapper.Map<OrderDish, BillDishDto>(dish));
            }
            return billTables;
        }
    }
}
