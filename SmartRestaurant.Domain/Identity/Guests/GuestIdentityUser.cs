using SmartRestaurant.Domain.BaseIdentity;

namespace SmartRestaurant.Domain.Identity.Guests
{
    public class GuestIdentityUser : BaseIdentityUser
    {
        public string RestuarantId { get; set; }
    }
}
