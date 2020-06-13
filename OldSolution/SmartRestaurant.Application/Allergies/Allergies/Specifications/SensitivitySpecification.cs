using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Allergies;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SmartRestaurant.Application.Allergies.Allergies.Specifications
{
    public class AllergySpecification : BaseSpecification<Allergy>
    {
        public AllergySpecification() : base()
        {
            //AddInclude(x => x.FoodAllergies);
        }
        public AllergySpecification(Expression<Func<Allergy, bool>> expression) : base(expression) 
        {
            
        }
    }
}
