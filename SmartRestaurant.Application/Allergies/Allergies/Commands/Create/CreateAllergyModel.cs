using System.Collections.Generic;

namespace SmartRestaurant.Application.Allergies.Allergies.Commands.Create
{
    public class CreateAllergyModel : ICreateAllergyModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }
        public bool IsDisabled { get; set; }
        public List<string> FoodsIds { get; set; }
    }
}