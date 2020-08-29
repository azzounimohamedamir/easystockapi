using SmartRestaurant.Domain.Entities.Globalisation;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Domain.Interfaces
{
    public interface IOrganization
    {
        public string Name { get; set; }
        public int NRC { get; set; }
        public int NIF { get; set; }
        public int NIS { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public string Email { get; set; }
        public Address Address { get; set; }
        public string Website { get; set; }
    }
}