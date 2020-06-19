using System;

namespace SmartRestaurant.Domain.Commun
{
    /// <summary>
    /// Language=Ar
    /// TableName= Dishes
    /// PrimaryKeyName=Id
    /// PrimaryKeyValue = 345-312312-213312-423
    /// ColumnName = Description
    /// Value = وصف الطبق
    /// 
    /// Language=En
    /// TableName= Dishes
    /// PrimaryKeyName=Id
    /// PrimaryKeyValue = 345-312312-213312-423
    /// ColumnName = Description
    /// Value = Dish Description
    /// </summary>
    public class Translate : SmartRestaurantBaseEntity<Guid>
    {
        public string TableName { get; set; }
        public string PrimaryKeyName { get; set; }
        public string PrimaryKeyValue { get; set; }
        public string ColumnName { get; set; }
        public string Text { get; set; }
        public string LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
