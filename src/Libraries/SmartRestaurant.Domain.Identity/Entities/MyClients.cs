using System;

namespace SmartRestaurant.Domain.Identity.Entities
{
    public class MyClients
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MacAdresse { get; set; }
        public bool LicenceStatus { get; set; }

    }
}
