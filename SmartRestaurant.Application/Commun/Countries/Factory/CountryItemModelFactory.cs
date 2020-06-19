using SmartRestaurant.Domain.Commun;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Countries.Factory
{

    public static class CountryItemModelExtension
    {
        public static CountryItemModel ToCountryItemModel(this Country entity)
        {
            return new CountryItemModel
            {
                Id = entity.Id,
                //Name = entity.Name,
                //IsoCode = entity.IsoCode,
                //Alias = entity.Alias,
            };
        }
        public static List<CountryItemModel> ToCountryItemModels(this IEnumerable<Country> entities)
        {
            return (from entity in entities
                    select entity.ToCountryItemModel())
                .ToList();
        }

    }
}
