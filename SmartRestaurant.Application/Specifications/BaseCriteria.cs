using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Specifications
{
    class BaseCriteria<T> : ICriteria<T> where T : SmartRestaurantEntity
    {
        public Expression<Func<T, bool>> Expression { get; set; }
    }
}
