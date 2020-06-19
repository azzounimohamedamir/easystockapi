using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Create;
using SmartRestaurant.Application.Allergies.Allergies.Commands.Update;

namespace SmartRestaurant.Client.Web.Models.Allergies
{
    public class AllergyViewModel
    {

        public SelectList Foods { get; set; }
        public SelectList SelectedFoods { get; set; }

        public UpdateAllergyModel UpdateModel { get; set; }
        public CreateAllergyModel CreateModel { get; set; }
    }
}
