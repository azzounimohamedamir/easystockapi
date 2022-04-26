using System;
using System.Collections.Generic;
using AutoMapper;
using Newtonsoft.Json;
using SmartRestaurant.Application.commisiones.Commands;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.BillDtos;
using SmartRestaurant.Application.Common.Dtos.CommissionsDtos;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Tools;
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
                .ForMember(x => x.CommissionConfigs, o => o.MapFrom(p => new CommissionConfigs()))
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
            CreateMap<ZoneWithTablesDto, Zone>()
                .ForMember(x => x.Tables, o => o.MapFrom(p => p.Tables))
                .ReverseMap();
            CreateMap<CreateTableCommand, Table>()
                .ForMember(x => x.TableId, o => o.MapFrom(p => p.Id))
                .ForMember(x => x.TableState, o => o.MapFrom(p => (short)TableState.Available));
            CreateMap<Table, UpdateTableCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.TableId))
                .ForMember(x => x.TableState, o => o.MapFrom(p => (short)p.TableState))
                .ReverseMap();

            CreateMap<CreateMenuCommand, Menu>()
                .ForMember(x => x.MenuId, o => o.MapFrom(p => p.Id))
                .ForMember(x => x.MenuState, o => o.MapFrom(p => MenuState.Disabled));

            CreateMap<UpdateMenuCommand, Menu>()
                .ForMember(x => x.MenuId, o => o.MapFrom(p => p.Id));

            CreateMap<Menu, MenuDto>().ReverseMap();

            CreateMap<Menu, ActiveMenuDto>().ReverseMap();

            CreateMap<Section, SectionDto>().ReverseMap();

            CreateMap<Section, ActiveSectionDto>()
                .ForPath(x => x.MenuItems.Dishes, o => o.MapFrom(p => p.Dishes))
                .ForPath(x => x.MenuItems.Products, o => o.MapFrom(p => p.Products))           
                .ReverseMap();

            CreateMap<SectionDish, DishDto>()
                .ForMember(x => x.DishId, o => o.MapFrom(p => p.Dish.DishId))
                .ForMember(x => x.Name, o => o.MapFrom(p => p.Dish.Name))
                .ForMember(x => x.Description, o => o.MapFrom(p => p.Dish.Description))
                .ForMember(x => x.Price, o => o.MapFrom(p => p.Dish.Price))
                .ForMember(x => x.EnergeticValue, o => o.MapFrom(p => p.Dish.EnergeticValue))
                .ForMember(x => x.FoodBusinessId, o => o.MapFrom(p => p.Dish.FoodBusinessId))
                .ForMember(x => x.Ingredients, o => o.MapFrom(p => p.Dish.Ingredients))
                .ForMember(x => x.Supplements, o => o.MapFrom(p => p.Dish.Supplements))
                .ForMember(x => x.Specifications, o => o.MapFrom(p => p.Dish.Specifications))
                .ForMember(x => x.Picture, o => o.MapFrom(p => Convert.ToBase64String(p.Dish.Picture)))
                .ForMember(x => x.EstimatedPreparationTime, o => o.MapFrom(p => p.Dish.EstimatedPreparationTime));


            CreateMap<SectionProduct, ProductDto>()
                .ForMember(x => x.ProductId, o => o.MapFrom(p => p.Product.ProductId))
                .ForMember(x => x.Name, o => o.MapFrom(p => p.Product.Name))
                .ForMember(x => x.Description, o => o.MapFrom(p => p.Product.Description))
                .ForMember(x => x.Price, o => o.MapFrom(p => p.Product.Price))
                .ForMember(x => x.EnergeticValue, o => o.MapFrom(p => p.Product.EnergeticValue))
                .ForMember(x => x.FoodBusinessId, o => o.MapFrom(p => p.Product.FoodBusinessId))
                .ForMember(x => x.Picture, o => o.MapFrom(p => Convert.ToBase64String(p.Product.Picture)));

            CreateMap<SubSection, SubSectionDto>().ReverseMap();

            CreateMap<SubSection, ActiveSubSectionDto>()
                .ForPath(x => x.MenuItems.Dishes, o => o.MapFrom(p => p.Dishes))
                .ForPath(x => x.MenuItems.Products, o => o.MapFrom(p => p.Products))
                .ReverseMap();

            CreateMap<SubSectionDish, DishDto>()
                .ForMember(x => x.DishId, o => o.MapFrom(p => p.Dish.DishId))
                .ForMember(x => x.Name, o => o.MapFrom(p => p.Dish.Name))
                .ForMember(x => x.Description, o => o.MapFrom(p => p.Dish.Description))
                .ForMember(x => x.Price, o => o.MapFrom(p => p.Dish.Price))
                .ForMember(x => x.EnergeticValue, o => o.MapFrom(p => p.Dish.EnergeticValue))
                .ForMember(x => x.FoodBusinessId, o => o.MapFrom(p => p.Dish.FoodBusinessId))
                .ForMember(x => x.Ingredients, o => o.MapFrom(p => p.Dish.Ingredients))
                .ForMember(x => x.Supplements, o => o.MapFrom(p => p.Dish.Supplements))
                .ForMember(x => x.Specifications, o => o.MapFrom(p => p.Dish.Specifications))
                .ForMember(x => x.Picture, o => o.MapFrom(p => Convert.ToBase64String(p.Dish.Picture)))
                .ForMember(x => x.EstimatedPreparationTime, o => o.MapFrom(p => p.Dish.EstimatedPreparationTime)); 
            

            CreateMap<SubSectionProduct, ProductDto>()
                .ForMember(x => x.ProductId, o => o.MapFrom(p => p.Product.ProductId))
                .ForMember(x => x.Name, o => o.MapFrom(p => p.Product.Name))
                .ForMember(x => x.Description, o => o.MapFrom(p => p.Product.Description))
                .ForMember(x => x.Price, o => o.MapFrom(p => p.Product.Price))
                .ForMember(x => x.EnergeticValue, o => o.MapFrom(p => p.Product.EnergeticValue))
                .ForMember(x => x.FoodBusinessId, o => o.MapFrom(p => p.Product.FoodBusinessId))
                .ForMember(x => x.Picture, o => o.MapFrom(p => Convert.ToBase64String(p.Product.Picture)));



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
                .ForMember(x => x.OrderId, o => o.MapFrom(p => p.Id))
                .ForMember(x => x.TVA, o => o.MapFrom(p => 19));

            CreateMap<OrderDishCommandDto, OrderDish>();

            CreateMap<OrderProductDto, OrderProduct>()
                .ReverseMap();

            CreateMap<OrderDishDto, OrderDish>()
                .ReverseMap();

            CreateMap<OrderProductDto, OrderProduct>()
                .ReverseMap();

            CreateMap<OrderDishIngredient, OrderDishIngredientDto>()
            .ReverseMap();

            CreateMap<OrderDishSpecification, OrderDishSpecificationDto>()
                .AfterMap((src, dest) => dest.ComboBoxContent = new List<string>((string.IsNullOrWhiteSpace(src.ComboBoxContent)) ? new string[0] : src.ComboBoxContent.Split(';')));

            CreateMap<OrderDishSpecificationDto, OrderDishSpecification>()
                .ForMember(x => x.ComboBoxContent, o => o.MapFrom(p => string.Join(";", p.ComboBoxContent)));

            CreateMap<OrderDishSupplementDto, OrderDishSupplement>()
                .ReverseMap();

            CreateMap<OrderOccupiedTableDto, OrderOccupiedTable>()
                .ReverseMap();

            CreateMap<OrderIngredient, OrderIngredientDto>()
                .ForMember(x => x.Names, o => o.MapFrom(p => JsonConvert.DeserializeObject<List<IngredientNameDto>>(p.Names)));

            CreateMap<OrderIngredientDto, OrderIngredient>()
               .ForMember(x => x.Names, o => o.MapFrom(p => JsonConvert.SerializeObject(p.Names)));         

            CreateMap<EnergeticValueDto, EnergeticValue>()
                .ReverseMap();

            CreateMap<TakeoutDetailsDto, TakeoutDetails>()
                .ReverseMap();

            CreateMap<Order, UpdateOrderCommand>()
                .ForMember(x => x.Id, o => o.MapFrom(p => p.OrderId))
                .ReverseMap();

            CreateMap<Order, BillDto>()
                .ForMember(dest => dest.Tables, opt => opt.MapFrom<BillResolver>())
                .ForMember(dest => dest.TvaPercentage, o => o.MapFrom(p => p.TVA))
                .ForMember(dest => dest.TvaValue, o => o.MapFrom(p => BillHelpers.CalculateTVA(p.TotalToPay, p.TVA)));

            CreateMap<OrderDish, BillDishDto>();
            CreateMap<OrderProduct, BillProductDto>();
            CreateMap<Domain.Entities.FoodBusiness, BillFoodBusinessDto>(); 
            CreateMap<Domain.Entities.FoodBusinessClient, BillFoodBusinessClientDto>();

            CreateMap< UpdateOrderStatusCommand, Order>();

            CreateMap<Order, OrderDto>()
                .ForMember(x => x.CreatedBy, o => o.Ignore())
                .ForMember(x => x.FoodBusiness, o => o.MapFrom(p => p.FoodBusiness))
                .ForMember(x => x.FoodBusinessClient, o => o.MapFrom(p => p.FoodBusinessClient));


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

            CreateMap<SetFoodBusinessCommissionCommand, Domain.Entities.FoodBusiness>()
                .ForMember(x => x.CommissionConfigs, opt => opt.MapFrom<SetFoodBusinessCommissionResolver>());

            CreateMap<Domain.Entities.FoodBusiness, MonthlyCommission>()
                .ForMember(x => x.CommissionConfigs, opt => opt.MapFrom(p => p.CommissionConfigs))
                .ForMember(x => x.FoodBusinessId, opt => opt.MapFrom(p => p.FoodBusinessId))
                .ForMember(x => x.Month, opt => opt.MapFrom(p => DateTimeHelpers.GetLastMonth(DateTime.Now)))
                .ForMember(x => x.MonthlyCommissionId, opt => opt.MapFrom(p => Guid.NewGuid()))
                .ForMember(x => x.Status, opt => opt.MapFrom(p => CommissionStatus.Unpaid));

            CreateMap<Domain.Entities.FoodBusiness, CommissionConfigsDto>()
                    .ForMember(x => x.FoodBusinessName, opt => opt.MapFrom(p => p.Name))
                   .ForMember(x => x.Value, opt => opt.MapFrom(p => p.CommissionConfigs.Value))
                   .ForMember(x => x.Type, opt => opt.MapFrom(p => p.CommissionConfigs.Type))
                   .ForMember(x => x.WhoPay, opt => opt.MapFrom(p => p.CommissionConfigs.WhoPay));

            CreateMap<MonthlyCommission, MonthlyCommissionDto>()
                   .ForMember(x => x.FoodBusinessId, opt => opt.MapFrom(p => p.FoodBusiness.FoodBusinessId))
                   .ForMember(x => x.FoodBusinessName, opt => opt.MapFrom(p => p.FoodBusiness.Name))
                   .ForMember(x => x.DefaultCurrency, opt => opt.MapFrom(p => p.FoodBusiness.DefaultCurrency));

        }
    }
}