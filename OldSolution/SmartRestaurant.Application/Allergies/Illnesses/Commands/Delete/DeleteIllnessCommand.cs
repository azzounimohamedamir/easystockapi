using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Allergies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;

namespace SmartRestaurant.Application.Allergies.Illnesses.Commands.Delete
{


    public interface IDeleteIllnessCommand
    {
        void Execute(DeleteIllnessModel model);
    }

    public class DeleteIllnessCommand : IDeleteIllnessCommand
    {
        private readonly ILoggerService<DeleteIllnessCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteIllnessCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteIllnessCommand> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteIllnessModel model)
        {
            try
            {
                var illnes = db.Illnesses.FirstOrDefault(x => x.Id == model.Id.ToGuid());
                if (illnes == null)
                {
                    throw new NotFoundException(nameof(Illness) + model.Id);
                }

                db.Illnesses.Remove(illnes);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
