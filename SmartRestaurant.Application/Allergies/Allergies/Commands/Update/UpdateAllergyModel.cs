using SmartRestaurant.Application.Allergies.Allergies.Commands.Create;
using SmartRestaurant.Application.Helpers;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Allergies.Allergies.Commands.Update
{
    public class UpdateAllergyModel : CreateAllergyModel, IUpdateAllergyModel
    {
        public string Id { get; set; }
        public List<IdName> FoodsIdsNames { get; set; } = new List<IdName>();
    }
}