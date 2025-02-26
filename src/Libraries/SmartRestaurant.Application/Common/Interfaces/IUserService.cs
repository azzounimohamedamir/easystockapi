namespace SmartRestaurant.Application.Common.Interfaces
{
    public interface IUserService
    {
        public string GetUserLanguage();
        public string GetUserId();
        public string GetRoles();
        public void SetNewRole(string role);
    }
}