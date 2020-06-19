namespace SmartRestaurant.Application.Commun.Specialites.Commands.Create
{
    public class CreateSpecialityModel : ICreateSpecialityModel
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
    }

}