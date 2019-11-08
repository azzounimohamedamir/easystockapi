using System.Collections.Generic;

namespace SmartRestaurant.Application.Allergies.Illnesses.Commands.Create
{
    public class CreateIllnessModel : ICreateIllnessModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }
        public bool IsDisabled { get; set; }

        public List<string> FoodsIds { get; set; } = new List<string>();
    }
}