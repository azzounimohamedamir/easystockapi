using System;
using System.Collections.Generic;
using System.Text;
using SmartRestaurant.Application.Foods.Queries;
using SmartRestaurant.Application.Foods.Queries.GetAll;

namespace SmartRestaurant.Application.Allergies.Allergies.Queries
{
    public class AllergyItemModel
    {
        public string Id { get;  set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string IsDisabled { get;  set; }
        public IEnumerable<FoodItemModel> Foods { get;  set; }
        public string SlugUrl { get;  set; }
    }
}
