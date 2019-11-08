using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

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
 