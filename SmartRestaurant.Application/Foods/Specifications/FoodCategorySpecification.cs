using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Foods;
using System;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Foods.Specifications
{
    /// <summary>
    /// Classe de base pour filtrer dans la table FoodCategories
    /// Par défaut le filtre includ Picture
    /// </summary>
    public class FoodCategorySpecification : BaseSpecification<FoodCategory>
    {

        public FoodCategorySpecification() : base()
        {
            BaseInclude();
        }

        public FoodCategorySpecification(Expression<Func<FoodCategory, bool>> expression) : base(expression)
        {
            BaseInclude();
        }

        private void BaseInclude()
        {
            AddInclude(x => x.Picture);
        }
    }
}
