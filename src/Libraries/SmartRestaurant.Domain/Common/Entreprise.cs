using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Domain.Common
{
    public abstract class Entreprise : AuditableEntity
    {
        public string Name { get; set; }
        public Names Names { get; set; }

        public int NRC { get; set; }
        public int NIF { get; set; }
        public int NIS { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public Address Address { get; set; }
        public PhoneNumber PhoneNumber { get; set; }

        public Odoo Odoo { get; set; }
        public string Website { get; set; }
    }
}
