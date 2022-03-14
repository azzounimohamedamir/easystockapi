namespace SmartRestaurant.Application.Common.Configuration
{
    public class EmailTemplateBase
    {
        public Ar Ar { get; set; }
        public En En { get; set; }
        public Fr Fr { get; set; }

        public EmailTemplateLanguagesBase SelectLanguage(string language)
        {
            if (language == null)
                return En;

            switch (language.ToLower())
            {
                case "ar":
                    return Ar;

                case "en":
                    return En;

                case "fr":
                    return Fr;

                default:
                    return En;
            }
        }
    }
}