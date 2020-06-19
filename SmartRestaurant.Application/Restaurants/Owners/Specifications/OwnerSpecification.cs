using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Restaurants.Owners.Specifications
{
    class OwnerSpecification : BaseSpecification<Owner>
    {
        public OwnerSpecification() : base()
        {

        }
        public OwnerSpecification(Expression<Func<Owner, bool>> expression) : base(expression)
        {

        }
    }
}
