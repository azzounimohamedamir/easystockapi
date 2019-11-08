using SmartRestaurant.Application.Commun.Select;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Commun.Countries.Commands.Create
{
    public class CreateStateModel : ICreateStateModel
    {

        public string CountryId { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        public string Alias { get; set; }
        public bool IsDisabled { get; set; }
        public List<SelectItemModel> Countries { get; set; }

    }
}