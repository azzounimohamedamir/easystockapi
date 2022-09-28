using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class HotelsDto
    {
        public Guid Id { get; set; }
        public string ImagUrl { get; set; }
        public string FoodBusinessAdministratorId { get; set; }
        public string Name { get; set; }
    }
}
