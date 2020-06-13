using SmartRestaurant.Application.Users.Commands.Create;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Users.Commands.Update
{
    public interface IUpdateUserModel : ICreateUserModel
    {
        string Id { get; set; }
    }
}
