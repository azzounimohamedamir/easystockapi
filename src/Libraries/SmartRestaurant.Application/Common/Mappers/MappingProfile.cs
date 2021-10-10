using System;
using System.Collections.Generic;
using AutoMapper;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Dishes.Commands;
using SmartRestaurant.Application.DishIngredients.Commands;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using SmartRestaurant.Application.FoodBusinessEmployee.Commands;
using SmartRestaurant.Application.Ingredients.Commands;
using SmartRestaurant.Application.LinkedDevice.Commands;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Application.Orders.Commands.Requests;
using SmartRestaurant.Application.Orders.Queries.Responses;
using SmartRestaurant.Application.Products.Commands;
using SmartRestaurant.Application.Reservations.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.SubSections.Commands;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Users.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.ValueObjects;

namespace SmartRestaurant.Application.Common.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.FoodBusiness, FoodBusinessDto>()
                .AfterMap((src, dest) => dest.Tags = new List<string>((String.IsNullOrWhiteSpace(src.Tags)) ? new string[0] : src.Tags.Split(';')))
                .ReverseMap();

            CreateMap<CreateFoodBusinessCommand, Domain.Entities.FoodBusiness>()
                .ForMember(x => x.FoodBusinessId, o => o.MapFrom(p => p.Id))
                .ForMember(x => x.Tags, o => o.MapFrom(p => string.Join(";", p.Tags)))
                .ReverseMap();

            CreateMap<UpdateFoodBusinessCommand, Domain.Entities.FoodBusiness> ()
                .ForMember(x => x.FoodBusinessId, o => o.MapFrom(p => p.Id))
                .ForMember(x => x.Tags, o => o.MapFrom(p => string.Join(";", p.Tags)))
                .ReverseMap();
            CreateMap<GeoPosition, GeoPositionDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<PhoneNumber, PhoneNumberDto>().ReverseMap();
            CreateMap<Zone, CreateZoneCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.ZoneId))
                .ReverseMap();
            CreateMap<Zone, UpdateZoneCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.ZoneId))
                .ReverseMap();
            CreateMap<ZoneDto, Zone>().ReverseMap();
            CreateMap<TableDto, Table>().ReverseMap();
            CreateMap<CreateTableCommand, Table>()
                .ForMember(x => x.TableId, o => o.MapFrom(p => p.Id))
                .ForMember(x => x.TableState, o => o.MapFrom(p => (short)TableState.Available));
            CreateMap<Table, UpdateTableCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.TableId))
                .ForMember(x => x.TableState, o => o.MapFrom(p => (short) p.TableState))
                .ReverseMap();
            CreateMap<Menu, CreateMenuCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.MenuId))
                .ForMember(x => x.MenuState, o => o.MapFrom(p => (int) p.MenuState))
                .ReverseMap();
            CreateMap<Menu, UpdateMenuCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.MenuId))
                .ForMember(x => x.MenuState, o => o.MapFrom(p => (int) p.MenuState))
                .ReverseMap();
            CreateMap<Menu, MenuDto>().ReverseMap();
            CreateMap<Section, SectionDto>().ReverseMap();
            CreateMap<SubSection, SubSectionDto>().ReverseMap();
            CreateMap<SubSection, CreateSubSectionCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.SubSectionId))
                .ReverseMap();
            CreateMap<Section, CreateSectionCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.SectionId))
                .ReverseMap();
            CreateMap<Section, UpdateSectionCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.SectionId))
                .ReverseMap();
            CreateMap<CreateReservationCommand, Reservation>()
                .ForMember(x => x.ReservationId, o => o.MapFrom(p => p.Id))
                .ReverseMap();

            CreateMap<UpdateReservationCommand, Reservation>(MemberList.Destination)
                .ForMember(x => x.ReservationId, o => o.MapFrom(p => p.Id))
                .ReverseMap();
            CreateMap<UpdateSubSectionCommand, SubSection>()
                .ForMember(x => x.SubSectionId, o => o.MapFrom(p => p.Id))
                .ReverseMap();
            CreateMap<Reservation, ReservationDto>()
                .ReverseMap();
            CreateMap<Reservation, ReservationClientDto>()
                .ForMember(x => x.FoodBusinessName, o => o.MapFrom(p => p.FoodBusiness.Name));
            CreateMap<CreateLinkedDeviceCommand, Domain.Entities.LinkedDevice>()
                .ForMember(x => x.LinkedDeviceId, o => o.MapFrom(p => p.Id));
            CreateMap<Domain.Entities.LinkedDevice, LinkedDeviceDto>()
                .ForMember(x => x.IdentifierDevice, o => o.MapFrom(p => p.IdentifierDevice)).ReverseMap();

            CreateMap<UpdateLinkedDeviceCommand, Domain.Entities.LinkedDevice>()
                .ReverseMap();

            CreateMap<ApplicationUser, FoodBusinessEmployeesDtos>()
                .ReverseMap();

            CreateMap<InviteUserToJoinOrganizationCommand, ApplicationUser>()
                .ForMember(x => x.UserName, o => o.MapFrom(p => p.Email));

            CreateMap<UserAcceptsInvitationToJoinOrganizationCommand, ApplicationUser>()
                .ForMember(x => x.Email, o => o.Ignore());

            CreateMap<ApplicationUser, FoodBusinessManagersDto>()
                .ForMember(x => x.FoodBusinesses, o => o.MapFrom(p => new List<Domain.Entities.FoodBusiness>()))
                .ReverseMap();
            CreateMap<UpdateFourDigitCodeCommand, Domain.Entities.FoodBusiness>()
                .ForMember(x => x.FoodBusinessId, o => o.MapFrom(p => p.Id)).ReverseMap();

            CreateMap<UpdateUserCommand, ApplicationUser>()
               .ReverseMap();
               
            CreateMap<ApplicationUser, ApplicationUserDto>()
                .ReverseMap();
            
             
            CreateMap<Ingredient, CreateIngredientCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.IngredientId))
                .ReverseMap();
            CreateMap<Ingredient, UpdateIngredientCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.IngredientId))
                .ReverseMap();
            CreateMap<IngredientDto, Ingredient>().ReverseMap();
            CreateMap<PagedResultBase<Ingredient>, PagedListDto<IngredientDto>>().ReverseMap();

            CreateMap<Dish, CreateDishCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.DishId))
                .ReverseMap();
            CreateMap<Dish, UpdateDishCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.DishId))
                .ReverseMap();
            CreateMap<DishDto, Dish>().ReverseMap();
            CreateMap<DurationDto, Duration>().ReverseMap();
            CreateMap<Quantity, QuantityDto>()
                .ForMember(x => x.MeasurementUnit, o => o.MapFrom(p => p.MeasurementUnits.ToString()))
                .ReverseMap();
            CreateMap<PagedResultBase<Dish>, PagedListDto<DishDto>>().ReverseMap();

            CreateMap<DishIngredient, CreateDishIngredientCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.DishIngredientId))
                .ReverseMap();
            CreateMap<DishIngredientDto, DishIngredient>().ReverseMap();

            CreateMap<Order, CreateOrderCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.OrderId))
                .ReverseMap();
            CreateMap<Order, UpdateOrderCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.OrderId))
                .ReverseMap();
            CreateMap<OrderDish, OrderDishResponse>().ReverseMap();
            CreateMap<OrderDishIngredient, OrderDishIngredientResponse>().ReverseMap();
            CreateMap<Order, OrderResponse>()
                .ForMember(x => x.OrderType, o => o.MapFrom(p => p.OrderType.ToString()))
                .ReverseMap();
            CreateMap<OrderDish, OrderDishRequest>().ReverseMap();
            CreateMap<OrderDishIngredient, OrderDishIngredientRequest>().ReverseMap();

            CreateMap<CreateFoodBusinessClientCommand, Domain.Entities.FoodBusinessClient>()
                .ForMember(x => x.FoodBusinessClientId, o => o.MapFrom(p => p.Id))
                .ReverseMap();
            CreateMap<UpdateFoodBusinessClientCommand, Domain.Entities.FoodBusinessClient>()
                .ForMember(x => x.FoodBusinessClientId, o => o.MapFrom(p => p.Id))
                .ReverseMap();

            CreateMap<CreateProductCommand, Product>()
                .ForMember(x => x.ProductId, o => o.MapFrom(p => p.Id))
                .ForMember(x => x.FoodBusinessId, o => o.MapFrom(p => p.FoodBusinessId))
                .ForMember(x => x.Picture, o => o.Ignore());

            CreateMap<UpdateProductCommand, Product>()
               .ForMember(x => x.ProductId, o => o.MapFrom(p => p.Id))
               .ForMember(x => x.Picture, o => o.Ignore());

            CreateMap<Product, ProductDto>()
               .ForMember(x => x.Picture, o => o.MapFrom(p => Convert.ToBase64String(p.Picture)));
            CreateMap<Domain.Entities.FoodBusinessClient,FoodBusinessClientDto>()
               .ForMember(x => x.FoodBusinessClientId, o => o.MapFrom(p => p.FoodBusinessClientId))
               .ReverseMap();
        }
    }
}