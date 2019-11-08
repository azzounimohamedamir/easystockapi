using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Create;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Pricings.Tarifications.Commands.Update
{
    public class UpdateTarificationModel : CreateTarificationModel, IUpdateTarificationModel
    {
        public string Id { get; set; }
        public List<IdName> ProductsNames { get; set; } = new List<IdName>();
        public List<IdName> DishesNames { get; set; } = new List<IdName>();
    }
}