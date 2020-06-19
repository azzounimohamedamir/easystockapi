using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Create;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Update;

namespace SmartRestaurant.Client.Web.Models.Pricings
{
    public class TarificationViewModel
    {
        public string SelectedProductFamily { get; set; }
        public SelectList ProductFamilies { get; set; }
        public SelectList Products { get; set; }
        public SelectList SelectedProducts { get; set; }

        public string SelectedDishFamily { get; set; }
        public SelectList DishFamilies { get; set; }
        public SelectList Dishes { get; set; }
        public SelectList SelectedDishes { get; set; }

        public string SelectedRestaurant { get; set; }
        public SelectList Restaurants { get; set; }

        public UpdateTarificationModel UpdateModel { get; set; }
        public CreateTarificationModel CreateModel { get; set; }

        public string Action { get; set; } = "add";
    }
}
