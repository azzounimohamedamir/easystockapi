using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Diner.Models
{
    /// <summary>
    /// Used to manage sections or categories of food.
    /// </summary>
    public class SectionModel
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameFr { get; set; }
        public string NameEn { get; set; }

        /// <summary>
        /// Used to set the image of the section or category.
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// Used to get the Uri of the image.
        /// </summary>
        public Uri ImageUri
        {
            get
            {
                return String.IsNullOrEmpty(Image) ? null : new Uri(Image);
            }
        }
    }
}
