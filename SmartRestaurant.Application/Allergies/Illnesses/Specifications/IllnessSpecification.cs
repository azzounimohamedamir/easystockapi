using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Allergies;
using System;
using System.Linq.Expressions;

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
