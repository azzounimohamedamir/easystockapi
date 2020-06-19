namespace SmartRestaurant.Application.Commun.Specialites.Commands.Create
{
    public interface ICreateSpecialityModel
    {
        string Alias { get; set; }
        string Description { get; set; }
        string Name { get; set; }        
    }
}