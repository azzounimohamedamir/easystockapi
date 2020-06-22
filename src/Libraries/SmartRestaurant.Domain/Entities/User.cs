using SmartRestaurant.Domain.Common;
using System;

namespace SmartRestaurant.Domain.Entities.User
{
    public class User : AuditableEntity
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}