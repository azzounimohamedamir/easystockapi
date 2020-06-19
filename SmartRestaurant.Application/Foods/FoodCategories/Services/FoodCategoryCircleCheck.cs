using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SmartRestaurant.Application.Foods.FoodCategories.Services
{
    public static class FoodCategoryCircleCheck
    {
        public static bool CircleCheckNotValid(this FoodCategory category, 
            ISmartRestaurantDatabaseService db,
           Guid newParent)
        {
            // category and its brothers
            var me = db.FoodCategories
                 .Include(x => x.Childs)
                 .Include("Childs.Childs")
                 .Where(x => x.Id == category.Id).FirstOrDefault();


            var allChildren = GetElementAndChilds(me);
           
            return allChildren.Any(x => x.Id == newParent);

        }

        private static IEnumerable<FoodCategory> GetElementAndChilds(FoodCategory node)
        {
            if (node.Childs == null || node.Childs.Count == 0)
                return new List<FoodCategory> { node };

            List<FoodCategory> meAndMyChilds = new List<FoodCategory> { node };
            foreach (var child in node.Childs)
            {
                var temp = GetElementAndChilds(child);
                if (temp != null)
                    meAndMyChilds.AddRange(temp);
            }

            return meAndMyChilds;
        }
    }
}
