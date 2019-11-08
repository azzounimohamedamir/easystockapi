using System.Collections.Generic;

namespace SmartRestaurant.Application.Services.Models
{
    public class SectionModel
    {
        public SectionModel()
        {
            Childs = new List<SectionModel>();
        }
        public string Name { get; set; }
        public List<SectionModel> Childs { get; set; }

        public List<MenuDishItemModel> Dishes { get; set; }
        public List<MenuProductItemModel> Products { get; set; }

        public TodaysChefSelection ChefSelection { get; }
        public TodaysDish TodaysDish { get; }

        public int level = 0;
    }
}