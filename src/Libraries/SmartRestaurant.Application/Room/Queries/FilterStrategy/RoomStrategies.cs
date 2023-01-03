namespace SmartRestaurant.Application.Rooms.Queries.FilterStrategy
{
    public static class RoomStrategies
    {
        public static IRoomsFilterStrategy GetFilterStrategy(string currentFilter)
        {
            if (string.IsNullOrWhiteSpace(currentFilter))
                return new FilterRoomByNumber();

            switch (currentFilter.ToLower())
            {
                case "name":
                    return new FilterRoomByNumber();

                default:
                    return new FilterRoomByNumber();
            }
        }
    }
}
