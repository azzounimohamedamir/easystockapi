using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class AvanceDto
    {
        public Guid Id { get; set; }
        public decimal MontantAvance { get; set; }
        public DateTime DateAvance { get; set; }
    }

}
