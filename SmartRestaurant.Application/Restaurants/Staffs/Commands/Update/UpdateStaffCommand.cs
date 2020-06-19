using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Restaurants.Staffs.Commands.Create;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Staffs.Commands.Update
{


    public interface IUpdateStaffCommand
    {
        void Execute(UpdateStaffModel model);
    }

    public class UpdateStaffCommand : IUpdateStaffCommand
    {
        private readonly ILoggerService<UpdateStaffCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateStaffCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateStaffCommand> log, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateStaffModel model)
        {
            try
            {
                var validator = new UpdateStaffCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var idGuid = model.Id.ToGuid();
                var staff = db.Staffs.FirstOrDefault(x => x.Id == idGuid);
                if (staff == null)
                {
                    throw new NotFoundException(nameof(Staff) + model.Id);
                }
                model.ToEntity(ref staff);

                db.Staffs.Update(staff);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
