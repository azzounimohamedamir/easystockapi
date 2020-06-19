using SmartRestaurant.Application.Users.Commands.Create;

namespace SmartRestaurant.Application.Users.Commands.Update
{
    public interface IUpdateUserModel : ICreateUserModel
    {
        string Id { get; set; }
    }
}
