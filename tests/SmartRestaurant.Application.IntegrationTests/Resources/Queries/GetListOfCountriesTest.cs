using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.Resources.Queries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Resources.Queries
{
    using static Testing;

    [TestFixture]
    public class GetListOfCountriesTest
    {
        [Test]
        public async Task ShouldListOfCountries()
        {
            var listOfCountries = await SendAsync(new GetListOfCountriesQuery());
            listOfCountries.Should().NotBeNull();
            listOfCountries.Should().NotBeEmpty();
            listOfCountries.Should().Contain("\"isoCode\": \"DZ\"");
            listOfCountries.Should().Contain("\"name\"");
            listOfCountries.Should().Contain("\"dialCode\"");
            listOfCountries.Should().Contain("\"isoCode\"");
            listOfCountries.Should().Contain("\"flag\"");
        }
    }
}
