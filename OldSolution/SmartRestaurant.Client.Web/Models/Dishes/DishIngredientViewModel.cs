using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Models;
using SmartRestaurant.Application.Dishes.DishIngredients.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Dishes
{
    public class DishIngredientViewModel 
    {
        public int Index { get; set; }
        public string Text { get; set; }
        public string CategoryId { get; set; }

        public SelectList Categories { get; set; }
        public SelectList Foods { get; set; }
        public SelectList Units { get; set; }

        public string Title
        {
            get
            {
                var n = Index+1 < 10 ? $"0{(Index + 1).ToString()}" : $"{(Index + 1).ToString()}";
                return $"{Text} {n}";
            }
        }

        public DishIngredientModel Ingredient { get; set; }

        public bool CanDelete
        {
            get
            {
                return !(Index == 0);
            }
        }
    }
}
