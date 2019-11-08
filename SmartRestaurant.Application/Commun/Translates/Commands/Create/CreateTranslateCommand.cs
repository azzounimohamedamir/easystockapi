using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Domain.Commun;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Domain.Pricings;
using SmartRestaurant.Application.Commun.Prices;
using SmartRestaurant.Application.Commun.Translates.Queries.GetByTableName;

namespace SmartRestaurant.Application.Commun.Translates.Commands.Create
{


    public interface ICreateTranslateCommand
    {
        void Execute(List<ItemTranslatesModel> model);
    }

    public class CreateTranslateCommand : ICreateTranslateCommand
    {
        private readonly ILoggerService<CreateTranslateCommand> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public CreateTranslateCommand(ISmartRestaurantDatabaseService db,
            ILoggerService<CreateTranslateCommand> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public void Execute(List<ItemTranslatesModel> model)
        {
            try
            {

                var tableName = model?.FirstOrDefault()?.TableName;
                if (tableName == null) return;

                var tableTranslates = db.Translates.Where(x => x.TableName == tableName).ToList();
                var languages = db.Languages.OrderBy(o => o.EnglishName).ToList();

               
                foreach (var translate in model)
                {
                    foreach (var text in translate.TextTraslations)
                    {

                        var dbTrans = tableTranslates
                        .FirstOrDefault(x => x.PrimaryKeyValue == translate.PrimaryKeyValue
                        && x.Language.IsoCode == text.Language.IsoCode && x.ColumnName == translate.ColumnName);

                        if (dbTrans != null)
                        {
                            dbTrans.Text = text.Text;
                            db.Save();
                        }
                        else
                        {
                            var newTrans = new Translate
                            {
                                Id = Guid.NewGuid(),
                                Text = text.Text,
                                TableName = translate.TableName,
                                PrimaryKeyValue = translate.PrimaryKeyValue,
                                LanguageId = text.Language.Id,
                                ColumnName = translate.ColumnName
                            };
                            db.Translates.Add(newTrans);
                            db.Save();
                        }
                    }
                }

              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
