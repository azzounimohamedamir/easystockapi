namespace SmartRestaurant.Persistence.ApplicationDataBase.Seed
{
    internal static class FoodsSeed
    {
        internal static void SeedFoods(SmartRestaurantDbContext context)
        {

            context.SaveChangesAsync();
        }


    }
}
