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

namespace SmartRestaurant.Application.Dishes.Dishes.Queries
{
    public interface IGetAllByTypeQuery
    {
        IEnumerable<DishItemModel> Execute(EnumDishType type);
    }
    public class GetAllByTypeQuery : IGetAllByTypeQuery
    {
        private readonly ISmartRestaurantDatabaseService db;
        private readonly ILoggerService<GetAllDishQuery> logger;
        private readonly INotifyService notify;
        private readonly IMailingService mailing;

        public GetAllByTypeQuery(
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

        public IEnumerable<DishItemModel> Execute(EnumDishType type)
        {
            try
            {
                return db.Dishes
                    .Include(d => d.Family)
                    .Include(d => d.Restaurant)
                    .Where(d=>d.Type==type)
                    .Select(DishItemModel.Projection)                    
                    .AsEnumerable();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
