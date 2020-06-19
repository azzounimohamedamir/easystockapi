using SmartRestaurant.Application.Commun.Select;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Notifications.Queries.GetNotificationById;
using SmartRestaurant.Application.Notifications.Queries.GetNotificationItems;
using SmartRestaurant.Application.Notifications.Services;
using SmartRestaurant.Domain;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Notifications.Queries
{
    public interface INotificationQueries
    {
        IGetNotificationByIdQuerie GetById { get; }
        IGetNotificationItemsQuery List { get; }
        IGetNotificationBySpecificationQuery Filter { get; }

        IEnumerable<SelectItemModel> SelectList();
        IEnumerable<SelectItemModel> SelectList(ISpecification<Notification> specification);

    }
    public class NotificationQueries
    {
        private readonly ILoggerService<NotificationQueries> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public NotificationQueries(
            ISmartRestaurantDatabaseService db,
            ILoggerService<NotificationQueries> logger,
            IMailingService mailing,
            INotifyService notify,
            IGetNotificationByIdQuerie getNotificationByIdQuerie,
            IGetNotificationItemsQuery getNotificationItemsQuerie,
            IGetNotificationBySpecificationQuery getNotificationBySpecificationQuery
            )
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mailing = mailing ?? throw new ArgumentNullException(nameof(mailing));
            this.notify = notify ?? throw new ArgumentNullException(nameof(notify));
            GetById = getNotificationByIdQuerie ?? throw new ArgumentNullException(nameof(getNotificationByIdQuerie));
            List = getNotificationItemsQuerie ?? throw new ArgumentNullException(nameof(getNotificationItemsQuerie));
            Filter = getNotificationBySpecificationQuery ?? throw new ArgumentNullException(nameof(getNotificationBySpecificationQuery));
        }

        public IGetNotificationByIdQuerie GetById { get; private set; }

        public IGetNotificationItemsQuery List { get; private set; }

        public IGetNotificationBySpecificationQuery Filter { get; private set; }

        public IEnumerable<SelectItemModel> SelectList()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SelectItemModel> SelectList(ISpecification<Notification> specification)
        {
            throw new NotImplementedException();
        }

    }
}
