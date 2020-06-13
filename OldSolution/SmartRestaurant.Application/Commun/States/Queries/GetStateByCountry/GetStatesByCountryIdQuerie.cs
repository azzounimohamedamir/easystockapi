using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Commun.States.Queries.GetStateByCountry
{



    public interface IGetStatesByCountryIdQuerie
    {
        List<UpdateStateModel> Execute(string Id);
    }
    public class GetStatesByCountryIdQuerie : IGetStatesByCountryIdQuerie
    {
        private readonly ILoggerService<GetStatesByCountryIdQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetStatesByCountryIdQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetStatesByCountryIdQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public List<UpdateStateModel> Execute(string Id)
        {
            var entity = db.States.
           Where(p => p.CountryId == Id)
           .Include(p => p.Country)
           .Select(p => new UpdateStateModel()
           {
               Id = p.Id,
               CountryId = p.CountryId,
               CountryIsoCode = p.Country.IsoCode,
               CountryName = p.Country.Name,
               IsoCode = p.IsoCode,
               Name = p.Name,
               Alias = p.Alias ,

           }

           ).ToList();


            return entity;


        }
    }



}
