using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Create;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Delete;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Commands.Update;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries;
using System;

namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Services
{
    public interface IRestaurantTypeService
    {
        ICreateRestaurantTypeCommand Create { get; }
        IUpdateRestaurantTypeCommand Update { get; }
        IDeleteRestaurantTypeCommand Delete { get; }
        IRestaurantTypeQueries Queries { get; }
    }

    public class RestaurantTypeService : IRestaurantTypeService
    {
        private readonly ILoggerService<RestaurantTypeService> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public RestaurantTypeService(
            ISmartRestaurantDatabaseService db,
            ILoggerService<RestaurantTypeService> logger,
            IMailingService mailing,
            INotifyService notify,
            ICreateRestaurantTypeCommand create,
            IUpdateRestaurantTypeCommand update,
            IDeleteRestaurantTypeCommand delete,
            IRestaurantTypeQueries queries
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

        public ICreateRestaurantTypeCommand Create { get; private set; }

        public IUpdateRestaurantTypeCommand Update { get; private set; }

        public IDeleteRestaurantTypeCommand Delete { get; private set; }

        public IRestaurantTypeQueries Queries { get; private set; }
    }
}
