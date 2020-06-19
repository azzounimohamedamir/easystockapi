using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Commun.State.Commands.Create;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Commun.States.Queries.GetStateById
{


    public interface IGetStateByIdQuerie
    {
        UpdateStateModel Execute(string Id);
    }
    public class GetStateByIdQuerie : IGetStateByIdQuerie
    {
        private readonly ILoggerService<GetStateByIdQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetStateByIdQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetStateByIdQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateStateModel Execute(string Id)
        {
            var entity = db.States.
                Where(p => p.Id == Id)
                .Include(p => p.Country)
                .Select(p => new UpdateStateModel()
                {
                    Id = p.Id,
                    CountryId = p.CountryId,
                    CountryIsoCode = p.Country.IsoCode,
                    CountryName = p.Country.Name,
                    IsoCode = p.IsoCode,
                    Name = p.Name,
                    Alias = p.Alias,
                    IsDisabled = p.IsDisabled,

                }

                ).FirstOrDefault();


            return entity; 
        }
    }

}
