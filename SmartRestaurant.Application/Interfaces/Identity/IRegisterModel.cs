namespace SmartRestaurant.Application.Identity.Interfaces
{
    interface IRegisterModel : ILoginModel
    {
        string Email { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PasswordConfirmation { get; set; }
    }
}