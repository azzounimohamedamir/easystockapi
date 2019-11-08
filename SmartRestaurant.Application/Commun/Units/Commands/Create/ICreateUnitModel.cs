namespace SmartRestaurant.Application.Commun.Units.Commands.Create
{
    public interface ICreateUnitModel
    {
        string Alias { get; set; }
        string Symbol { get; set; }
        string Name { get; set; }
        
    }
}