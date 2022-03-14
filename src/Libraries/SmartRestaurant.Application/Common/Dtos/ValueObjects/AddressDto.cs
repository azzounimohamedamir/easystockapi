namespace SmartRestaurant.Application.Common.Dtos.ValueObjects
{
    public class AddressDto
    {
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public GeoPositionDto GeoPosition { get; set; }
    }
}