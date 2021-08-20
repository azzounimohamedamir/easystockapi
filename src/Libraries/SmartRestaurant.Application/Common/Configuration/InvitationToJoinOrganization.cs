using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Common.Configuration
{
    public class InvitationToJoinOrganization
    {
        public string Subject { get; set; }
        public Body Body { get; set; }
        public string Template {
            get {
                return this.Body.Content
                    .Replace("{welcome}", this.Body.welcome)
                    .Replace("{message}", this.Body.message)
                    .Replace("{button}", this.Body.button);
            } set{ }
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
