using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Create;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Owners.Commands.Update;
using SmartRestaurant.Application.Restaurants.Owners.Queries;
using System;

namespace SmartRestaurant.Application.Restaurants.Owners.Services
{
    public interface IOwnerService
    {
        ICreateOwnerCommand Create { get; }
        IUpdateOwnerCommand Update { get; }
        IDeleteOwnerCommand Delete { get; }
        IOwnerQueries Queries { get; }
    }
    public class OwnerService : IOwnerService
    {
        private readonly ILoggerService<OwnerService> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public OwnerService(
            ISmartRestaurantDatabaseService db,
            ILoggerService<OwnerService> logger,
            IMailingService mailing,
            INotifyService notify,
            ICreateOwnerCommand create,
            IUpdateOwnerCommand update,
            IDeleteOwnerCommand delete,
            IOwnerQueries queries
            )
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mailing = mailing ?? throw new ArgumentNullException(nameof(mailing));
            this.notify = notify ?? throw new ArgumentNullException(nameof(notify));
            Create = create ?? throw new ArgumentNullException(nameof(create));
            Update = update ?? throw new ArgumentNullException(nameof(update));
            Delete = delete ?? throw new ArgumentNullException(nameof(delete));
            Queries = queries ?? throw new ArgumentNullException(nameof(queries));
        }

        public ICreateOwnerCommand Create { get; private set; }

        public IUpdateOwnerCommand Update { get; private set; }

        public IDeleteOwnerCommand Delete { get; private set; }

        public IOwnerQueries Queries { get; private set; }
    }
}
