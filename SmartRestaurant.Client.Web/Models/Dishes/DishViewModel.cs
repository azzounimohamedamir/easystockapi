using Microsoft.AspNetCore.Mvc.Rendering;
using SmartRestaurant.Application.Dishes.Dishes.Commands.Models;
using SmartRestaurant.Client.Web.Models.Galleries;
using SmartRestaurant.Client.Web.Models.Utils;
using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Models.Dishes
{
    public class DishViewModel
    {
        public string Id { get; set; }
        public SelectList Restaurants { get; set; }
        public DishModel DishModel { get; set; }

        public List<DishIngredientViewModel> Ingredients { get; set; }
        public List<DishAccompanimentViewModel> Accompaniments { get; set; }
        public List<DishEquivalenceModel> Equivalences { get; set; }
        public string Action { get; set; } = "Add";
        public SelectListViewModel Famillies { get; set; }
        public SelectList DishTypes { get; set; }

        public int IngredientIndex { get; set; } = 0;
        public int IngredientToDeleteIndex { get; set; }

        public int AccompanyingIndex { get; set; } = 0;
        public int AccompanyingToDeleteIndex { get; set; }

        public int EquivalenceIndex { get; set; } = 0;
        public int EquivalenceToDeleteIndex { get; set; }
        public string GalleryId { get; set; }
        public SelectList Galleries { get; set; }

        public int GalleryPictureIndex { get; set; }
        public int GalleryPictureToDeleteIndex { get; set; }
        public GalleryViewModel GalleryViewModel { get; set; }
    }


}
