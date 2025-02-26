using System;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class AvanceDto
    {
        public Guid Id { get; set; }
        public decimal MontantAvance { get; set; }
        public DateTime DateAvance { get; set; }
    }

}
