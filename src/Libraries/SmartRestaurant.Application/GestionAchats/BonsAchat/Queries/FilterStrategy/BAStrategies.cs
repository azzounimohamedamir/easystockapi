namespace SmartRestaurant.Application.GestionAchats.BonsAchat.Queries.FilterStrategy
{
    public static class BAStrategies
    {
        public static IBAFilterStrategy GetFilterStrategy()
        {

            return new FilterBAbyName();

        }
    }
}
