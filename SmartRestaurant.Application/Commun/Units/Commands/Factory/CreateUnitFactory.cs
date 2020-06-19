using SmartRestaurant.Domain.Commun;
namespace SmartRestaurant.Application.Commun.Units.Commands.Factory
{
    public interface ICreateUnitFactory
    {
        Unit Create(string name, string symbol, string alias, bool isDisabled);

    }
    public class CreateUnitFactory : ICreateUnitFactory
    {
        public Unit Create(
            string name,
            string symbol,
            string alias,
            bool isDisabled)
        {
            var entity = new Domain.Commun.Unit();

            entity.Name = name;
            entity.Symbol = symbol;
            entity.Alias = alias;
            entity.IsDisabled = isDisabled;
            return entity;

        }
    }
}
