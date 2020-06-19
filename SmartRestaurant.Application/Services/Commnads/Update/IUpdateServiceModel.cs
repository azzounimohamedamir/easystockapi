using SmartRestaurant.Application.Services.Commnads.Create;

namespace SmartRestaurant.Application.Services.Commnads.Update
{
    public interface IUpdateServiceModel : ICreateServiceModel
    {
        string Id { get; set; }
    }
}