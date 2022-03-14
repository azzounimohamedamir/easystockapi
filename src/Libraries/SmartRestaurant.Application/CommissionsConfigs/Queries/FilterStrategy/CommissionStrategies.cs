namespace SmartRestaurant.Application.Commissions.Queries.FilterStrategy
{
    public static class CommissionStrategies
    {
        public static ICommissionFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterCommissionsByFoodBusinessesName();

            switch (currentFilter.ToLower())
            {
                case "foodbusinessname":
                    return new FilterCommissionsByFoodBusinessesName();

                default:
                    return new FilterCommissionsByFoodBusinessesName();
            }
        }
    }
}
