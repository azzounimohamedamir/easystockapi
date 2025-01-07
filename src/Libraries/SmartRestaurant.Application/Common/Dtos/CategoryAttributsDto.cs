using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class CategoryAttributsDto
    {
     
        public string Nom { get; set; } // Ex: Pantalon, Chaussures, etc.

        public List<ProductAttributeDto> ProductsAttributes { get; set; } = new List<ProductAttributeDto>();

    }
}
