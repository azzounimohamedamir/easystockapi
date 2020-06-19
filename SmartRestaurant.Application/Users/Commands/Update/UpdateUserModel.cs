using SmartRestaurant.Application.Users.Commands.Create;

namespace SmartRestaurant.Application.Users.Commands.Update
{
    public class UpdateUserModel : CreateUserModel, IUpdateUserModel
    {
        public string Id { get; set; }
    }
}
