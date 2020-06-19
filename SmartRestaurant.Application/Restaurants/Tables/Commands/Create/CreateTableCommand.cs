using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Restaurants;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Restaurants.Tables.Commands.Create
{


    public interface ICreateTableCommand
    {
        void Execute(CreateTableModel model);
    }

    public class CreateTableCommand : ICreateTableCommand
    {
        private readonly ILoggerService<CreateTableCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateTableCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateTableCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(CreateTableModel model)
        {
            try
            {
                var validator = new CreateTableCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {
                    throw new NotValidException(result.Errors);
                }

                var areaGuid = model.AreaId.ToGuid();
                if (!db.Areas.Any(x => x.Id == areaGuid))
                {
                    throw new NotFoundException(nameof(Area) + model.AreaId);
                }

                var table = model.ToEntity();

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
