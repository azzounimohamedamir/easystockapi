using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Restaurants.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace SmartRestaurant.Application.IntegrationTests.IntegrationTest
{
    
    public class RestaurantIntegrationTest
    {
        [Fact]
        public void CreateRestaurant_SouldSaveDB()
        {
            Restaurant restaurant = new Restaurant
            {
                NameArabic = "تاج محل",
                NameFrench = "Taj mahal",
                NameEnglish = "Taj mahal",
                Address = { City = "Algiers", StreetAddress = "Bznknoun", GeoPosition = { Longitude = "332444", Latitude = "2324342" } },
                PhoneNumber = { CountryCode = 00213, Number = 555064434 },
                Description = "Restaurant indien"

            };
            CreateRestaurantCommand createRestaurantCommand = new CreateRestaurantCommand();
            Restaurant RestaurantFind = new Restaurant();
            RestaurantFind.Should().BeEquivalentTo(restaurant);


        }
        //deleteRestaurant_ShouldSaveDB
    }
}
