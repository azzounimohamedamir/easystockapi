using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.Restaurants.Staffs.Commands.Delete
{


    public interface IDeleteStaffCommand
    {
        void Execute(DeleteStaffModel model);
    }

    public class DeleteStaffCommand : IDeleteStaffCommand
    {
        private readonly ILoggerService<DeleteStaffCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteStaffCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteStaffCommand> log, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteStaffModel model)
        {
            try
            {
                var validator = new DeleteStaffCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.Id.ToGuid();
                var staff = db.Staffs.FirstOrDefault(x => x.Id == guid);
                if (staff == null)
                {
                    throw new NotFoundException(nameof(Staff));
                }
                 
                db.Staffs.Remove(staff);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
