using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SmartRestaurant.Application.Interfaces
{
    public interface ISepecification
    {

    }

    public abstract class Specification<T> where T : SmartRestaurantEntity
    {
        private Expression<Func<T,bool>>  Criteria { get; }

        public Specification(Expression<Func<T, bool>> criteria)
        {
            Criteria = criteria;
        }
    }
}
