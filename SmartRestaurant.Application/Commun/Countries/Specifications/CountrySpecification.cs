using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Commun;
using System;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Commun.Countries.Specifications
{
    public class CountrySpecification : BaseSpecification<Country>
    {
        public CountrySpecification() : base()
        {

        }
        public CountrySpecification(Expression<Func<Country, bool>> expression) : base(expression)
        {

        }

        //public CountrySpecification(
        //    Expression<Func<Country, bool>> expression, 
        //    Func<Country, object> selects
        //    ) : base(expression,selects)
        //{

        //}
    }
}
