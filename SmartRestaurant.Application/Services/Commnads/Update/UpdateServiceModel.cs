using SmartRestaurant.Application.Services.Commnads.Create;

namespace SmartRestaurant.Application.Services.Commnads.Update
{
    public class UpdateServiceModel : CreateServiceModel, IUpdateServiceModel
    {
        public string Id { get; set; }
    }
}
