using SmartRestaurant.Domain.Commun;
using System;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Interfaces
{
    public interface ICriteria<T> where T : SmartRestaurantEntity
    {
        Expression<Func<T, bool>> Expression { get; set; }
    }
}
