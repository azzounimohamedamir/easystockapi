using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Foods.Queries
{
    public interface ISelectFoodBySpecification
    {
        IEnumerable<FoodListModel> Execute(
            ISepecification specification);

    }
}
