using SmartRestaurant.Application.Common.Dtos.DishDtos;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class ActiveMenuItemDto
    {
        public List<ProductDto> Products { get; set; }
        public List<DishDto> Dishes { get; set; }

    }
}
