using SmartRestaurant.Application.Commun.Specialites.Queries.Models;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Resources.Utils;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Commun.Specialites.Queries.Factory
{
    public static class SpecialityItemModelFactory
    {
        public static SpecialityItemModel ToSpecialityItemModel(this Speciality entity)
        {
            return new SpecialityItemModel
            {
                Id = entity.Id.ToString(),
                Name = entity.Name,                
                SlugUrl = entity.SlugUrl,
                IsDisabled = entity.IsDisabled ? UtilsResource.IsDisabledTrueValueText : UtilsResource.IsDisabledFalseValueText,
            };
        }

        public static IEnumerable<SpecialityItemModel> ToSpecialityItemModels(this IEnumerable<Speciality> entities)
        {
            return entities.Select(e => e.ToSpecialityItemModel()).ToList();
        }
    }
    
}
