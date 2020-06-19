using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Commun.Countries.Commands.Create;
using SmartRestaurant.Application.Commun.State.Commands.Create;

namespace SmartRestaurant.Client.Web.Models.States
{
    public class StateViewModel
    {


        public CreateStateModel CreateModel { get; set; }
        public UpdateStateModel UpdateModel { get; set; }
        public SelectList Countries { get; set; }

    }
}
