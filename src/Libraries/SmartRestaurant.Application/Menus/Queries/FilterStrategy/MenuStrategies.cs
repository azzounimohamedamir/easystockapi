namespace SmartRestaurant.Application.Menus.Queries.FilterStrategy
{
    public static class MenuStrategies
    {
        public static IMenuFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterMenusByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterMenusByName();

                default:
                    return new FilterMenusByName();
            }
        }
    }
}
