using SmartRestaurant.Application.Commun.Quantities;

namespace SmartRestaurant.Client.Web.Models.Commun
{
    public class QuantityViewModel
    {
        public QuantityViewModel(SelectUnitModel units)
        {
            Units = units;
        }
        public SelectUnitModel Units { get; set; }
        public QuantityModel Quantity { get; set; }
    }
}
