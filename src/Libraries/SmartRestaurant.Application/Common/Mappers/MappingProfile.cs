using AutoMapper;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Domain.Entities.Globalisation;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Common.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.FoodBusiness, FoodBusinessDto>().ReverseMap();
            CreateMap<Domain.Entities.FoodBusiness, CreateFoodBusinessCommand>()
                .ForMember(x=>x.CmdId , o=>o.MapFrom(p=>p.FoodBusinessId))
                .ReverseMap();
            CreateMap<Domain.Entities.FoodBusiness, UpdateFoodBusinessCommand>()
                .ForMember(x => x.CmdId, o => o.MapFrom(p => p.FoodBusinessId))
                .ReverseMap();
            CreateMap<GeoPosition, GeoPositionDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<PhoneNumber, PhoneNumberDto>().ReverseMap();
        }
    }
}
