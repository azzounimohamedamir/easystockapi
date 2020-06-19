using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmartRestaurant.Application.Allergies.Allergies.Queries.GetAll
{


    public interface IGetAllAllergiesQuery
    {
        IEnumerable<AllergyItemModel> Execute();
    }
    public class GetAllAllergiesQuery : IGetAllAllergiesQuery
    {
        private readonly ILoggerService<GetAllAllergiesQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllAllergiesQuery(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllAllergiesQuery> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }

        public IEnumerable<AllergyItemModel> Execute()
        {
            try
            {
                return db.Allergies
                    .Select(x => new AllergyItemModel
                    {
                        Description = x.Description,
                        Name = x.Name,
                        Id = x.Id.ToString(),
                        IsDisabled = x.IsDisabled.DisabledDisplay(),
                        SlugUrl = x.SlugUrl
                    });
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
