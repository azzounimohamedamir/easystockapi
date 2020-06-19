namespace SmartRestaurant.Application.Commun.Specialites.Commands.Update
{
    public interface IUpdateSpecialityModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        string Id { get; set; }
        bool IsDisabled { get; set; }
        string Name { get; set; }
        
    }
}