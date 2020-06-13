using Newtonsoft.Json;

namespace SmartRestaurant.Application.Restaurants.Menu.Queries.GetAllFilterd
{
    public class MenuQueryModel
    {
        public MenuQueryModel()
        {
            
        }
        public MenuQueryModel(Domain.Restaurants.Menu menu)
        {
            Id = menu.Id.ToString();
            Name = menu.Name;

        }
        [JsonProperty(PropertyName = "id")] public string Id { get; set; }
        [JsonProperty(PropertyName = "name")] public string Name { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "restaurant")]
        public string Restaurant { get; set; }

        [JsonProperty(PropertyName = "isDisabled")]
        public bool IsDisabled { get; set; }

        [JsonProperty(PropertyName = "restaurantId")]
        public string RestaurantId { get; set; }

    }
}
