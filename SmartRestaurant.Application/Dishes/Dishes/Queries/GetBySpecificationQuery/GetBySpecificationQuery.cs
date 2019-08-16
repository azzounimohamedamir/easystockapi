using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Dishes.Dishes.Queries.Models;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Domain.Enumerations;
using SmartRestaurant.Application.ApplicationDataBase.Extensions;

namespace SmartRestaurant.Application.Dishes.Dishes.Queries
{
    public interface IGetBySpecificationQuery
    {
        List<DishItemModel> Execute(ISpecification<Dish> specification);
        List<DishItemModel> Execute(ISpecification<Dish> specification, out int count);
    }
    public class GetBySpecificationQuery : IGetBySpecificationQuery
    {
        private readonly ISmartRestaurantDatabaseService db;
        private readonly ILoggerService<GetAllDishQuery> logger;
        private readonly INotifyService notify;
        private readonly IMailingService mailing;

        public GetBySpecificationQuery(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllDishQuery> logger,
            INotifyService notify,
            IMailingService mailing)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.notify = notify ?? throw new ArgumentNullException(nameof(notify));
            this.mailing = mailing ?? throw new ArgumentNullException(nameof(mailing));
        }

        public List<DishItemModel> Execute(ISpecification<Dish> specification)
        {
            try
            {
                var query = db.Dishes.Query(specification);
                return query
                    .Select(DishItemModel.Projection)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DishItemModel> Execute(ISpecification<Dish> specification, out int count)
        {
            try
            {
                var query = db.Dishes.Query(specification);
                count = query.Count();
                return query
                    .Skip(specification.Skip)
                    .Take(specification.Take)
                    .Select(DishItemModel.Projection)
                    .ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
