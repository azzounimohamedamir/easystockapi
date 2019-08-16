using Helpers;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Commun.Galleries.Galleries.Commands.Factory;
using SmartRestaurant.Application.Dishes.DishAccompaniments.Factory;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Factory;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Update;
using SmartRestaurant.Application.Dishes.DishIngredients.Commands.Factory;
using SmartRestaurant.Application.Interfaces;
using System;
using System.Linq;

namespace SmartRestaurant.Application.Dishes.Dishes.Queries
{
    public interface IGetByIdQuery
    {
        UpdateDishModel Execute(string id);
    }
    public class GetByIdQuery : IGetByIdQuery
    {
        private readonly ISmartRestaurantDatabaseService db;
        private readonly ILoggerService<GetAllDishQuery> logger;
        private readonly INotifyService notify;
        private readonly IMailingService mailing;
        private readonly IDishModelFactory dishModelFactory;
        private readonly IDishIngredientModelFactory dishIngredientModelFactory;
        private readonly IDishAccompanimentModelFactory dishAccompanimentModelFactory;
        private readonly IGalleryModelFactory galleryModelFactory;

        public GetByIdQuery(
            ISmartRestaurantDatabaseService db,
            ILoggerService<GetAllDishQuery> logger,
            INotifyService notify,
            IMailingService mailing,
            IDishModelFactory dishModelFactory,
            IDishIngredientModelFactory dishIngredientModelFactory,
            IDishAccompanimentModelFactory dishAccompanimentModelFactory,
            IGalleryModelFactory galleryModelFactory)
        {
            this.db = db ?? throw new ArgumentNullException(nameof(db));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.notify = notify ?? throw new ArgumentNullException(nameof(notify));
            this.mailing = mailing ?? throw new ArgumentNullException(nameof(mailing));
            this.dishModelFactory = dishModelFactory ?? throw new ArgumentNullException(nameof(dishModelFactory));
            this.dishIngredientModelFactory = dishIngredientModelFactory ?? throw new ArgumentNullException(nameof(dishIngredientModelFactory));
            this.dishAccompanimentModelFactory = dishAccompanimentModelFactory ?? throw new ArgumentNullException(nameof(dishAccompanimentModelFactory));
            this.galleryModelFactory = galleryModelFactory ?? throw new ArgumentNullException(nameof(galleryModelFactory));
        }

        public UpdateDishModel Execute(string id)
        {
            try
            {
                var dish= db.Dishes
                    .Include(d => d.Family)
                    .Include(d => d.Restaurant)
                    .Include(d=>d.Ingredients)
                    .ThenInclude(ding=>ding.Food)
                    .ThenInclude(fo=>fo.Category)
                    .ThenInclude(focat=>focat.Parent)
                    .ThenInclude(parent=> parent.Parent)
                    .ThenInclude(parent => parent.Parent.Parent)
                    .Include(d=>d.ChildAccompaniments)
                    //.Include("Ingredients.Food")   
                    //.Include("Ingredients.Food.Category.Parent")
                    .Include(d=>d.Gallery).ThenInclude(gal=>gal.Pictures)
                    //.Include("Gallery.Pictures")
                    .Where(d=>d.Id==id.ToGuid())                                        
                    .FirstOrDefault();

                return new UpdateDishModel
                {
                    Id = dish.Id.ToString(),
                    DishModel = dishModelFactory.Create(dish),
                    Ingredients= dishIngredientModelFactory.Create(dish.Ingredients).ToList(),
                    Accompaniments= dishAccompanimentModelFactory.Create(dish.ChildAccompaniments).ToList(),
                    Gallery = galleryModelFactory.Create(dish.Gallery)
                };
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
