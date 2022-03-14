using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos.BillDtos
{
    public class BillChairDto
    {
        public BillChairDto()
        {
            Dishes = new List<BillDishDto>();
            Products = new List<BillProductDto>();
        }

        public int ChairNumber { get; set; }
        public float TotalToPay { get; set; }
        public List<BillDishDto> Dishes { get; set; }
        public List<BillProductDto> Products { get; set; }
    }
}
