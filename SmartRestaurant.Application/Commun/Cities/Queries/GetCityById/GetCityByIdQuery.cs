using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Commun.Cities.Commands.Update;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Commun.Cities.Queries.GetCityById
{



    public interface IGetCityByIdQuerie
    {
        UpdateCityModel Execute(string Id);
    }
    public class GetCityByIdQuerie : IGetCityByIdQuerie
    {
        private readonly ILoggerService<GetCityByIdQuerie> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetCityByIdQuerie(ISmartRestaurantDatabaseService db,
            ILoggerService<GetCityByIdQuerie> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateCityModel Execute(string Id)
        {
            var entity = db.Cities
                .Where(p => p.Id == Id)
                .Include(q => q.State)
               .Select(p => new UpdateCityModel()
               {
                   Id = p.Id,
                   StateId = p.StateId,
                   Alias = p.Alias , 
                   IsoCode = p.IsoCode,
                   Name = p.Name,
                   CountryId = p.State.CountryId,
                   IsDisabled = p.IsDisabled,
                   

               })
                .FirstOrDefault();
            return entity;

        }
    }




}
