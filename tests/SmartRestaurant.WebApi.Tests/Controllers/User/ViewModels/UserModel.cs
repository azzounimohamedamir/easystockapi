namespace SmartRestaurant.WebApi.Tests.Controllers.User.ViewModels
{
    public class UserModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public object FullName { get; set; }
        public string UserName { get; set; }
        public string Roles { get; set; }
        public object PhoneNumber { get; set; }
    }
}