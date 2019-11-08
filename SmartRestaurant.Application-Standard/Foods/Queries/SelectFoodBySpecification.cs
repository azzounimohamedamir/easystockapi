using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;

namespace SmartRestaurant.Application.Foods.Queries
{
    public class SelectFoodBySpecification : ISelectFoodBySpecification
    {
        private readonly ISmartRestaurantDatabaseService _database;

        public SelectFoodBySpecification(ISmartRestaurantDatabaseService database)
        {
            _database = database;
        }
        //public IEnumerable<FoodListModel> Execute(FoodSpecification specification)
        //{
        //   // _database.Aliments.Where(specification).ToList();
        //}

        public IEnumerable<FoodListModel> Execute(ISepecification specification)
        {
            throw new NotImplementedException();
        }
    }

    public class Test
    {
        //SelectFoodBySpecification s = new SelectFoodBySpecification();
        //void ttt()
        //{
        //    Guid _guid = Guid.NewGuid();
        //    s.Execute(new FoodSpecification(f => f.Alias=="alias")
            
        //    );
        //}
    }

    public class FoodSpecification: Specification<Food>
    {
        public FoodSpecification(Expression<Func<Food, bool>> criteria) : base(criteria)
        {

        }
    }
}
