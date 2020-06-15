using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Diner.Models
{
    /// <summary>
    /// Used to manage Dishes
    /// </summary>
    public class DishModel
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameFr { get; set; }
        public string NameEn { get; set; }
        public int EstimatedTime { get; set; }
        public float Price { get; set; }
        /// <summary>
        /// Used to set images of the dish
        /// </summary>
        public List<String> Images { get; set; }
        public int SubSectionId { get; set; }
        public List<DishIngredient> Ingredients { get; set; }
        #region Intial Values : for bread for example
        public float Calories { get; set; }
        public float Carbo { get; set; }
        public float Fat { get; set; }
        public float Protein { get; set; }
        #endregion
    }
    public class DishIngredient
    {
        public int Id { get; set; }
        public int Measure { get; set; }
    }
}
