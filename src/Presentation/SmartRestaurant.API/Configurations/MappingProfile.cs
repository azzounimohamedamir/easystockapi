using AutoMapper;
using SmartRestaurant.API.Models;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.API.Configurations
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUserModel, ApplicationUser>().ReverseMap();
        }
    }
}
