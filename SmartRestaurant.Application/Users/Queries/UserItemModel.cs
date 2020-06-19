using System;

namespace SmartRestaurant.Application.Users.Queries
{
    public class UserItemModel
    {
        public String Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public bool IsSelected { get; set; }
    }
}
