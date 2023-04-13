using SmartRestaurant.Application.Common.Dtos.BillDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos.OrdersDtos
{
    public class OrderDto
    {
        public string OrderId { get; set; }
        public int Number { get; set; }
        public float TotalToPay { get; set; }
        public float MoneyReceived { get; set; }
        public float MoneyReturned { get; set; }
        public OrderTypes Type { get; set; }
        public OrderStatuses Status { get; set; }
        public TakeoutDetailsDto TakeoutDetails { get; set; }
        public List<OrderDishDto> Dishes { get; set; }
        public List<OrderProductDto> Products { get; set; }
        public List<OrderOccupiedTableDto> OccupiedTables { get; set; }
        public List<CurrencyDto> CurrencyExchange { get; set; }
        public DateTime CreatedAt { get; set; }
        public ApplicationUserDto CreatedBy { get; set; }
        public string FoodBusinessId { get; set; }
        public string? FoodBusinessClientId { get; set; }
        public BillFoodBusinessDto FoodBusiness { get; set; }
        public BillFoodBusinessClientDto FoodBusinessClient { get; set; }
        public CommissionConfigs CommissionConfigs { get; set; }
        public ErrorResult ErrorDeliveryTimeAvailabilite { get; set; }

         public GeoPosition? GeoPosition { get; set; }
        public long? OdooClientId { get; set; }
        public string? OdooUrl { get; set; }
        public string? OrderedBy { get; set; }

    }
}
