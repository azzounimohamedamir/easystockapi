using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Domain.Enumerations;

namespace SmartRestaurant.Client.Web.Models.Dishes
{
    public class DishListFilterViewModel
    {
        public string Name { get; set; }
        public string RestaurantId { get; set; }
        public SelectList Restaurants { get; set; }

        public EnumDishType? Type { get; set; }
        public SelectList Types { get; set; }

        //public string FamilyId { get; set; }
        //public SelectList Famillies { get; set; }

        //public List<string> HasIngredients { get; set; }
        //public SelectList Ingredients { get; set; }

        public bool IsDefined
        {
            get
            {
                return !string.IsNullOrEmpty(Name)
                     || !string.IsNullOrEmpty(RestaurantId)
                     || Type != null;
                //|| !string.IsNullOrEmpty(FamilyId)
                //|| (HasIngredients != null && HasIngredients.Count > 0)
            }
        }

    }
}
