
namespace SmartRestaurant.Application.ProgrammeFidelite.Queries.FilterStrategy
{
    public static class FideliteStrategies
    {
        public static IFideliteFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterFideliteByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterFideliteByName();

                default:
                    return new FilterFideliteByName();
            }
        }
    }
}
