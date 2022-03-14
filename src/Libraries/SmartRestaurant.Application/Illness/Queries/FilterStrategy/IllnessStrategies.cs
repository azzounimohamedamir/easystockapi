namespace SmartRestaurant.Application.Illness.Queries.FilterStrategy
{
    public static class IllnessStrategies
    {
        public static IIllnessFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterIllnessesByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterIllnessesByName();

                default:
                    return new FilterIllnessesByName();
            }
        }
    }
}
