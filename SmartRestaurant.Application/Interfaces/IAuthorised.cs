namespace SmartRestaurant.Application.Interfaces
{
    public interface IAutor
    {
        string UserId { get; set; }
        string TableName { get; set; }
        string ActionName { get; set; }
    }
    public interface IAutorisation
    {
        bool IsAuthorised(string userId, params string[] args);
    }
}
