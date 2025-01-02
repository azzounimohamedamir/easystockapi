

namespace SmartRestaurant.Application.GestionEmployees.Employees.Clients.Queries.FilterStrategy
{
    public static class ClStrategies
    {
        public static IClFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterClByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterClByName();

                default:
                    return new FilterClByName();
            }
        }
    }
}
