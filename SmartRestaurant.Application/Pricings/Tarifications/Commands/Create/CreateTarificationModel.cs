using System.Collections.Generic;

namespace SmartRestaurant.Application.Pricings.Tarifications.Commands.Create
{
    public class CreateTarificationModel : ICreateTarificationModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public string SlugUrl { get; set; }
        public bool IsDisabled { get; set; }
        public string RestaurantId { get; set; }

        public List<string> ProductsIds { get; set; } = new List<string>();
        public List<string> DishesIds { get; set; } = new List<string>();
        public bool IsPercentage { get; set; }
        public decimal Amount { get; set; }
    }
}