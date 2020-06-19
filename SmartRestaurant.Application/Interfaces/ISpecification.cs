using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Interfaces
{
    public interface ISpecification<T> where T : SmartRestaurantEntity
    {
        /// <summary>
        /// Les critèires de select dans les tables
        /// Exemple where x=20 and name='xxxxxx'
        /// </summary>
        ICriteria<T> Criteria { get; }
        List<Expression<Func<T, object>>> Includes { get; }
        /// <summary>
        /// Include("Parent.Childs")
        /// </summary>
        List<string> IncludeStrings { get; }

        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, Object>> OrderByDescending { get; }

        int Skip { get; }
        int Take { get; }
        bool IsPagingEnabled { get; }


        //Func<T, object> Selects { get; }
    }
}
