using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Dishes;
using System;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Dishes.Dishes.Specifications
{
    public class DishSpecification : BaseSpecification<Dish>
    {

        public DishSpecification() : base()
        {

        }
        public DishSpecification(Expression<Func<Dish, bool>> expression) : base(expression)
        {

        }
    }
}
