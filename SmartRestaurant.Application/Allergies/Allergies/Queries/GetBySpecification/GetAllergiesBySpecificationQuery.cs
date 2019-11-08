using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Application.Allergies.Allergies.Queries.Factory;
using SmartRestaurant.Application.Allergies.Allergies.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Allergies.Allergies.Queries.GetBySpecification
{


    public interface IGetAllergiesBySpecificationQuery
    {
        IEnumerable<AllergyItemModel> Execute(AllergySpecification spec);
    }
    public class GetAllergiesBySpecificationQuery : IGetAllergiesBySpecificationQuery
    {
        private readonly ILoggerService<GetAllergiesBySpecificationQuery> log;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetAllergiesBySpecificationQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllergiesBySpecificationQuery> log,
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.log = log;
            this.mailing = mailing;
            this.notify = notify;
        }

        public IEnumerable< AllergyItemModel> Execute(AllergySpecification spec)
        {
            try
            {
                return db.Allergies.AsQueryable()
                       .ApplySpecification(spec)
                       .ToAllergyItemModels()
                       .ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

}
