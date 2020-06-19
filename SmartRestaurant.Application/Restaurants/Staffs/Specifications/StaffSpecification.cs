using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Staffs.Specifications
{
    public class StaffSpecification : BaseSpecification<Staff>
    {
        public StaffSpecification():base()
        {
            AddInclude(x => x.Restaurant);
            AddInclude(x => x.Address);
        }
        public StaffSpecification(Expression<Func<Staff, bool>> expression):base(expression)
        {
            AddInclude(x => x.Restaurant);
            AddInclude(x => x.Address);
        }

        //public StaffSpecification(
        //     Expression<Func<Staff, bool>> expression,
        //     Func<Staff, object> selects
        //     ) : base(expression, selects)
        //{

        //}
    }
}
