using Microsoft.AspNetCore.Mvc.Rendering;

namespace SmartRestaurant.Client.Web.Models.Foods
{
    public class FoodCompositionViewModel
    {
        public string Id { get; set; }
        public int Index { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Foods { get; set; }
        public SelectList Units { get; set; }

    }
}
