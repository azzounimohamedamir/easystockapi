namespace SmartRestaurant.Application.Interfaces
{
    public interface IPagination
    {
        int Skip { get; set; }
        int Take { get; set; }
    }
}
