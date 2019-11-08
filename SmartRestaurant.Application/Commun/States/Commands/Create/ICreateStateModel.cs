using System.Collections.Generic;
using SmartRestaurant.Application.Commun.Select;

namespace SmartRestaurant.Application.Commun.Countries.Commands.Create
{
    public interface ICreateStateModel
    {
        string Alias { get; set; }
        List<SelectItemModel> Countries { get; set; }
        string CountryId { get; set; }
        string IsoCode { get; set; }
        string Name { get; set; }
    }
}