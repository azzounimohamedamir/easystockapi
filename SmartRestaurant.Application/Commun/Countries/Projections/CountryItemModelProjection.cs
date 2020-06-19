using SmartRestaurant.Domain.Commun;
using System;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Commun.Countries.Projections
{
    public static class CountryItemModelProjection
    {
        public static Expression<Func<Country, CountryItemModel>> Projection
        {
            get
            {
                return x => new CountryItemModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsoCode = x.IsoCode,
                    Alias = x.Alias,
                };
            }
        }

    }
}
