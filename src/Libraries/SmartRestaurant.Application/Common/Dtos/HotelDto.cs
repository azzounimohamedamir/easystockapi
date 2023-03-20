using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Dtos
{
    public class HotelDto
    {
        public Guid Id { get; set; }
        public string ImagUrl { get; set; }
        public string Picture { get; set; }

        public string FoodBusinessAdministratorId { get; set; }
        public string Name { get; set; }
        public Names Names { get; set; }
        public int NRC { get; set; }
        public int NIF { get; set; }
        public int NIS { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string? YoutubeLink { get; set; }
        public Address Address { get; set; }
        public Odoo Odoo { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public List<HotelDetailsSectionDto> DetailsSections { get; set; }
        public string Website { get; set; }
        
    }
}
