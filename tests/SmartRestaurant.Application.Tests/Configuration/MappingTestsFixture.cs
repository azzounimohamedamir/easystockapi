using AutoMapper;
using SmartRestaurant.Application.Common.Mappers;

namespace SmartRestaurant.Application.Tests.Configuration
{
    public class MappingTestsFixture
    {
        public MappingTestsFixture()
        {
            ConfigurationProvider = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); });

            Mapper = ConfigurationProvider.CreateMapper();
        }

        public IConfigurationProvider ConfigurationProvider { get; }

        public IMapper Mapper { get; }
    }
}