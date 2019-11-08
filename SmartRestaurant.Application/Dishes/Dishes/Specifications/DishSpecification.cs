using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SmartRestaurant.Application.Dishes.Dishes.Specifications
{
    public class DishSpecification:BaseSpecification<Dish>
    {
        
        public DishSpecification():base()
        {
            
        }
        public DishSpecification(Expression<Func<Dish,bool>> expression):base(expression)
        {
            
        }
    }
}
