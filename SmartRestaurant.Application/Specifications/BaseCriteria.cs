using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SmartRestaurant.Application.Specifications
{
    class BaseCriteria<T> : ICriteria<T> where T : SmartRestaurantEntity
    {
        public Expression<Func<T, bool>> Expression { get; set; }
    }
}
