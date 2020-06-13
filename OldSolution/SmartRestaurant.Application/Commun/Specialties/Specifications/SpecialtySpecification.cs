using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SmartRestaurant.Application.Dishes.DishFamillies.Specifications
{
    public class SpecialitySpecification : BaseSpecification<Speciality>
    {
        
        public SpecialitySpecification()
        {            
        }

        public SpecialitySpecification(Expression<Func<Speciality, bool>> expression) : base(expression)
        {           
        }
    }
}
