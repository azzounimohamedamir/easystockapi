namespace SmartRestaurant.Application.Commun.Translates.Commands.Create
{
    public interface ICreateTranslateModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        string Name { get; set; }
        string TableName { get; set; }
        string PrimaryKeyName { get; set; }
        string PrimaryKeyValue { get; set; }
        string ColumnName { get; set; }
        string Text { get; set; }
        string LanguageId { get; set; }
    }
}