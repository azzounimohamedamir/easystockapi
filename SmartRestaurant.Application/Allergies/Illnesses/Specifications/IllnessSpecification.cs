using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Allergies;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SmartRestaurant.Application.Allergies.Illnesses.Specifications
{
    public class IllnessSpecification : BaseSpecification<Illness>
    {
        public IllnessSpecification() : base()
        {

        }
        public IllnessSpecification(Expression<Func<Illness, bool>> expression) : base(expression)
        {
            
        }
    }
}
