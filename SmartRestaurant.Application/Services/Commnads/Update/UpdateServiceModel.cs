using SmartRestaurant.Application.Services.Commnads.Create;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Services.Commnads.Update
{
    public class UpdateServiceModel : CreateServiceModel, IUpdateServiceModel
    {
        public string Id { get; set; }
    }
}
