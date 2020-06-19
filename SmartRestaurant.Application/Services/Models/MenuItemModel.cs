using SmartRestaurant.Domain.Products;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Services.Models
{
    public class BaseMenuItemModel
    {
        public string MenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<BaseImageModel> Images { get; set; }
        public PriceModel Price { get; set; }//currency,value


    }
    public class MenuDishItemModel : BaseMenuItemModel
    {
        public string DishId { get; set; }
        public List<IngredientModel> Ingredients { get; set; }
        public DishNutrritionModel Nutrrition { get; set; }
    }

    public class MenuProductItemModel : BaseMenuItemModel
    {
        public string ProductId { get; set; }

        public static implicit operator MenuProductItemModel(Product product)
        {
            var images = new List<BaseImageModel>
                {
                    new BaseImageModel
                    {
                        ImageUrl = product.Picture.ImageUrl,
                        Description= product.Picture.Description,
                        IsCover = true,
                        Title = product.Picture.Name
                    }
                };
            var price = new PriceModel
            {
                Amount = product.Pricing.SalePriceTTC.Amount,
                Currency = product.Pricing.SalePriceTTC.Currency.Name,
            };

            return new MenuProductItemModel
            {
                Description = product.Description,
                Images = images,
                Name = product.Name,
                Price = price,
                ProductId = product.Id.ToString()
            };
        }
    }
}

