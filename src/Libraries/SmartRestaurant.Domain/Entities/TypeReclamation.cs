using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;


namespace SmartRestaurant.Domain.Entities
{
    public class TypeReclamation
    {
        public TypeReclamation() { }
        public Guid TypeReclamationId { get; set; }
        public Guid ServiceTechniqueId { get; set; }
        public Guid HotelId { get; set; }
        public string Name { get; set; }
        public int Delai { get; set; }
        public Names Names { get; set; }
    }




}