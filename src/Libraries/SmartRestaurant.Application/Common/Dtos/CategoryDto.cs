using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class CategoryDto
    {
        public string Nom { get; set; }
        public List<CategoryAttributsDto> CategorieAttributs { get; set; } = new List<CategoryAttributsDto>();

    }
}
