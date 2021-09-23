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
}