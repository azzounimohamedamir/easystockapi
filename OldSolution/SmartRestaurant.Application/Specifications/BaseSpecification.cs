using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SmartRestaurant.Application.Specifications
{
    public abstract class BaseSpecification<T> :ISpecification<T> where T: SmartRestaurantEntity
    {
        public BaseSpecification()
        {
            Criteria = new BaseCriteria<T>();
        }

        public BaseSpecification(Expression<Func<T, bool>> expression):this()
        {           
            Criteria.Expression = expression;
        }

       

        public ICriteria<T> Criteria { get; private set; }

        public List<Expression<Func<T, object>>> Includes { get; private set; } = new List<Expression<Func<T, object>>>();

        public List<string> IncludeStrings { get; private set; } = new List<string>();

        public Expression<Func<T, object>> OrderBy { get; private set; }

        public Expression<Func<T, object>> OrderByDescending { get; private set; }

        public int Skip { get; private set; }

        public int Take { get; private set; }        

        public bool IsPagingEnabled { get; private set; }

       // public Func<T, object> Selects { get; private set; }

        public BaseSpecification<T> AddInclude(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
            return this;
        }
        public BaseSpecification<T> RemoveAllInclude()
        {
            Includes = new List<Expression<Func<T, object>>>();
            return this;
        }

        public BaseSpecification<T> AddStringInclude(string include)
        {
            IncludeStrings.Add(include);
            return this;
        }

        public BaseSpecification<T> ApplyPagination(int skip,int take)
        {
            IsPagingEnabled = true;
            Skip = skip;
            Take = take;
            return this;
        }

        public BaseSpecification<T> ApplyOrderBy(Func<T, object> orderBy)
        {
            //swith and convert object to type then apply orderby.....
            return this;
        }

        public BaseSpecification<T> ApplyOrderByDescending(Func<T, object> orderBy)
        {
            //swith and convert object to type then apply orderby.....
            return this;
        }
    }
       
}
