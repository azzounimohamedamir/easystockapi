namespace SmartRestaurant.Application.Commun.Languages.Commands.Create
{
    public interface ICreateLanguageModel
    {
        string Id { get; set; }
        string Alias { get; set; }
        string EnglishName { get; set; }
        string IsoCode { get; set; }
        bool IsRTL { get; set; }
        string Name { get; set; }
    }
}