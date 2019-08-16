namespace SmartRestaurant.Application.Allergies.Illnesses.Commands.Create
{
    public interface ICreateIllnessModel
    {
         string Name { get; set; }
         string Description { get; set; }
         string Alias { get; set; }
         bool  IsDisabled { get; set; }
    }
}