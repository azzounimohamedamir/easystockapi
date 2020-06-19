using SmartRestaurant.Domain.Commun;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Domain.Foods
{
    //Category 
    //__Food==>throw Exception <Name>
    //__ Child Category
    //______Child Category
    public class FoodCategory : BaseEntity<Guid>
    {
        public Guid? ParentId { get; set; }
        public Guid? PictureId { get; set; }
        public virtual Picture Picture { get; set; }
        public virtual FoodCategory Parent { get; set; }
        public virtual ICollection<FoodCategory> Childs { get; set; }
        public virtual ICollection<Food> Foods { get; set; }
    }
}