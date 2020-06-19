using Helpers;
using SmartRestaurant.Application.ApplicationDataBase.Extensions;
using SmartRestaurant.Application.Commun.Galleries.Pictures.Models;
using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Foods.Commands.Update;
using SmartRestaurant.Application.Foods.Models;
using SmartRestaurant.Application.Foods.Specifications;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Foods.Queries.GetById
{


    public interface IGetFoodByIdQuery
    {
        UpdateFoodModel Execute(string id);
    }
    public class GetFoodByIdQuery : IGetFoodByIdQuery
    {
        private readonly ILoggerService<GetFoodByIdQuery> logger;
        private readonly IMailingService mailing;
        private readonly INotifyService notify;
        private readonly ISmartRestaurantDatabaseService db;

        public GetFoodByIdQuery(ISmartRestaurantDatabaseService db,
            ILoggerService<GetFoodByIdQuery> logger, IMailingService mailing,
            INotifyService notify)
        {
            this.db = db;
            this.logger = logger;
            this.mailing = mailing;
            this.notify = notify;
        }

        public UpdateFoodModel Execute(string id)
        {
            try
            {
                var specification = new FoodSpecification(f => f.Id == id.ToGuid())
                    .AddInclude(f => f.Nutrition.Quantity.Unit);

                return db.Foods.ApplySpecification(specification)
                    .Select(f => new UpdateFoodModel()
                    {
                        FoodModel = new FoodModel
                        {
                            Id = f.Id.ToString(),
                            Name = f.Name,
                            Alias = f.Alias,
                            Description = f.Description,
                            FoodCategoryId = f.FoodCategoryId.ToString(),
                            IsDisabled = f.IsDisabled,
                            Picture = f.Picture != null ? new PictureModel
                            {
                                Id = f.Picture.Id.ToString(),
                                Url = f.Picture.ImageUrl,
                            } : null,
                            UnitId = f.UnitId.ToString(),
                        },
                        Nutrition = new NutritionModel
                        {
                            Quantity = new QuantityModel
                            {
                                UnitId = f.Nutrition.Quantity.UnitId.ToString(),
                                Value = f.Nutrition.Quantity.Value
                            },
                            GlycemicIndex = f.Nutrition.GlycemicIndex,
                            Fibre = f.Nutrition.Fibre,
                            Calorie = f.Nutrition.Calorie,
                            Protein = f.Nutrition.Protein,
                            Carbohydrate = f.Nutrition.Carbohydrate,
                            Lipid = f.Nutrition.Lipid,

                        }
                    })
                    .FirstOrDefault();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
