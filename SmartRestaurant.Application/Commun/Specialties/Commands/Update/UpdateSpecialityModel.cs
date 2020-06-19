namespace SmartRestaurant.Application.Commun.Specialites.Commands.Update
{
    public class UpdateSpecialityModel : IUpdateSpecialityModel
    {
        public string Id { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDisabled { get; set; }
    }
}