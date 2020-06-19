using Helpers;
using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Foods;
using System;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Foods.Specifications
{
    /// <summary>
    /// Classe de base pour filtrer dans la table Foods
    /// Par défaut le filtre includ Picture
    /// </summary>
    public class FoodSpecification : BaseSpecification<Food>
    {

        public FoodSpecification() : base()
        {
            BaseInclude();
        }

        public FoodSpecification(string categoryId, string name)
            : base(
                  food => (!string.IsNullOrEmpty(categoryId) ? food.FoodCategoryId.Equals(categoryId.ToGuid())
                  || food.Category.ParentId.Equals(categoryId.ToGuid())
                  || food.Category.Parent.ParentId.Equals(categoryId.ToGuid())
                  || food.Category.Parent.Parent.ParentId.Equals(categoryId.ToGuid())
                  || food.Category.Parent.Parent.Parent.ParentId.Equals(categoryId.ToGuid())
                  || food.Category.Parent.Parent.Parent.Parent.ParentId.Equals(categoryId.ToGuid()) : true)
                  && (!string.IsNullOrEmpty(name) ? food.Name.Contains(name) : true)
                )
        {
            BaseInclude();
        }
        public FoodSpecification(Expression<Func<Food, bool>> expression) : base(expression)
        {
            BaseInclude();
        }

        private void BaseInclude()
        {
            AddInclude(x => x.Category);
            AddInclude(x => x.Picture);
            AddInclude(x => x.Unit);
        }
    }
}
