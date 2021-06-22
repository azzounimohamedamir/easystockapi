using System.Collections.Generic;

namespace SmartRestaurant.WebApi.Tests.Controllers.FoodBusiness.ViewModels
{
    public class GeoPositionModel
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }

    public class AddressModel
    {
        public AddressModel(GeoPositionModel geoPosition)
        {
            GeoPosition = geoPosition;
        }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public GeoPositionModel GeoPosition { get; set; }
    }

    public class PhoneNumberModel
    {
        public int CountryCode { get; set; }
        public int Number { get; set; }
    }

    public class FoodBusinessModel
    {
        public string FoodBusinessId { get; set; }
        public string Name { get; set; }
        public AddressModel Address { get; set; }
        public PhoneNumberModel PhoneNumber { get; set; }
        public string Description { get; set; }
        public int AverageRating { get; set; }
        public bool HasCarParking { get; set; }
        public bool IsHandicapFriendly { get; set; }
        public bool AcceptsCreditCards { get; set; }
        public bool AcceptTakeout { get; set; }
        public string Tags { get; set; }
        public string Website { get; set; }
        public int FoodBusinessState { get; set; }
        public List<string> Images { get; set; }
    }
}