using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SmartRestaurant.Application.Notifications.Specifications
{
    public class NotificationSpecification : BaseSpecification<Notification>
    {

        public NotificationSpecification():base()
        {

        }

        public NotificationSpecification(Expression<Func<Notification, bool>> expression) :base(expression)
        {

        }
    }
}
