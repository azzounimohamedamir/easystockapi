using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Staffs.Queries.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Staffs.Queries.GetAll
{


    public interface IGetAllStaffsQuery
    {
        List<StaffItemModel> Execute();
    }
    public class GetAllStaffsQuery : IGetAllStaffsQuery
    {
        private readonly ILoggerService<IGetAllStaffsQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllStaffsQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<IGetAllStaffsQuery> log, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public List<StaffItemModel> Execute()
        {
            try
            {
                return db.Staffs.ToStaffItemModels();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
