using SmartRestaurant.Domain.Commun;
namespace SmartRestaurant.Application.Commun.Units.Commands.Factory
{
    public interface IUpdateUnitFactory
    {
        Unit Create(Unit unit, string name, string symbol, string alias);

    }
    public class UpdateUnitFactory : IUpdateUnitFactory
    {
        public Unit Create(
            Unit unit,
            string name,
            string symbol,
            string alias)
        {

            unit.Name = name;
            unit.Symbol = symbol;
            unit.Alias = alias;
            return unit;
        }
    }
}
