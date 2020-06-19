using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Identity;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Enumerations;
using SmartRestaurant.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Restaurants.Staffs.Commands.Create
{


    public interface ICreateStaffCommand
    {
        void Execute(CreateStaffModel model);
    }

    public class CreateStaffCommand : ICreateStaffCommand
    {
        private readonly ILoggerService<CreateStaffCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateStaffCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateStaffCommand> log, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public async void Execute(CreateStaffModel model)
        {
            try
            {
                var validator = new CreateStaffCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var staff = model.ToEntity();

                db.Staffs.Add(staff);
                db.Save();
                ///TODO:Add Register for user and there roles 
                ///Default password and after login he could change it password 

                //TODO: Delete Guest and Developper Roles from Combobox 

                string pass = "A*a123456789";
                string baseurl = "http://192.168.1.10:12064/api";
                RegisterModel registerModel = new RegisterModel
                {
                    Username = staff.UserName,
                    FirstName = staff.FirstName,
                    LastName = staff.LastName,
                    Password = pass,
                    RoleName = staff.StaffRole.ToString(),
                };
                APIHelper api = new APIHelper(baseurl);
                await api.Post<string, RegisterModel>("account/register", registerModel);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
