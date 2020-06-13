using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Application.Restaurants.Tables.Commands.Delete
{


    public interface IDeleteTableCommand
    {
        void Execute(DeleteTableModel model);
    }

    public class DeleteTableCommand : IDeleteTableCommand
    {
        private readonly ILoggerService<DeleteTableCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteTableCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteTableCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteTableModel model)
        {
            try
            {
                var validator = new DeleteTableCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var guid = model.Id.ToGuid();
                var table = db.Tables.FirstOrDefault(x => x.Id == guid);
                if (table == null)
                {
                    throw new NotFoundException(nameof(Table) + model.Id);
                }

                db.Tables.Remove(table);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
