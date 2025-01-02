

namespace SmartRestaurant.Application.AdminArea.Queries.FilterStrategy
{
    public static class ClAppStrategies
    {
        public static IClAppFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterClAppByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterClAppByName();

                default:
                    return new FilterClAppByName();
            }
        }
    }
}
