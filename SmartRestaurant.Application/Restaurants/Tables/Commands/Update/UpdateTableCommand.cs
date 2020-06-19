using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Domain.Restaurants;
using SmartRestaurant.Application.Restaurants.Tables.Commands.Create;

namespace SmartRestaurant.Application.Restaurants.Tables.Commands.Update
{


    public interface IUpdateTableCommand
    {
        void Execute(UpdateTableModel model);
    }

    public class UpdateTableCommand : IUpdateTableCommand
    {
        private readonly ILoggerService<UpdateTableCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public UpdateTableCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<UpdateTableCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(UpdateTableModel model)
        {
            try
            {
                var validator = new UpdateTableCommandValidation();
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

                var areaGuid = model.AreaId.ToGuid();
                if (!db.Areas.Any(x => x.Id == areaGuid))
                {
                    throw new NotFoundException(nameof(Area) + model.AreaId);
                }

                model.ToEntity(ref table);

                db.Tables.Add(table);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
