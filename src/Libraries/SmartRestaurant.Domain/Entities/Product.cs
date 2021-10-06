using SmartRestaurant.Domain.Common;
using System;

namespace SmartRestaurant.Domain.Entities
{
    public class Product : MenuItem
    {
        public Guid ProductId { get; set; }
    }

    
}
