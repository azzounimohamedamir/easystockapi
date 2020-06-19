using SmartRestaurant.Application.Commun.Select;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Owners.Queries.GetAll;
using SmartRestaurant.Application.Restaurants.Owners.Queries.GetById;
using SmartRestaurant.Application.Restaurants.Owners.Queries.GetBySpecification;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Restaurants.Owners.Queries
{
    public interface IOwnerQueries
    {
        IGetOwnerBySpecificationQuery Filter { get; }
        IGetOwnerByIdQuery GetById { get; }
        IGetAllOwnersQuery List { get; }
        IEnumerable<SelectItemModel> SelectList();
        IEnumerable<SelectItemModel> SelectList(ISpecification<Owner> specification);
    }

    public class OwnerQueries : IOwnerQueries
    {
        private readonly ILoggerService<OwnerQueries> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public OwnerQueries(
            ISmartRestaurantDatabaseService db,
            ILoggerService<OwnerQueries> logger,
            IMailingService mailing,
            INotifyService notify,
            IGetAllOwnersQuery All,
            IGetOwnerByIdQuery byId,
            IGetOwnerBySpecificationQuery getOwnerBySpecificationQuery
            )
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.mailing = mailing ?? throw new ArgumentNullException(nameof(mailing));
            this.notify = notify ?? throw new ArgumentNullException(nameof(notify));
            Filter = getOwnerBySpecificationQuery ?? throw new ArgumentNullException(nameof(getOwnerBySpecificationQuery));
            GetById = byId ?? throw new ArgumentNullException(nameof(getOwnerBySpecificationQuery));
            List = All ?? throw new ArgumentNullException(nameof(getOwnerBySpecificationQuery));
        }


        public IGetOwnerBySpecificationQuery Filter { get; private set; }

        public IGetOwnerByIdQuery ById { get; private set; }

        public IGetOwnerByIdQuery GetById { get; private set; }

        public IGetAllOwnersQuery List { get; private set; }

        public IEnumerable<SelectItemModel> SelectList()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<SelectItemModel> SelectList(ISpecification<Owner> specification)
        {
            throw new NotImplementedException();
        }
    }
}
