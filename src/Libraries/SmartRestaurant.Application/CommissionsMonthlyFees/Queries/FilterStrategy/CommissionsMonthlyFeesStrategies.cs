namespace SmartRestaurant.Application.CommissionsMonthlyFees.Queries.FilterStrategy
{
    public static class CommissionsMonthlyFeesStrategies
    {
        public static ICommissionsMonthlyFeesFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterCommissionsMonthlyFeesByFoodBusinessesName();

            switch (currentFilter.ToLower())
            {
                case "foodbusinessname":
                    return new FilterCommissionsMonthlyFeesByFoodBusinessesName();

                case "foodbusinessadmin":
                    return new FilterCommissionsMonthlyFeesByFoodBusinessesAdmin();

                default:
                    return new FilterCommissionsMonthlyFeesByFoodBusinessesName();
            }
        }
    }
}
