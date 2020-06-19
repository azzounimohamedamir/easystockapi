using SmartRestaurant.Application.Commun.Prices;

namespace SmartRestaurant.Application.Commun.Translates.Commands.Create
{
    public class CreateTranslateModel : ICreateTranslateModel
    {
        public string LanguageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Alias { get; set; }

        public bool IsDisabled { get; set; }
        public string TableName { get; set; }
        public string PrimaryKeyName { get; set; }
        public string PrimaryKeyValue { get; set; }
        public string ColumnName { get; set; }
        public string Text { get; set; }
    }
}