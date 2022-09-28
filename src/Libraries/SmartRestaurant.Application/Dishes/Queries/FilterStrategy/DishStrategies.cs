namespace SmartRestaurant.Application.Dishes.Queries.FilterStrategy
{
    public static class DishesStrategies
    {
        public static IDishesFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterDishesByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterDishesByName();
                default:
                    return new FilterDishesByName();
            }
        }
    }
}
