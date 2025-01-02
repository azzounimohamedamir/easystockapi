using SmartRestaurant.Application.GestionVentes.VenteParBl.Queries.FilterStrategy;

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
