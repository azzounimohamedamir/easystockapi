using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Specifications
{
    class RestaurantTypeSpecification : BaseSpecification<RestaurantType>
    {
        public RestaurantTypeSpecification() : base()
        {

        }
        public RestaurantTypeSpecification(Expression<Func<RestaurantType, bool>> expression) : base(expression)
        {

        }
    }

}
