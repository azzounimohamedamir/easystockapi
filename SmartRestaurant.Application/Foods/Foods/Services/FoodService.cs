using SmartRestaurant.Application.Foods.Commands.Create;
using SmartRestaurant.Application.Foods.Commands.Delete;
using SmartRestaurant.Application.Foods.Commands.Update;
using SmartRestaurant.Application.Foods.Queries;
using SmartRestaurant.Application.Foods.Services;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Foods.Foods.Services
{
    public class FoodService : IFoodService
    {
        private readonly ILoggerService<FoodService> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public FoodService(
            ISmartRestaurantDatabaseService db,
            ILoggerService<FoodService> logger,
            IMailingService mailing,
            INotifyService notify,
            ICreateFoodCommand create,
            IUpdateFoodCommand update,
            IDeleteFoodCommand delete,
            IFoodQueries queries
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
        public ICreateFoodCommand Create { get; private set; }

        public IUpdateFoodCommand Update { get; private set; }

        public IDeleteFoodCommand Delete { get; private set; }

        public IFoodQueries Queries { get; private set; }
    }
}
