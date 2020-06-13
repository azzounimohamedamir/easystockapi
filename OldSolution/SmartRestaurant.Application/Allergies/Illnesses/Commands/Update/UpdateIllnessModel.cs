using SmartRestaurant.Application.Allergies.Illnesses.Commands.Create;
using SmartRestaurant.Application.Helpers;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Allergies.Illnesses.Commands.Update
{
    public class UpdateIllnessModel : CreateIllnessModel, IUpdateIllnessModel
    {
        public string Id { get; set; }
        public List<IdName> FoodsIdsNames { get; set; } = new List<IdName>();
    }
}