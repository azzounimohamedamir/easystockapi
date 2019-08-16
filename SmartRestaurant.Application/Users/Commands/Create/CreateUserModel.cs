using System;

namespace SmartRestaurant.Application.Users.Commands.Create
{
    public class CreateUserModel : ICreateUserModel
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
    }
}