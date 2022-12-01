namespace SmartRestaurant.Application.Orders.Queries.FilterStrategy
{
    public static class OrderStrategies
    {
        public static IOrderFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterOrdersByNumber();

            switch (currentFilter.ToLower())
            {
                case "number":
                    return new FilterOrdersByNumber();
                default:
                    return new FilterOrdersByNumber();
            }
        } 
    }
}
