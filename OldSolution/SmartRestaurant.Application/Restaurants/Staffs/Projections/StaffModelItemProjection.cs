using SmartRestaurant.Application.Restaurants.Staffs.Queries;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Staffs.Projections
{
    public static class StaffItemModelProjection
    {
        public static Expression<Func<Staff, StaffItemModel>> Projection
        {
            get
            {
                return x => new StaffItemModel()
                {
                    Id = x.Id.ToString(), 
                    FirstName=x.FirstName,
                    LastName=x.LastName,
                    RestaurantName=x.Restaurant!=null? x.Restaurant.Name:null,
                    Alias = x.Alias,
                };
            }
        }


    }
}
