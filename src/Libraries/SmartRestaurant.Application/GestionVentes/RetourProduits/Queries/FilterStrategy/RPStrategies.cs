namespace SmartRestaurant.Application.GestionVentes.RetourProduits.Queries.FilterStrategy
{
    public static class RPStrategies
    {
        public static IRPFilterStrategy GetFilterStrategy()
        {

            return new FilterRPbyName();

        }
    }
}
