using SmartRestaurant.Application.Common.Dtos.BillDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos.OrdersDtos
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
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
        public Guid FoodBusinessId { get; set; }
        public Guid? FoodBusinessClientId { get; set; }
        public BillFoodBusinessDto FoodBusiness { get; set; }
        public BillFoodBusinessClientDto FoodBusinessClient { get; set; }

    }
}
