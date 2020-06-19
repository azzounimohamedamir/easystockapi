using SmartRestaurant.Application.Foods.Queries;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Allergies.Illnesses.Queries
{
    public class IllnessItemModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SlugUrl { get; set; }
        public string IsDisabled { get; set; }
        public IEnumerable<FoodItemModel> Foods { get; set; }
    }
}
