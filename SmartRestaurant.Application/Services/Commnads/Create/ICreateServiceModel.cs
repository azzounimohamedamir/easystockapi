namespace SmartRestaurant.Application.Services.Commnads.Create
{
    public interface ICreateServiceModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        bool IsDisabled { get; set; }
        string Name { get; set; }
        string RestaurantId { get; set; }
    }
}