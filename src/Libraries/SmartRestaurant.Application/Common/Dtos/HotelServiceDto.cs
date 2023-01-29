using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class HotelServiceDto
    {

        public Guid Id { get; set; }
        public Names Names { get; set; }
        public string Picture { get; set; }
        public string VideoUrl { get; set; }
        public Guid OrderDestinationId { get; set; }
        public List<ServiceParametreDto> Parametres { get; set; }
        public bool isSmartrestaurantMenue { get; set; }
        public Guid FoodBusinessID { get; set; }
        public Guid MenuID { get; set; }
        public Names DetailServce { get; set; }
        public Names TitelSeccesResponce { get; set; }
        public Names TitelFailureResponce { get; set; }
    }
}
