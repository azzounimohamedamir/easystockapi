using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Application.Commun.Translates.Queries.GetByTableName
{
    public class TranslateItemModel
    {
        public string IsDisabled { get; set; }
        public string Text { get; set; }
        public string PrimaryKeyName { get; set; }
        public string PrimaryKeyValue { get; set; }
        public string TableName { get; set; }
        public string Id { get; set; }
        public Language Language { get; set; }
        public string ColumnName { get; set; }
        public dynamic OriginalText { get; internal set; }
    }
}