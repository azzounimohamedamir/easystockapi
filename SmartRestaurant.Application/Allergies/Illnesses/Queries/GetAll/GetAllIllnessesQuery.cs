using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Helpers;
using SmartRestaurant.Application.Allergies.Illnesses.Queries.Factory;
using SmartRestaurant.Application.Helpers;

namespace SmartRestaurant.Application.Allergies.Illnesses.Queries.GetAll
{
    public interface IGetAllIllnessesQuery
    {
        IEnumerable<IllnessItemModel> Execute();
    }
    public class GetAllIllnessesQuery : IGetAllIllnessesQuery
    {
        private readonly ILoggerService<GetAllIllnessesQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllIllnessesQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllIllnessesQuery> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }

        public IEnumerable<IllnessItemModel> Execute()
        {
            try
            {
                return db.Illnesses
                    
                    .Select(x => new IllnessItemModel
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
