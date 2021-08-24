namespace SmartRestaurant.Application.Common.Configuration
{
    public class InvitationToJoinOrganization
    {
        public string Subject { get; set; }
        public Body Body { get; set; }

        public string Template
        {
            get =>
                Body.Content
                    .Replace("{welcome}", Body.welcome)
                    .Replace("{message}", Body.message)
                    .Replace("{button}", Body.button);
            set { }
        }
    }

    public class Body
    {
        public string welcome { get; set; }
        public string message { get; set; }
        public string button { get; set; }
        public string Content { get; set; }
    }
}