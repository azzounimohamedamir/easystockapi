using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Staffs.Commands.Create;
using SmartRestaurant.Application.Restaurants.Staffs.Commands.Delete;
using SmartRestaurant.Application.Restaurants.Staffs.Commands.Update;
using SmartRestaurant.Application.Restaurants.Staffs.Queries;
using System;

namespace SmartRestaurant.Application.Restaurants.Staffs.Services
{
    public interface IStaffService
    {
        ICreateStaffCommand Create { get; }
        IUpdateStaffCommand Update { get; }
        IDeleteStaffCommand Delete { get; }
        IStaffQueries Queries { get; }
    }

    public class StaffService : IStaffService
    {
        private readonly ILoggerService<StaffService> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public StaffService(
            ISmartRestaurantDatabaseService db,
            ILoggerService<StaffService> logger,
            IMailingService mailing,
            INotifyService notify,
            ICreateStaffCommand create,
            IUpdateStaffCommand update,
            IDeleteStaffCommand delete,
            IStaffQueries queries
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

        public ICreateStaffCommand Create { get; private set; }

        public IUpdateStaffCommand Update { get; private set; }

        public IDeleteStaffCommand Delete { get; private set; }

        public IStaffQueries Queries { get; private set; }
    }
}
