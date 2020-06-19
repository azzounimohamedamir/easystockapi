namespace SmartRestaurant.Application.Commun.Units.Commands.Create
{
    public class CreateUnitModel : ICreateUnitModel
    {
        public string Name { get; set; }
        public string Symbol { get; set; }        
        public string Alias { get; set; }
        public bool IsDisabled { get; set; }
    }
}