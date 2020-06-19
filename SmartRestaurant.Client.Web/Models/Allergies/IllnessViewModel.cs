using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Create;
using SmartRestaurant.Application.Allergies.Illnesses.Commands.Update;

namespace SmartRestaurant.Client.Web.Models.Allergies
{
    public class IllnessViewModel
    {

        public SelectList Foods { get; set; }
        public SelectList SelectedFoods { get; set; }
        public UpdateIllnessModel UpdateModel { get; set; }
        public CreateIllnessModel CreateModel { get; set; }

    }
}
