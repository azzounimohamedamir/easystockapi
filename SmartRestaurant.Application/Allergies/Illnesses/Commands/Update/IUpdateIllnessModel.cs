using SmartRestaurant.Application.Allergies.Illnesses.Commands.Create;

namespace SmartRestaurant.Application.Allergies.Illnesses.Commands.Update
{
    public interface IUpdateIllnessModel : ICreateIllnessModel
    {
          string Id { get; set; }
    }
}