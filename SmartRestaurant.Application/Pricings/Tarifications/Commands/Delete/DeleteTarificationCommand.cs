using Helpers;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Pricings.Tarifications.Commands.Delete
{


    public interface IDeleteTarificationCommand
    {
        void Execute(DeleteTarificationModel model);
    }

    public class DeleteTarificationCommand : IDeleteTarificationCommand
    {
        private readonly ILoggerService<DeleteTarificationCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteTarificationCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteTarificationCommand> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteTarificationModel model)
        {
            try
            {
                var tarif = db.Tarifications.FirstOrDefault(x => x.Id == model.Id.ToGuid());
                if (tarif == null)
                {
                    throw new NotFoundException(nameof(tarif) + model.Id);
                }

                db.Tarifications.Remove(tarif);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
