using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Domain.Entities
{
    public class HotelService
    {
        public Guid Id { get; set; }
        public Guid SectionId { get; set; }
        public Names Names { get; set; }
        public byte[] Picture { get; set; }
        public string VideoUrl { get; set; }
        public Guid OrderDestinationId { get; set; }
        public List<ServiceParametre> Parametres { get; set; }
        public bool isSmartrestaurantMenue { get; set; }
        public Guid FoodBusinessID { get; set; }
        public Guid MenuID { get; set; }
        public Names DetailServce { get; set; }
        public Names TitelSeccesResponce { get; set; }
        public Names TitelFailureResponce { get; set; }
    }
}
