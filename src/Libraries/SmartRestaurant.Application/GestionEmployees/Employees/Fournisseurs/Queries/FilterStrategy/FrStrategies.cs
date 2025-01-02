
namespace SmartRestaurant.Application.GestionEmployees.Employees.Fournisseurs.Queries.FilterStrategy
{
    public static class FrStrategies
    {
        public static IFrFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterFrByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterFrByName();

                default:
                    return new FilterFrByName();
            }
        }
    }
}
