using SmartRestaurant.Application.Specifications;
using SmartRestaurant.Domain;
using System;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.Notifications.Specifications
{
    public class NotificationSpecification : BaseSpecification<Notification>
    {

        public NotificationSpecification() : base()
        {

        }

        public NotificationSpecification(Expression<Func<Notification, bool>> expression) : base(expression)
        {

        }
    }
}
