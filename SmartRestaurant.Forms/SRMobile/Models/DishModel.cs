using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Diner.Models
{
    /// <summary>
    /// Used to manage sections or categories of food.
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
        /// Used to set the image of the section or category.
        /// </summary>
        public List<string> Images { get; set; }
        public int SubSectionId { get; set; }
    }
}
