using Helpers;
using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Exceptions;
using SmartRestaurant.Application.FoodCategories.Commands.Update;
using SmartRestaurant.Application.Foods.Specifications;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.FoodCategories.Queries.GetById
{
    public interface IGetFoodCategoryByIdQuery
    {
        UpdateFoodCategoryModel Execute(string id);
    }

    public class GetFoodCategoryByIdQuery : IGetFoodCategoryByIdQuery
    {
        private readonly ILoggerService<GetFoodCategoryByIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetFoodCategoryByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetFoodCategoryByIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }
        //TODO: this methode return UpdateFoodCategoryModel
        public UpdateFoodCategoryModel Execute(string id)
        {
            try
            {
                var guid = id.ToGuid();

                var specification = new FoodCategorySpecification(fc => fc.Id == guid)
                    .AddInclude(fc => fc.Parent);

                var _category = db.FoodCategories.AsQueryable()
                    .ApplySpecification(specification)
                    .FirstOrDefault();

                if (_category == null) throw new NotFoundException();
                return new UpdateFoodCategoryModel
                {
                    Id = _category.Id.ToString(),
                    ParentId = _category.ParentId.ToString(),
                    Alias = _category.Alias,
                    Description = _category.Description,
                    Name = _category.Name,
                    PictureUrl = _category.Picture?.ImageUrl,
                };
                //var FoodCategorie = db.FoodCategories
                //     .Include(p => p.Parent)
                //     .Include(c => c.Picture)
                //     .Where(f => f.Id == guid)
                //     .FirstOrDefault()
                //.ToFoodCategoryItemModel();
                /*.Select(x => new FoodCategoryItemModel
                {
                    Id = x.Id.ToString(),
                    Description = x.Description,
                    Name = x.Name,
                    ParentName = x.Parent.Name,
                    PictureUrl = x.Picture != null ? x.Picture.ImageUrl : null,
                    SlugUrl = x.SlugUrl
                }).FirstOrDefault();*/

                //return FoodCategorie;
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
