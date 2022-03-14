using System;

namespace SmartRestaurant.Domain.Entities
{
    public class SubSectionProduct
    {
        public Guid SubSectionId { get; set; }
        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; }

    }
}
