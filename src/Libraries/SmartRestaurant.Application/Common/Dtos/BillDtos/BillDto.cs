using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos.BillDtos
{
    public class BillDto
    {
        public BillDto()
        {
            Tables = new List<BillTableDto>();
        }
        public Guid OrderId { get; set; }
        public int Number { get; set; }
        public float TotalToPay { get; set; }
        public float TvaPercentage { get; set; }
        public float TvaValue { get; set; }
        public float Discount { get; set; }
        public OrderTypes Type { get; set; }
        public OrderStatuses Status { get; set; }
        public List<BillTableDto> Tables { get; set; }
        public DateTime CreatedAt { get; set; }
        public BillFoodBusinessDto FoodBusiness { get; set; }
        public BillFoodBusinessClientDto FoodBusinessClient { get; set; }

    }
}
