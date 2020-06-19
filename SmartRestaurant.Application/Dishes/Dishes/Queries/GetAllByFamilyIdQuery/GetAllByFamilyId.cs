using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Dishes.Dishes.Queries.Models;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SmartRestaurant.Application.Dishes.Dishes.Queries
{
    public interface IGetAllByFamilyIdQuery
    {
        IEnumerable<DishItemModel> Execute(string familyId);
    }
    public class GetAllByFamilyIdQuery : IGetAllByFamilyIdQuery
    {
        private readonly ISmartRestaurantDatabaseService db;
        private readonly ILoggerService<GetAllDishQuery> logger;
        private readonly INotifyService notify;
        private readonly IMailingService mailing;

        public GetAllByFamilyIdQuery(
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

        public IEnumerable<DishItemModel> Execute(string familyId)
        {
            try
            {
                return db.Dishes
                    .Include(d => d.Family)
                    .Include(d => d.Restaurant)
                    .Where(d => d.FamillyId == familyId.ToGuid())
                    .Select(DishItemModel.Projection)
                    .AsEnumerable();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
