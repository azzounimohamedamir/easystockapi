using AutoMapper;
using SmartRestaurant.Application.Tests.Configuration;
using Xunit;

namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class ZoneMappingTest : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;

        public ZoneMappingTest(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }
    }
}
