namespace SmartRestaurant.Application.GestionVentes.FacturesAvoirs.Queries.FilterStrategy
{
    public static class AvoirStrategies
    {
        public static IAvoirFilterStrategy GetFilterStrategy()
        {

            return new FilterAvoirbyName();

        }
    }
}
