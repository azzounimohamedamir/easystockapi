using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using SmartRestaurant.Domain.Commun;
using System.Linq;
using Helpers;
using Microsoft.EntityFrameworkCore;

namespace SmartRestaurant.Application.Commun.Countries.Commands.Update
{
    public class UpdateCountryCommand : IUpdateCountryCommand
    {
        private ISmartRestaurantDatabaseService _db;
        private INotifyService _notify;
        private IMailingService _mailing;
        private ILoggerService<UpdateCountryCommand> _log;

        public UpdateCountryCommand(
              ISmartRestaurantDatabaseService database,
              INotifyService notify,
              IMailingService mailing,
              ILoggerService<UpdateCountryCommand> log)
        {
            _db = database ?? throw new ArgumentNullException(nameof(database));
            _notify = notify;
            _mailing = mailing;
            _log = log;
        }


        public void Execute(UpdateCountryModel model)
        {
            try
            {
                
                var validator = new UpdateCountryCommandValidation();
                var result = validator.Validate(model);
                if (!result.IsValid)
                {

                    throw new NotValidException(result.Errors);
                }
                var entity = _db.Countries
                    .Include(c=> c.Currencies)
                    .FirstOrDefault(c=>c.Id==model.Id);

                if (entity.ToString().IsNullOrEmpty())
                {
                    throw new NotFoundException("Coutntry : " + model.Id);
                }

                entity.IsoCode = model.IsoCode;
                entity.Name = model.Name;
                entity.Id = model.Id;
                entity.Alias = model.Alias;
                entity.IsDisabled = model.IsDisabled;
                //in db
                HashSet<string> idsDB = new HashSet<string>(entity.Currencies.Select(i => i.CurrencyId.ToString()));
                //if not null CurrenciesId
                HashSet<string> idsMODEL = new HashSet<string>(model.CurrenciesId);

                foreach(string s in idsDB)
                {
                    if (!idsMODEL.Contains(s))
                    {
                        //Delete
                        var item = entity.Currencies.FirstOrDefault(i => i.CurrencyId == s.ToGuid());
                        entity.Currencies.Remove(item);
                    }
                }
                foreach(string s in idsMODEL)
                {
                    //Add
                    if (!idsDB.Contains(s))
                    {
                        entity.Currencies.Add(
                            new CountryCurrency
                            {
                                CurrencyId=s.ToGuid(),
                            }
                            );
                    }
                    
                }

                _db.Countries.Update(entity);
                _db.Save();
            }
            catch (Exception)
            {


            }




        }
    }
}
