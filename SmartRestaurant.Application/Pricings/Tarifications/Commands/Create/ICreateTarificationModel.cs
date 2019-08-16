namespace SmartRestaurant.Application.Pricings.Tarifications.Commands.Create
{
    public interface ICreateTarificationModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        bool IsDisabled { get; set; }
        string Name { get; set; }
        string SlugUrl { get; set; }
        string RestaurantId { get; set; }

        bool IsPercentage { get; set; }
        decimal Amount { get; set; }
    }
}