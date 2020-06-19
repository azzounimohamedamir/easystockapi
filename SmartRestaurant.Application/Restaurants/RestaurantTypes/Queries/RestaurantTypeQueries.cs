using SmartRestaurant.Application.Commun.Select;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries.GetById;
using SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries.GetBySpecification;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Restaurants.RestaurantTypes.Queries
{
    public interface IRestaurantTypeQueries
    {
        IGetRestaurantTypeByIdQuery GetById { get; }
        IGetRestaurantTypeBySpecificationQuery Filter { get; }
        IGetAllRestaurantTypesQuery List { get; }
        IEnumerable<SelectItemModel> SelectList();
        IEnumerable<SelectItemModel> SelectList(ISpecification<RestaurantType> specification);
    }

    public class RestaurantTypeQueries : IRestaurantTypeQueries
    {
        private readonly ILoggerService<RestaurantTypeQueries> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public RestaurantTypeQueries(
            ISmartRestaurantDatabaseService db,
            ILoggerService<RestaurantTypeQueries> logger,
            IMailingService mailing,
            INotifyService notify,
            IGetAllRestaurantTypesQuery all,
            IGetRestaurantTypeByIdQuery id,
            IGetRestaurantTypeBySpecificationQuery getRestaurantTypeBySpecificationQuery
            )
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mailing = mailing ?? throw new ArgumentNullException(nameof(mailing));
            this.notify = notify ?? throw new ArgumentNullException(nameof(notify));
            Filter = getRestaurantTypeBySpecificationQuery ?? throw new ArgumentNullException(nameof(getRestaurantTypeBySpecificationQuery));
            List = all ?? throw new ArgumentNullException(nameof(getRestaurantTypeBySpecificationQuery));
            GetById = id ?? throw new ArgumentNullException(nameof(getRestaurantTypeBySpecificationQuery));
        }


        public IGetRestaurantTypeBySpecificationQuery Filter { get; private set; }

        public IGetRestaurantTypeByIdQuery GetById { get; private set; }

        public IGetAllRestaurantTypesQuery List { get; private set; }

        public IEnumerable<SelectItemModel> SelectList()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<SelectItemModel> SelectList(ISpecification<RestaurantType> specification)
        {
            throw new NotImplementedException();
        }
    }
}
