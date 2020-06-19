using SmartRestaurant.Application.FoodCategories.Commands;
using SmartRestaurant.Application.FoodCategories.Commands.Delete;
using SmartRestaurant.Application.FoodCategories.Commands.Update;
using SmartRestaurant.Application.Foods.FoodCategories.Queries;
using SmartRestaurant.Application.Interfaces;
using System;

namespace SmartRestaurant.Application.FoodCategories.Services
{
    public class FoodCategoryService : IFoodCategoryService
    {
        private readonly ILoggerService<FoodCategoryService> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public FoodCategoryService(
            ISmartRestaurantDatabaseService db,
            ILoggerService<FoodCategoryService> logger,
            IMailingService mailing,
            INotifyService notify,
            ICreateFoodCategoryCommand create,
            IUpdateFoodCategoryCommand update,
            IDeleteFoodCatergoryCommand delete,
            IFoodCategoryQueries queries
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

        public ICreateFoodCategoryCommand Create { get; private set; }

        public IUpdateFoodCategoryCommand Update { get; private set; }

        public IDeleteFoodCatergoryCommand Delete { get; private set; }

        public IFoodCategoryQueries Queries { get; private set; }

    }
}
