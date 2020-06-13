using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Commun.Quantities;
using SmartRestaurant.Application.Dishes.DishAccompaniments.Models;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Models;
using SmartRestaurant.Application.Dishes.DishIngredients.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Models.Dishes
{
    public class DishAccompanimentViewModel
    {
        public int Index { get; set; }
        public string Text { get; set; }

       
        public SelectList Accompaniments { get; set; }
        
        public SelectList Units { get; set; }

        public string Title
        {
            get
            {
                var n = Index+1 < 10 ? $"0{(Index + 1).ToString()}" : $"{(Index + 1).ToString()}";
                return $"{Text} {n}";
            }
        }

        public DishAccompanyingModel Accompaniment { get; set; }
    }
}
