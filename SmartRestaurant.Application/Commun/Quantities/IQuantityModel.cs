namespace SmartRestaurant.Application.Commun.Quantities
{
    public interface IQuantityModel
    {
        string UnitId { get; set; }
        decimal Value { get; set; }
    }
}