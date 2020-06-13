using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Domain.Restaurants;

namespace SmartRestaurant.Application.Restaurants.Chains.Commands.Delete
{


    public interface IDeleteChainCommand
    {
        void Execute(DeleteChainModel model);
    }

    public class DeleteChainCommand : IDeleteChainCommand
    {
        private readonly ILoggerService<DeleteChainCommand> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public DeleteChainCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<DeleteChainCommand> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(DeleteChainModel model)
        {
            try
            {
                var chain = db.Chains.FirstOrDefault(x => x.Id == model.Id.ToGuid());
                if (chain == null)
                    throw new NotFoundException(nameof(Chain) + ":" + model.Id);

                db.Chains.Remove(chain);
                db.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
