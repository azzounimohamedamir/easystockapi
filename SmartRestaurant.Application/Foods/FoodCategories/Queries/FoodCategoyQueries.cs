using SmartRestaurant.Application.FoodCategories.Queries.GetAll;
using SmartRestaurant.Application.FoodCategories.Queries.GetById;
using SmartRestaurant.Application.Foods.FoodCategories.Queries.GetBySpecification;
using SmartRestaurant.Application.Interfaces;
using System;

namespace SmartRestaurant.Application.Foods.FoodCategories.Queries
{
    public interface IFoodCategoryQueries
    {
        IGetFoodCategoryByIdQuery GetById { get; }
        IGetAllFoodCategoriesQuery List { get; }
        IGetFoodCategoryBySpecificationQuery Filter { get; }

    }

    public class FoodCategoryQueries : IFoodCategoryQueries
    {
        private readonly ILoggerService<FoodCategoryQueries> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public FoodCategoryQueries(
            ISmartRestaurantDatabaseService db,
            ILoggerService<FoodCategoryQueries> logger,
            IMailingService mailing,
            INotifyService notify,
            IGetFoodCategoryByIdQuery getFoodCategoryByIdQuery,
            IGetAllFoodCategoriesQuery getAllFoodCategoriesQuery,
            IGetFoodCategoryBySpecificationQuery getFoodCategoryBySpecificationQuery
            )
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mailing = mailing ?? throw new ArgumentNullException(nameof(mailing));
            this.notify = notify ?? throw new ArgumentNullException(nameof(notify));
            GetById = getFoodCategoryByIdQuery ?? throw new ArgumentNullException(nameof(getFoodCategoryByIdQuery));
            List = getAllFoodCategoriesQuery ?? throw new ArgumentNullException(nameof(getAllFoodCategoriesQuery));
            Filter = getFoodCategoryBySpecificationQuery ?? throw new ArgumentNullException(nameof(getFoodCategoryBySpecificationQuery));
        }

        public IGetFoodCategoryByIdQuery GetById { get; private set; }

        public IGetAllFoodCategoriesQuery List { get; private set; }

        public IGetFoodCategoryBySpecificationQuery Filter { get; private set; }


    }
}
