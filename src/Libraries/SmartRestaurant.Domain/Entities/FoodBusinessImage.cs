using System;
using SmartRestaurant.Domain.Common;

namespace SmartRestaurant.Domain.Entities
{
    public class FoodBusinessImage : AuditableEntity
    {
        public Guid Id { get; set; }
        public Guid EntityId { get; set; }
        public byte[] ImageBytes { get; set; }
        public string ImageTitle { get; set; }
        public bool IsLogo { get; set; }
    }
}