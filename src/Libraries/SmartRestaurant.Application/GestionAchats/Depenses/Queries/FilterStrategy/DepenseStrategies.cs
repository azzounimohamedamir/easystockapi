namespace SmartRestaurant.Application.Depenses.Queries.FilterStrategy
{
    public static class DepenseStrategies
    {
        public static IDepenseFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterDepenseByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterDepenseByName();

                default:
                    return new FilterDepenseByName();
            }
        }
    }
}
