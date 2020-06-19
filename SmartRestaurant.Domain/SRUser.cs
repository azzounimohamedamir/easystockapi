using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Domain
{
    public class SRUser : BaseEntity<string>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
        public string ChainId { get; set; }
        public string RestuarantId { get; set; }
    }
}
