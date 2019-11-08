using SmartRestaurant.Application.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Forms.Models
{
    public class MenuItemModelDto : BaseModel
    {
        private int quantity;
        public Action QuantityPropertyChanged;
        
        private string getlist()
        {
            if (Ingredients == null || Ingredients.Count == 0)
                return "";
            var temp = "";
            foreach (var item in Ingredients)
            {
                temp += item.Name + " ";
            }
            return temp;
        }
        public string INGSTR => getlist();
        public string Id { get; set; }
        public bool IsProduct { get; set; }
        public List<IngredientModelDto> Ingredients { get; set; }
        public DishNutrritionModelDto Nutrrition { get; set; }
        public int Quantity

        {
            get { return quantity; }
            set
            {
                quantity = value;
                TotalPrice = (double)(quantity * Price?.Amount ?? 0);
                QuantityPropertyChanged();
            }
        }
        public string Currency { get; set; }
        public double TotalPrice { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<BaseImageModelDto> Images { get; set; }
        public PriceModelDto Price { get; set; }
        public BaseImageModelDto Cover { get; set; }

        public static implicit operator MenuItemModelDto(MenuDishItemModel model)
        {
            if (model == null) return null;
            var temp = new MenuItemModelDto();
            temp.Images = BaseImageModelDto.ToDtoList(model.Images);
            temp.Description = model.Description;
            temp.Id = model.DishId;
            temp.Ingredients = IngredientModelDto.ToDtoList(model.Ingredients);
            temp.IsProduct = false;
            temp.Name = model.Name;
            temp.Nutrrition = model.Nutrrition;
            temp.Price = model.Price;
            temp.Quantity = 0;
            temp.Cover = model.Images?.FirstOrDefault(x => x.IsCover);
            temp.TotalPrice = (double)(model.Price?.Amount ?? 0);
            temp.Currency = model.Price?.Currency ?? "";
            return temp;

        }
        public static implicit operator MenuItemModelDto(MenuProductItemModel model)
        {
            if (model == null) return null;
            return new MenuItemModelDto
            {
                Images = BaseImageModelDto.ToDtoList(model.Images),
                Description = model.Description,
                Id = model.ProductId,
                IsProduct = true,
                Name = model.Name,
                Price = model.Price,
                Quantity = 0,
                Cover = model.Images?.FirstOrDefault(x => x.IsCover),
                TotalPrice = (double)model.Price.Amount,
                Currency = model.Price.Currency
            };
        }
        public static implicit operator OrderItemModel(MenuItemModelDto model)
        {
            if (model == null) return null;
            return new OrderItemModel
            {
                CoverUrl = model.Cover?.ImageUrl,
                Description = model.Description,
                Id = model.Id,
                IsProduct = model.IsProduct,
                Name = model.Name,
                Price = model.Price,
                Quantity = 0,
                TotalPrice = new PriceModel
                {
                    Amount = (decimal)model.TotalPrice,
                    Currency = model.Currency
                },
                Ingredients = IngredientModelDto.ToModelList(model.Ingredients)
            };
        }
        public static List<OrderItemModel> ToModeList(List<MenuItemModelDto> models)
        {
            if (models == null) return null;
            return models.ConvertAll<OrderItemModel>((input) =>
            { return input;
            });
        }
    }
}
