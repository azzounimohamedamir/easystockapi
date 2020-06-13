namespace SmartRestaurant.Application.Allergies.Allergies.Commands.Create
{
    public interface ICreateAllergyModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        bool IsDisabled { get; set; }
        string Name { get; set; }
    }
}