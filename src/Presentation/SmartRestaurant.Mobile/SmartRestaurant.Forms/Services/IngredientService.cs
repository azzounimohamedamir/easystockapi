using Newtonsoft.Json;
using SmartRestaurant.Diner.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SmartRestaurant.Diner.Services
{
    /// <summary>
    /// this class is used to get tables from the server API of local json file and stored them in a ListTables Object.
    /// </summary>
    public class IngredientService
    {
        static private ListIngredientsObject Ingredients;
        public static ObservableCollection<IngredientModel> GetListIngredients()
        {
            if(Ingredients ==null)
            Ingredients = JsonConvert.DeserializeObject<ListIngredientsObject>(SimpleService.GetJsonString("Repositories.ListIngredients.json"));            
            if (Ingredients.IngredientsList != null)
            {
                return new ObservableCollection<IngredientModel>(Ingredients.IngredientsList);
            }
            else
            {
                return new ObservableCollection<IngredientModel>();
            }
        }
    }

    /// <summary>
    /// Used to store and manage tables
    /// </summary>
    public class ListIngredientsObject
    {
        public IList<IngredientModel> IngredientsList { get; set; }
    }
}
