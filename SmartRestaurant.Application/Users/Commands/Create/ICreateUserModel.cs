namespace SmartRestaurant.Application.Users.Commands.Create
{
    public interface ICreateUserModel
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}