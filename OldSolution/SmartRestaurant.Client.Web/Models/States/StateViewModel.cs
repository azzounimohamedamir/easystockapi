using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Commun.Countries.Commands.Create;
using SmartRestaurant.Application.Commun.State.Commands.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.States
{
    public class StateViewModel
    {


        public CreateStateModel CreateModel { get; set; }
        public UpdateStateModel UpdateModel { get; set; }
        public SelectList Countries { get; set; }

    }
}
