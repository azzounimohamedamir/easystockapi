using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Xunit;

namespace SmartRestaurant.Application.IntegrationTests.IntegrationTest
{
    
    public class AuthTests: IClassFixture<CustomWebApplicationFactory<SmartRestaurant.Web.Startup>>
    {
        private readonly CustomWebApplicationFactory<SmartRestaurant.Web.Startup>
            _factory;

        public AuthTests(
            CustomWebApplicationFactory<SmartRestaurant.Web.Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_SecurePageRedirectsAnUnauthenticatedUser()
        {
            // Arrange
            var client = _factory.CreateClient(
                new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false
                });

            // Act
            var response = await client.GetAsync("/SecurePage");

            // Assert
            Assert.Equal(HttpStatusCode.Redirect, response.StatusCode);
            Assert.StartsWith("http://localhost/Identity/Account/Login",
                response.Headers.Location.OriginalString);
        }

        [Fact]
        public async Task Get_SecurePageIsReturnedForAnAuthenticatedUser()
        {
            // Arrange
            var client = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(IUserService =>
                {
                    IUserService.AddAuthentication("Test")
                        .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                            "Test", options => { });
                });
            })
                .CreateClient(new WebApplicationFactoryClientOptions
                {
                    AllowAutoRedirect = false,
                });

            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Test");

            //Act
            var response = await client.GetAsync("/SecurePage");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        public class TestAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
        {
            public TestAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
                ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock)
                : base(options, logger, encoder, clock)
            {
            }

            protected override Task<AuthenticateResult> HandleAuthenticateAsync()
            {
                var claims = new[] { new Claim(ClaimTypes.Name, "Test user") };
                var identity = new ClaimsIdentity(claims, "Test");
                var principal = new ClaimsPrincipal(identity);
                var ticket = new AuthenticationTicket(principal, "Test");

                var result = AuthenticateResult.Success(ticket);

                return Task.FromResult(result);
            }
        }

    }
}
