using SmartRestaurant.Domain.Common;
using System;

namespace SmartRestaurant.Domain.Entities
{
    public class OrderProduct : OrderMenuItem
    {
        public Guid OrderProductId { get; set; }
        public string ProductId { get; set; }
        public string SectionId { get; set; }
        public string SubSectionId { get; set; }
    }
}
