using SmartRestaurant.Domain.BaseIdentity;

namespace SmartRestaurant.Domain.Clients.Identity
{
    public class SRIdentityUser : BaseIdentityUser
    {
        public string RestaurantId { get; set; }
        public string ChainId { get; set; }
        public bool IsDisabled { get; set; }
    }
}
