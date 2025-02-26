namespace SmartRestaurant.Application.Rapports
    .MvtStock.Queries.FilterStrategy
{
    public static class MvtStockStrategies
    {
        public static IMvtStockFilterStrategy GetFilterStrategy()
        {

            return new FilterMvtStockByName();

        }
    }
}
