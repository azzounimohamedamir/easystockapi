namespace SmartRestaurant.Application.Commun.Languages.Commands.Create
{
    public class CreateLanguageModel : ICreateLanguageModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IsoCode { get; set; }
        

        public bool IsRTL { get; set; }
        public string Alias { get; set; }
        public string EnglishName { get; set; }
        public bool IsDisabled { get; set; }

    }
}