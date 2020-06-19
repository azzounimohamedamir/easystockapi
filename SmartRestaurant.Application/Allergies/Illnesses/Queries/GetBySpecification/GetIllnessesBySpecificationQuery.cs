using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Allergies.Illnesses.Queries.Factory;
using SmartRestaurant.Application.Allergies.Illnesses.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Allergies.Illnesses.Queries.GetBySpesification
{


    public interface IGetIllnessesBySpecificationQuery
    {
        IEnumerable<IllnessItemModel> Execute(IllnessSpecification spec);
    }
    public class GetIllnessesBySpecificationQuery : IGetIllnessesBySpecificationQuery
    {
        private readonly ILoggerService<GetIllnessesBySpecificationQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetIllnessesBySpecificationQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetIllnessesBySpecificationQuery> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }

        public IEnumerable<IllnessItemModel> Execute(IllnessSpecification spec)
        {
            try
            {
                return db.Illnesses.AsQueryable()                   
                       .ApplySpecification(spec)
                       .ToIllnessItemModels()
                       .ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}
