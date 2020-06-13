using SmartRestaurant.Application.Users.Commands.Create;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Users.Commands.Update
{
    public class UpdateUserModel : CreateUserModel, IUpdateUserModel
    {
        public string Id { get; set; }
    }
}
