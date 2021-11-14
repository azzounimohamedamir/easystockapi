using System;
using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Dishes.Commands;
using SmartRestaurant.Application.FoodBusiness.Commands;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using SmartRestaurant.Application.FoodBusinessEmployee.Commands;
using SmartRestaurant.Application.Illness.Commands;
using SmartRestaurant.Application.Ingredients.Commands;
using SmartRestaurant.Application.LinkedDevice.Commands;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Orders.Commands;
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

            CreateMap<UpdateFoodBusinessCommand, Domain.Entities.FoodBusiness>()
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
                .ForMember(x => x.TableState, o => o.MapFrom(p => (short)p.TableState))
                .ReverseMap();
            CreateMap<Menu, CreateMenuCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.MenuId))
                .ForMember(x => x.MenuState, o => o.MapFrom(p => (int)p.MenuState))
                .ReverseMap();
            CreateMap<Menu, UpdateMenuCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.MenuId))
                .ForMember(x => x.MenuState, o => o.MapFrom(p => (int)p.MenuState))
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


            CreateMap<CreateIngredientCommand, Ingredient>()
                .ForMember(x => x.IngredientId, o => o.MapFrom(p => p.Id))
                .ForMember(x => x.Names, o => o.MapFrom(p => p.Names))
                .ForMember(x => x.Picture, o => o.Ignore());


            CreateMap<UpdateIngredientCommand, Ingredient>()
                .ForMember(x => x.IngredientId, o => o.MapFrom(p => p.Id))
                .ForMember(x => x.Names, o => o.MapFrom(p => p.Names))
                .ForMember(x => x.Picture, o => o.Ignore());

            CreateMap<Ingredient, IngredientDto>()
                .ForMember(x => x.Picture, o => o.MapFrom(p => Convert.ToBase64String(p.Picture)))
                .ForMember(x => x.Names, o => o.MapFrom(p => JsonConvert.DeserializeObject<List<IngredientNameDto>>(p.Names)));

            CreateMap<PagedResultBase<Ingredient>, PagedListDto<IngredientDto>>().ReverseMap();

            CreateMap<CreateDishCommand, Dish>()
                .ForMember(x => x.DishId, o => o.MapFrom(p => p.Id))
                .ForMember(x => x.Ingredients, o => o.MapFrom(p => p.Ingredients))
                .ForMember(x => x.Supplements, o => o.MapFrom(p => p.Supplements))
                .ForMember(x => x.Specifications, o => o.MapFrom(p => p.Specifications))
                .ForMember(x => x.Picture, o => o.MapFrom(p => Convert.FromBase64String(p.Picture)));


            CreateMap<UpdateDishCommand, Dish>()
                .ForMember(x => x.DishId, o => o.MapFrom(p => p.Id))
                .ForMember(x => x.Ingredients, o => o.MapFrom(p => p.Ingredients))
                .ForMember(x => x.Supplements, o => o.MapFrom(p => p.Supplements))
                .ForMember(x => x.Specifications, o => o.MapFrom(p => p.Specifications))
                .ForMember(x => x.Picture, o => o.MapFrom(p => Convert.FromBase64String(p.Picture)));

            CreateMap<Dish, DishDto>()
                .ForMember(x => x.Picture, o => o.MapFrom(p => Convert.ToBase64String(p.Picture)))
                .ReverseMap();

            CreateMap<DurationDto, Duration>()
                .ReverseMap();

            CreateMap<Quantity, QuantityDto>()
                .ForMember(x => x.MeasurementUnit, o => o.MapFrom(p => p.MeasurementUnits.ToString()))
                .ReverseMap();

            CreateMap<PagedResultBase<Dish>, PagedListDto<DishDto>>()
                .ReverseMap();

            CreateMap<DishSpecification, DishSpecificationDto>()
                .AfterMap((src, dest) => dest.ComboBoxContent = new List<string>((String.IsNullOrWhiteSpace(src.ComboBoxContent)) ? new string[0] : src.ComboBoxContent.Split(';')));

            CreateMap<DishSpecificationDto, DishSpecification>()
                .ForMember(x => x.ComboBoxContent, o => o.MapFrom(p => string.Join(";", p.ComboBoxContent)));

            CreateMap<DishIngredientCreateDto, DishIngredient>()
                .ReverseMap();

            CreateMap<DishSupplementCreateDto, DishSupplement>()
                .ReverseMap();

            CreateMap<DishIngredientDto, DishIngredient>()
                .ReverseMap();

            CreateMap<DishSupplement, DishSupplementDto>()
                .ForMember(x => x.DishId, o => o.MapFrom(p => p.Supplement.DishId))
                .ForMember(x => x.Name, o => o.MapFrom(p => p.Supplement.Name))
                .ForMember(x => x.Description, o => o.MapFrom(p => p.Supplement.Description))
                .ForMember(x => x.Picture, o => o.MapFrom(p => Convert.ToBase64String(p.Supplement.Picture)))
                .ForMember(x => x.Price, o => o.MapFrom(p => p.Supplement.Price))
                .ForMember(x => x.EnergeticValue, o => o.MapFrom(p => p.Supplement.EnergeticValue))
                .ReverseMap();

            CreateMap<CreateOrderCommand, Order>()
                .ForMember(x => x.OrderId, o => o.MapFrom(p => p.Id));

            CreateMap<OrderDishDto, OrderDish>()
                .ReverseMap();

            CreateMap<OrderProductDto, OrderProduct>()
                .ReverseMap();

            CreateMap<OrderDishDto, OrderDish>()
                .ReverseMap();

            CreateMap<OrderProductDto, OrderProduct>()
                .ReverseMap();

            CreateMap<OrderDishIngredientDto, OrderDishIngredient>()
                .ReverseMap();

            CreateMap<OrderDishSpecification, OrderDishSpecificationDto>()
                .AfterMap((src, dest) => dest.ComboBoxContent = new List<string>((string.IsNullOrWhiteSpace(src.ComboBoxContent)) ? new string[0] : src.ComboBoxContent.Split(';')));

            CreateMap<OrderDishSpecificationDto, OrderDishSpecification>()
                .ForMember(x => x.ComboBoxContent, o => o.MapFrom(p => string.Join(";", p.ComboBoxContent)));

            CreateMap<OrderDishSupplementDto, OrderDishSupplement>()
                .ReverseMap();

            CreateMap<OrderOccupiedTableDto, OrderOccupiedTable>()
                .ReverseMap();

            CreateMap<OrderIngredientDto, OrderIngredient>()
                .ReverseMap();

            CreateMap<EnergeticValueDto, EnergeticValue>()
                .ReverseMap();

            CreateMap<TakeoutDetailsDto, TakeoutDetails>()
                .ReverseMap();

            CreateMap<Order, UpdateOrderCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.OrderId))
                .ReverseMap();

            CreateMap< UpdateOrderStatusCommand, Order>();

            CreateMap<Order, OrderDto>();

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
            CreateMap<Domain.Entities.FoodBusinessClient, FoodBusinessClientDto>()
               .ForMember(x => x.FoodBusinessClientId, o => o.MapFrom(p => p.FoodBusinessClientId))
               .ReverseMap();

            CreateMap<AddProductToSectionCommand, SectionProduct>();

            CreateMap<AddDishToSectionCommand, SectionDish>();

            CreateMap<Product, MenuItemDto>()
                .ForMember(x => x.MenuItemId, o => o.MapFrom(p => p.ProductId))
                .ForMember(x => x.Picture, o => o.MapFrom(p => Convert.ToBase64String(p.Picture)))
                .ForMember(x => x.Type, o => o.MapFrom(p => MenuItemType.Product));

            CreateMap<Dish, MenuItemDto>()
                .ForMember(x => x.MenuItemId, o => o.MapFrom(p => p.DishId))
                .ForMember(x => x.Picture, o => o.MapFrom(p => Convert.ToBase64String(p.Picture)))
                .ForMember(x => x.Type, o => o.MapFrom(p => MenuItemType.Dish));

            CreateMap<AddProductToSubSectionCommand, SubSectionProduct>();

            CreateMap<AddDishToSubSectionCommand, SubSectionDish>();

            CreateMap<CreateIllnessCommand, Domain.Entities.Illness>()
                .ForMember(x => x.IllnessId, o => o.MapFrom(p => p.Id))
                .ForMember(x => x.IngredientIllnesses, o=> o.MapFrom(p => p.Ingredients));
            CreateMap<UpdateIllnessCommand, Domain.Entities.Illness>()
                .ForMember(x => x.IllnessId, o => o.MapFrom(p => p.Id))
                .ForMember(x => x.IngredientIllnesses, o => o.MapFrom(p => p.Ingredients))
                .ReverseMap();

            CreateMap<Domain.Entities.Illness, IllnessDto>()
               .ForMember(x => x.IllnessId, o => o.MapFrom(p => p.IllnessId))
                .ForMember(x => x.Ingredients, o => o.MapFrom(p => p.IngredientIllnesses))
               .ReverseMap();

            CreateMap<IngredientIllnessDto, IngredientIllness>();
          
        }
    }
}