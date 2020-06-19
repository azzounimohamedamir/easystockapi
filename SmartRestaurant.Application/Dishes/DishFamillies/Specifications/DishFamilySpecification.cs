using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Dishes;
using System;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Dishes.DishFamillies.Specifications
{
    public class DishFamilySpecification : BaseSpecification<DishFamily>
    {
        private void DefaultInclude()
        {

            AddInclude(df => df.Picture);
        }
        public DishFamilySpecification()
        {
            DefaultInclude();
        }

        public DishFamilySpecification(Expression<Func<DishFamily, bool>> expression) : base(expression)
        {
            DefaultInclude();
        }


    }
}
