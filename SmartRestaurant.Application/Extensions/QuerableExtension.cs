using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.ApplicationDataBase.Extensions
{
    public static class QuerableExtension//<T> where T : SmartRestaurantEntity
    {
        //[Obsolete("Cettte méthode sera supprimer dans la version suivante, utiliser Filter")]

        public static IQueryable<T> ApplySpecification<T>(this IQueryable<T> query, ISpecification<T> specification) where T : SmartRestaurantEntity
        {
            //application des critèires de select
            if (specification.Criteria != null && specification.Criteria.Expression != null)
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
            return query;
        }

        public static IQueryable<T> Query<T>(this IQueryable<T> query, ISpecification<T> specification) where T : SmartRestaurantEntity
        {
            //application des critèires de select
            if (specification.Criteria != null && specification.Criteria.Expression != null)
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
            return query;
        }

        public static IEnumerable<T> Filter<T>(this DbSet<T> dbSet, ISpecification<T> specification) where T : SmartRestaurantEntity
        {
            return dbSet
                .AsQueryable()
                .ApplySpecification(specification)
                .AsEnumerable();
        }

        public static IQueryable<T> ApplyCriteria<T>(IQueryable<T> query, ICriteria<T> criteria) where T : SmartRestaurantEntity
        {
            if (criteria == null) return query;
            query = query.Where(criteria.Expression);
            return query;
        }
    }


}
