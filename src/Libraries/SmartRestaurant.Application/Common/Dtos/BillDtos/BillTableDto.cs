using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos.BillDtos
{
    public class BillTableDto
    {
        public BillTableDto()
        {
            Chairs = new List<BillChairDto>();
        }

        public string TableId { get; set; }
        public int TableNumber { get; set; }
        public List<BillChairDto> Chairs { get; set; }
    }
}
