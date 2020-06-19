using SmartRestaurant.Application.Foods.Foods.Queries.GetByCategoryId;
using SmartRestaurant.Application.Foods.Queries.GetAll;
using SmartRestaurant.Application.Foods.Queries.GetById;
using SmartRestaurant.Application.Foods.Queries.GetBySpecification;
using SmartRestaurant.Application.Interfaces;
using System;

namespace SmartRestaurant.Application.Foods.Queries
{
    public class FoodQueries : IFoodQueries
    {
        private readonly ILoggerService<FoodQueries> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public FoodQueries(
            ISmartRestaurantDatabaseService db,
            ILoggerService<FoodQueries> logger,
            IMailingService mailing,
            INotifyService notify,
            IGetFoodByIdQuery getFoodByIdQuery,
            IGetFoodsByCategoryIdQuery getFoodsByCategory,
            IGetAllFoodsQuery getAllFoodsQuery,
            IGetFoodBySpecificationQuery getFoodBySpecificationQuery
            )
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mailing = mailing ?? throw new ArgumentNullException(nameof(mailing));
            this.notify = notify ?? throw new ArgumentNullException(nameof(notify));

            GetById = getFoodByIdQuery ?? throw new ArgumentNullException(nameof(getFoodByIdQuery));
            GetListByCategoryId = getFoodsByCategory;
            List = getAllFoodsQuery ?? throw new ArgumentNullException(nameof(getAllFoodsQuery));
            Filter = getFoodBySpecificationQuery ?? throw new ArgumentNullException(nameof(getFoodBySpecificationQuery));
        }

        public IGetFoodByIdQuery GetById { get; private set; }

        public IGetFoodsByCategoryIdQuery GetListByCategoryId { get; private set; }

        public IGetAllFoodsQuery List { get; private set; }

        public IGetFoodBySpecificationQuery Filter { get; private set; }
    }
}
