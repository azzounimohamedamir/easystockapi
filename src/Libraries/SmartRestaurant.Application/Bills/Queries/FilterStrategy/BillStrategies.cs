namespace SmartRestaurant.Application.Bills.Queries.FilterStrategy
{
    public static class BillStrategies
    {
        public static IBillFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterBillsByNumber();

            switch (currentFilter.ToLower())
            {
                case "number":
                    return new FilterBillsByNumber();
                default:
                    return new FilterBillsByNumber();
            }
        }
    }
}
