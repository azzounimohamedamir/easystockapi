using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Dishes.Dishes.Queries.Models;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Dishes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Dishes.Dishes.Queries
{
    public interface IGetAllDishQuery
    {
        List<DishItemModel> Execute();
        List<DishItemModel> Execute(out int count, int skip, int take);
    }
    public class GetAllDishQuery : IGetAllDishQuery
    {
        private readonly ISmartRestaurantDatabaseService db;
        private readonly ILoggerService<GetAllDishQuery> logger;
        private readonly INotifyService notify;
        private readonly IMailingService mailing;

        public GetAllDishQuery(
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

        private IQueryable<Dish> GetQuery()
        {
            return db.Dishes
                    .Include(d => d.Family)
                    .Include(d => d.Restaurant)
                    .Include(d => d.Gallery)
                    .Include(d => d.Gallery.Pictures)
                    .AsQueryable();
        }
        public List<DishItemModel> Execute(out int count, int skip, int take)
        {
            try
            {
                var query = GetQuery();
                count = query.Count();
                return query.Skip(skip).Take(take)
                    .Select(DishItemModel.Projection)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DishItemModel> Execute()
        {
            try
            {
                return GetQuery()
                    .Select(DishItemModel.Projection)
                    .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
