using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Foods.FoodCategories.Queries.Factory;
using SmartRestaurant.Application.Foods.Specifications;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.FoodCategories.Queries.GetAll
{
    public interface IGetChildrenQuery
    {        
        List<FoodCategoryItemModel> Execute(string parentId, string excludeId = null);
        
    }

    public class GetChildrenQuery : IGetChildrenQuery
    {
        private readonly ILoggerService<GetAllFoodCategoriesQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetChildrenQuery(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllFoodCategoriesQuery> logger, 
            IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        public  List<FoodCategoryItemModel> Execute(string parentId, string excludeId = null)
        {
            try
            {
                var specification = new FoodCategorySpecification(fc => fc.ParentId.ToString() == parentId & excludeId != null ? fc.Id.ToString() != excludeId : true)
                    .ApplyOrderBy(fc=>fc.Name);
                    

                return db.FoodCategories
                    .AsQueryable()
                    .ApplySpecification(specification)                    
                    .ToFoodCategoryItemModels()
                    .ToList();  
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
