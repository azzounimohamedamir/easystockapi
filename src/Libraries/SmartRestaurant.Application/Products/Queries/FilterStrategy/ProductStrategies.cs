namespace SmartRestaurant.Application.Products.Queries.FilterStrategy
{
    public static class ProductStrategies
    {
        public static IProductFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterProductsByName();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterProductsByName();

                case "description":
                    return new FilterProductsByDescription();

                case "price":
                    return new FilterProductsByPrice();

                case "energeticvalue":
                    return new FilterProductsByEnergeticValue();

                default:
                    return new FilterProductsByName();
            }
        }
    }
}
