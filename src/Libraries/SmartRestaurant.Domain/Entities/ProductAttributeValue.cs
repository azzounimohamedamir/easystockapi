using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class ProductAttributeValue
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public Guid ProductAttributeId { get; set; }
        public Guid StockId { get; set; } // Foreign key property

        // Navigation properties
        public virtual Stock Stock { get; set; } // Navigation property to Stock
    }







}
