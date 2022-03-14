using AutoMapper;
using SmartRestaurant.API.Models.UserModels;
using SmartRestaurant.Domain.Identity.Entities;

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