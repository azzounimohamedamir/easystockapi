using SmartRestaurant.Application.Allergies.Allergies.Commands.Create;

namespace SmartRestaurant.Application.Allergies.Allergies.Commands.Update
{
    public interface IUpdateAllergyModel: ICreateAllergyModel
    {
        string Id { get; set; }
    }
}