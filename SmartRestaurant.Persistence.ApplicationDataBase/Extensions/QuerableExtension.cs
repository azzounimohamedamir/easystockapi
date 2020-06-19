using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System.Linq;

namespace SmartRestaurant.Persistence.ApplicationDataBase.Extensions
{
    public static class QuerableExtension<T> where T : SmartRestaurantEntity
    {
        public static IQueryable<T> ApplySpecification(IQueryable<T> query, ISpecification<T> specification)
        {
            //application des critaires
            if (specification.Criteria != null)
            {
                query = ApplyCriteria(query, specification.Criteria);
            }
            //application des includes
            query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

            //application des includes strings
            query = specification.IncludeStrings.Aggregate(query, (current, include) => current.Include(include));

            //application d'ordre
            if (specification.OrderBy != null)
            {
                query = query.OrderBy(specification.OrderBy);
            }
            else if (specification.OrderByDescending != null)
            {
                query = query.OrderByDescending(specification.OrderByDescending);
            }
            //application de la pagination
            if (specification.IsPagingEnabled)
            {
                query = query.Skip(specification.Skip).Take(specification.Take);
            }
            return query;
        }

        public static IQueryable<T> ApplyCriteria(IQueryable<T> query, ICriteria<T> criteria)
        {
            query = query.Where(criteria.Expression);
            return query;
        }
    }


}
