namespace SmartRestaurant.Application.Common.Configuration
{
    public class EmailTemplateLanguagesBase
    {
        public string Subject { get; set; }
        public Body Body { get; set; }

        public string Template
        {
            get
            {
                return Body.Content
                   .Replace("{welcome}", Body.welcome)
                   .Replace("{message}", Body.message)
                   .Replace("{button}", Body.button);
            }
        }
    }

    public class Body
    {
        public string welcome { get; set; }
        public string message { get; set; }
        public string button { get; set; }
        public string Content { get; set; }
    }

    public class Ar : EmailTemplateLanguagesBase
    {

    }

    public class En : EmailTemplateLanguagesBase
    {

    }

    public class Fr : EmailTemplateLanguagesBase
    {

    }


}
