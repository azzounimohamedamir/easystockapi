using System;
using SmartRestaurant.Domain.Entities.Globalisation;
using SmartRestaurant.Domain.Interfaces;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Domain.Entities
{
    public class RestaurantCustomer:IOrganization
    {
        public Guid RestaurantCustomerId { get; set; }
        public string NameArabic { get; set; }
        public string NameFrench { get; set; }
        public string NameEnglish { get; set; }
        public int NRC { get; set; }
        public int NIF { get; set; }
        public int NIS { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Website { get; set; }
        public ApplicationUser UserManager { get; set; }
    }
}
