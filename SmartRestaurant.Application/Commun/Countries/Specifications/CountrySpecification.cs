using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SmartRestaurant.Application.Commun.Countries.Specifications
{
    public class CountrySpecification : BaseSpecification<Country>
    {
        public CountrySpecification():base()
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
