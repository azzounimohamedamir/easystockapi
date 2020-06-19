using System.Collections.Generic;

namespace SmartRestaurant.Application.Commun.Translates.Queries.GetByTableName
{
    public class ItemTranslatesModel
    {
        public List<TextTraslation> TextTraslations { get; set; }
        public string PrimaryKeyValue { get; set; }
        public string ColumnName { get; set; }
        public string TableName { get; set; }
        public string OriginalText { get; set; }
        public int Index { get; set; }
    }
}