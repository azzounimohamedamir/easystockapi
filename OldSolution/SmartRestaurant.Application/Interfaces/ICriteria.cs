using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SmartRestaurant.Application.Interfaces
{
    public interface ICriteria<T> where T : SmartRestaurantEntity
    {
        Expression<Func<T, bool>> Expression { get; set; }
    }
}
