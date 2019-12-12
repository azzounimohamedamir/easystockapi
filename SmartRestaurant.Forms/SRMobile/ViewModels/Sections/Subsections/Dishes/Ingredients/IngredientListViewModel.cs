using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Sections.Subsections.Ingredientes.Ingredients
{
    public class IngredientListViewModel : SimpleViewModel
    {
        private static ObservableCollection<IngredientViewModel> ingredients;
        /// <summary>
        /// Ingredient to bind with the View.
        /// </summary>
        public ObservableCollection<IngredientViewModel> Ingredients
        {
            get
            {
                if (ingredients == null)
                {
                    ObservableCollection<IngredientModel> listIngredient = IngredientService.GetListIngredients();
                    ingredients = new ObservableCollection<IngredientViewModel>();
                    foreach (var item in listIngredient)
                    {
                        ingredients.Add(new IngredientViewModel(item));
                    }
                }
                return ingredients;
            }
            set
            {
                ingredients = value;
                RaisePropertyChanged();
            }

        }

    }
}
