namespace SmartRestaurant.Application.GestionAchats.BonCommandeFournisseur.Queries.FilterStrategy
{
    public static class BCFStrategies
    {
        public static IBCFFilterStrategy GetFilterStrategy()
        {

            return new FilterBCFByName();

        }
    }
}
