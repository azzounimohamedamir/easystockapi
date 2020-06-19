using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Commun;
using System;
using System.Linq.Expressions;

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
