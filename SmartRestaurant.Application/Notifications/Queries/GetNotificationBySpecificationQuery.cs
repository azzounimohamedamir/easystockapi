using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Commun.Countries.Queries;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Notifications.Commands.Factory;
using SmartRestaurant.Application.Notifications.Queries;
using SmartRestaurant.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Notifications.Services
{
    public  interface IGetNotificationBySpecificationQuery
    {
        List<NotificationItemModel> Execute(ISpecification<Notification> specifications);
    }

    public class GetNotificationBySpecificationQuery : IGetNotificationBySpecificationQuery
    {
        private readonly ISmartRestaurantDatabaseService _db;
        private readonly INotifyService _notify;
        private readonly IMailingService _mailing;
        private readonly ILoggerService<GetNotificationBySpecificationQuery> _log;

        public GetNotificationBySpecificationQuery(
            ISmartRestaurantDatabaseService db,
            INotifyService notify,
            IMailingService mailing,
            ILoggerService<GetNotificationBySpecificationQuery> log
            )
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _notify = notify;
            _mailing = mailing;
            _log = log;

        }

        public List<NotificationItemModel> Execute(
            ISpecification<Notification> specifications) =>
                _db.Notifications
                .AsQueryable()
                .ApplySpecification(specifications)
                .ToNotificationItemModels();
    }
}