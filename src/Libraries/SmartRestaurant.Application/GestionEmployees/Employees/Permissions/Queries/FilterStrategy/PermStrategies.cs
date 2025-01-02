

namespace SmartRestaurant.Application.GestionEmployees.Employees.Permissions.Queries.FilterStrategy
{
    public static class PermStrategies
    {
        public static IPermFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterPermissionsByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterPermissionsByName();

                default:
                    return new FilterPermissionsByName();
            }
        }
    }
}
