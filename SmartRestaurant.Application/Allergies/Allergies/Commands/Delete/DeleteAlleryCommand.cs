using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Allergies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.Allergies.Allergies.Commands.Delete
{
    public interface IDeleteAllergyCommand
    {
        void Execute(DeleteAllergyModel model);
    }

    public class DeleteAllergyCommand : IDeleteAllergyCommand
    {
        private readonly ILoggerService<DeleteAllergyCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteAllergyCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteAllergyCommand> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteAllergyModel model)
        {
            try
            {
                var Allergy = db.Allergies.FirstOrDefault(x => x.Id == model.Id.ToGuid());
                if (Allergy == null)
                {
                    throw new NotFoundException(nameof(Allergy) + model.Id);
                }

                db.Allergies.Remove(Allergy);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
