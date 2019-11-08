using SmartRestaurant.Domain;

namespace SmartRestaurant.Application.Users.Commands.Create
{
    public interface ICreateUserFactory
    {
        SRUser Create(string FirstName, string LastName, string UserName, string Email, string Password);
    }

    public class CreateUserFactory : ICreateUserFactory
    {
        public SRUser Create(string FirstName, string LastName, string UserName, string Email, string Password)
        {
            var entity = new SRUser();
            entity.FirstName = FirstName;
            entity.LastName = LastName;
            entity.Email = Email;
            entity.PasswordHash = Password;
            return entity;

        }
    }
}