using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Dishes.Commands;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Application.Products.Commands;
using SmartRestaurant.Application.Reclamation.Commands;
using SmartRestaurant.Domain.Common.Enums;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;

    public class OrderTestTools
    {
        public static async Task<CreateOrderCommand> CreateOrder(Guid foodBusinessId,
             string? foodBusinessClientId,
             CreateDishCommand dishCommand,
             CreateProductCommand procuctCommand)
        {
            OrderDishSpecificationDto CheckBox = new OrderDishSpecificationDto()
            {
                ContentType = ContentType.CheckBox,
                Names = new NamesDto() { AR = "Slaty ar", EN = "Slaty en", FR = "Slaty fr", TR = "Slaty tr", RU = "Slaty ru" },
                Title = "Slaty",
                CheckBoxContent = false,
                ComboBoxContent = null,
                CheckBoxSelection = false,
                ComboBoxSelection = null
            };

            OrderDishSpecificationDto ComboBox = new OrderDishSpecificationDto()
            {
                ContentType = ContentType.ComboBox,
                Names = new NamesDto() { AR = "Slaty ar", EN = "Slaty en", FR = "Slaty fr", TR = "Slaty tr", RU = "Slaty ru" },
                Title = "Cuission",
                ComboBoxContentTranslation = new List<TranslationItemDto>()
                        {
                            new TranslationItemDto()
                            {
                                Name="Bien Cuite",
                                Names=new NamesDto() {AR="Bien Cuite ar",EN="Bien Cuite en",FR="Bien Cuite fr",TR="Bien Cuite tr",RU="Bien Cuite ru"}
                            },
                            new Common.Dtos.TranslationItemDto()
                            {
                                    Name="Demi cuisson",
                                Names=new NamesDto() {AR="Demi cuisson ar",EN="Demi cuisson en",FR="Demi cuisson fr",TR="Demi cuisson tr",RU="Demi cuisson ru"}
                            }
                        },
                CheckBoxSelection = false,
                ComboBoxSelection = "Demi cuisson"
            };

            OrderDishIngredientDto Ingredient = new OrderDishIngredientDto()
            {
                IsPrimary = true,
                Amount = 10,
                MinimumAmount = 5,
                MaximumAmount = 25,
                AmountIncreasePerStep = 1,
                PriceIncreasePerStep = 1,
                MeasurementUnits = MeasurementUnits.Gramme,
                Steps = 0,
                OrderIngredient = new OrderIngredientDto()
                {
                    IngredientId = dishCommand.Ingredients[0].IngredientId,
                    Names = new List<IngredientNameDto>{
                    new IngredientNameDto() {Name = "Cooking oil Modified",Language = "en"},
                    new IngredientNameDto() {Name = "Modified زيت الطهي",Language = "ar"},
                    new IngredientNameDto() {Name = "Huile Modified",Language = "fr"}
                    },
                    EnergeticValue = new EnergeticValueDto
                    {
                        Fat = 0,
                        Protein = 0,
                        Carbohydrates = 0,
                        Energy = 0,
                        Amount = 1,
                        MeasurementUnit = MeasurementUnits.Gramme
                    }
                }
            };

            OrderDishSupplementDto Supplement = new OrderDishSupplementDto()
            {
                SupplementId = dishCommand.Supplements[0].SupplementId,
                IsSelected = true
            };

            var createOrderCommand = new CreateOrderCommand
            {
                Type = OrderTypes.DineIn,
                FoodBusinessId = foodBusinessId.ToString(),
                FoodBusinessClientId = foodBusinessClientId,
                TakeoutDetails = new TakeoutDetailsDto()
                {
                    DeliveryTime = DateTime.Now,
                    Type = TakeoutType.Delayed
                },
                OccupiedTables = new List<OrderOccupiedTableDto>() {
                    new OrderOccupiedTableDto { TableId = "44aecd78-59bb-7504-bfff-07c07129ab00" }
                },
                Dishes = new List<OrderDishCommandDto>() {
                     new OrderDishCommandDto {
                      DishId =dishCommand.Id.ToString(),
                      EnergeticValue =  0,
                      TableNumber =  4,
                      ChairNumber =  1,
                      Quantity =  2,
                      TableId="44aecd78-59bb-7504-bfff-07c07129ab00",
                      Specifications = new List<OrderDishSpecificationDto>() { CheckBox, ComboBox },
                      Ingredients =  new List<OrderDishIngredientDto>() { Ingredient },
                      Supplements = new List<OrderDishSupplementDto>() { Supplement },
                    }
                },
                Products = new List<OrderProductDto>() {
                    new OrderProductDto {
                    ProductId =procuctCommand.Id.ToString(),
                    TableNumber =  4,
                    TableId="44aecd78-59bb-7504-bfff-07c07129ab00",
                    ChairNumber =  1,
                    Quantity =  1
                }
            }
            };

            await SendAsync(createOrderCommand);

            return createOrderCommand;
        }



        public static async Task<HotelOrder> CreateOrderSH(CreateDishCommand createDishCommand,CreateProductCommand createProductCommand, Domain.Entities.FoodBusiness foodBusiness, HotelService service , CheckIn checkin , Hotel hotel )
           
        {



            var createOrderSh = new CreateOrderSHCommand
            {
                HotelId = hotel.Id.ToString(),
                CheckinId = checkin.Id.ToString(),
                FoodBusinessId = foodBusiness.FoodBusinessId.ToString(),
                ServiceId = service.Id.ToString(),
                FoodBusinessClientId = null,
                SectionId = service.SectionId,
                OccupiedTables = new List<OrderOccupiedTableDto>() {
                    new OrderOccupiedTableDto { TableId = "44aecd78-59bb-7504-bfff-07c07129ab00" }
                },
                Dishes = new List<OrderDishCommandDto>() {
                     new OrderDishCommandDto {
                      DishId =createDishCommand.Id.ToString(),
                      EnergeticValue =  0,
                      TableNumber =  4,
                      ChairNumber =  1,
                      Quantity =  2,
                      Specifications = new List<OrderDishSpecificationDto>() {  },
                      Ingredients =  new List<OrderDishIngredientDto>() {  },
                      Supplements = new List<OrderDishSupplementDto>() {  },
                    }
                },
                Products = new List<OrderProductDto>() {
                    new OrderProductDto {
                    ProductId =createProductCommand.Id.ToString(),
                    TableNumber =  4,
                    ChairNumber =  1,
                    Quantity =  1
                } },
                GeoPosition = null,
                ParametreValueClient = null,
                RoomId = null
            };

            var hotelOrder =  await SendAsync(createOrderSh);


            return hotelOrder;
        }





        public static async Task<HotelOrder> CreateOrderSHInRoom(CreateDishCommand createDishCommand, CreateProductCommand createProductCommand, Domain.Entities.FoodBusiness foodBusiness, HotelService service, CheckIn checkin, Hotel hotel)

        {



            var createOrderShForRoom = new CreateOrderSHCommand
            {
                HotelId = hotel.Id.ToString(),
                CheckinId = checkin.Id.ToString(),
                FoodBusinessId = foodBusiness.FoodBusinessId.ToString(),
                ServiceId = service.Id.ToString(),
                FoodBusinessClientId = null,
                SectionId = service.SectionId,
                OccupiedTables = new List<OrderOccupiedTableDto>() {},
                Dishes = new List<OrderDishCommandDto>() {
                     new OrderDishCommandDto {
                      DishId =createDishCommand.Id.ToString(),
                      EnergeticValue =  0,
                      TableNumber =  4,
                      ChairNumber =  1,
                      Quantity =  2,
                      Specifications = new List<OrderDishSpecificationDto>() {  },
                      Ingredients =  new List<OrderDishIngredientDto>() {  },
                      Supplements = new List<OrderDishSupplementDto>() {  },
                    }
                },
                Products = new List<OrderProductDto>() {
                    new OrderProductDto {
                    ProductId =createProductCommand.Id.ToString(),
                    TableNumber =  4,
                    ChairNumber =  1,
                    Quantity =  1
                } },
                GeoPosition = null,
                ParametreValueClient = null,
                RoomId = checkin.RoomId.ToString(),
                Type=OrderTypes.InRoom
            };
            var hotelOrderInRoom = await SendAsync(createOrderShForRoom);


            return hotelOrderInRoom;
        }




        public static async Task<HotelOrder> CreateOrderSHwithparamvalue( Domain.Entities.FoodBusiness foodBusiness, HotelService service, CheckIn checkin, Hotel hotel)

        {



            var createOrderShForServiceWithParam = new CreateOrderSHCommand
            {
                HotelId = hotel.Id.ToString(),
                CheckinId = checkin.Id.ToString(),
                FoodBusinessId = service.FoodBusinessID.ToString(),
                ServiceId = service.Id.ToString(),
                FoodBusinessClientId = null,
                SectionId = service.SectionId,
                OccupiedTables = new List<OrderOccupiedTableDto>() { },
                Dishes = null,
                Products = null,
                GeoPosition = null,
                ParametreValueClient = new List< ParametresValue > () {
                 new ParametresValue {
                Names = new Names() { AR = "عدد الحصص", EN = "number of seance", FR = "nombre de seance", TR = "number of seance", RU = "number of seance" },
                    ServiceParametreType = ServiceParametreType.NumericValue,
                    NumberValue =  1,
                    Date =  null,
                    SelectedValue = null,
                }
                },
                RoomId = null
            };
            var hotelOrderWithParamsService = await SendAsync(createOrderShForServiceWithParam);


            return hotelOrderWithParamsService;
        }


        public static async Task<HotelOrder> CreateOrderSHwithQuantity(Domain.Entities.FoodBusiness foodBusiness, HotelService service, CheckIn checkin, Hotel hotel,int quantity)

        {



            var createOrderShForServiceWithQuantity = new CreateOrderSHCommand
            {
                HotelId = hotel.Id.ToString(),
                CheckinId = checkin.Id.ToString(),
                FoodBusinessId = service.FoodBusinessID.ToString(),
                ServiceId = service.Id.ToString(),
                FoodBusinessClientId = null,
                SectionId = service.SectionId,
                OccupiedTables = new List<OrderOccupiedTableDto>() { },
                Dishes = null,
                Products = null,
                GeoPosition = null,
                Quantity= quantity,     
                ParametreValueClient = new List<ParametresValue>() {
                 new ParametresValue {
                Names = new Names() { AR = "عدد الحصص", EN = "number of seance", FR = "nombre de seance", TR = "number of seance", RU = "number of seance" },
                    ServiceParametreType = ServiceParametreType.NumericValue,
                    NumberValue =  1,
                    Date =  null,
                    SelectedValue = null,
                }
                },
                RoomId = null
            };
            var hotelOrderWithQuantityService = await SendAsync(createOrderShForServiceWithQuantity);


            return hotelOrderWithQuantityService;
        }







        public static async Task<CreateOrderCommand> CreateOrderInTable(Guid foodBusinessId,
            string? foodBusinessClientId,
            CreateDishCommand dishCommand,
            CreateProductCommand procuctCommand,string tableId , int chairnumber)
        {
            OrderDishSpecificationDto CheckBox = new OrderDishSpecificationDto()
            {
                ContentType = ContentType.CheckBox,
                Names = new NamesDto() { AR = "Slaty ar", EN = "Slaty en", FR = "Slaty fr", TR = "Slaty tr", RU = "Slaty ru" },
                Title = "Slaty",
                CheckBoxContent = false,
                ComboBoxContent = null,
                CheckBoxSelection = false,
                ComboBoxSelection = null
            };

            OrderDishSpecificationDto ComboBox = new OrderDishSpecificationDto()
            {
                ContentType = ContentType.ComboBox,
                Names = new NamesDto() { AR = "Slaty ar", EN = "Slaty en", FR = "Slaty fr", TR = "Slaty tr", RU = "Slaty ru" },
                Title = "Cuission",
                ComboBoxContentTranslation = new List<TranslationItemDto>()
                        {
                            new TranslationItemDto()
                            {
                                Name="Bien Cuite",
                                Names=new NamesDto() {AR="Bien Cuite ar",EN="Bien Cuite en",FR="Bien Cuite fr",TR="Bien Cuite tr",RU="Bien Cuite ru"}
                            },
                            new Common.Dtos.TranslationItemDto()
                            {
                                    Name="Demi cuisson",
                                Names=new NamesDto() {AR="Demi cuisson ar",EN="Demi cuisson en",FR="Demi cuisson fr",TR="Demi cuisson tr",RU="Demi cuisson ru"}
                            }
                        },
                CheckBoxSelection = false,
                ComboBoxSelection = "Demi cuisson"
            };

            OrderDishIngredientDto Ingredient = new OrderDishIngredientDto()
            {
                IsPrimary = true,
                Amount = 10,
                MinimumAmount = 5,
                MaximumAmount = 25,
                AmountIncreasePerStep = 1,
                PriceIncreasePerStep = 1,
                MeasurementUnits = MeasurementUnits.Gramme,
                Steps = 0,
                OrderIngredient = new OrderIngredientDto()
                {
                    IngredientId = dishCommand.Ingredients[0].IngredientId,
                    Names = new List<IngredientNameDto>{
                    new IngredientNameDto() {Name = "Cooking oil Modified",Language = "en"},
                    new IngredientNameDto() {Name = "Modified زيت الطهي",Language = "ar"},
                    new IngredientNameDto() {Name = "Huile Modified",Language = "fr"}
                    },
                    EnergeticValue = new EnergeticValueDto
                    {
                        Fat = 0,
                        Protein = 0,
                        Carbohydrates = 0,
                        Energy = 0,
                        Amount = 1,
                        MeasurementUnit = MeasurementUnits.Gramme
                    }
                }
            };

            OrderDishSupplementDto Supplement = new OrderDishSupplementDto()
            {
                SupplementId = dishCommand.Supplements[0].SupplementId,
                IsSelected = true
            };

            var createOrderCommand = new CreateOrderCommand
            {
                Type = OrderTypes.DineIn,
                FoodBusinessId = foodBusinessId.ToString(),
                FoodBusinessClientId = foodBusinessClientId,
                TakeoutDetails = new TakeoutDetailsDto()
                {
                    DeliveryTime = DateTime.Now,
                    Type = TakeoutType.Delayed
                },
                OccupiedTables = new List<OrderOccupiedTableDto>() {
                    new OrderOccupiedTableDto { TableId = tableId }
                },
                Dishes = new List<OrderDishCommandDto>() {
                     new OrderDishCommandDto {
                      DishId =dishCommand.Id.ToString(),
                      EnergeticValue =  0,
                      TableNumber =  4,
                      ChairNumber =  chairnumber,
                      Quantity =  2,
                      Specifications = new List<OrderDishSpecificationDto>() { CheckBox, ComboBox },
                      Ingredients =  new List<OrderDishIngredientDto>() { Ingredient },
                      Supplements = new List<OrderDishSupplementDto>() { Supplement },
                    }
                },
                Products = new List<OrderProductDto>() {
                    new OrderProductDto {
                    ProductId =procuctCommand.Id.ToString(),
                    TableNumber =  4,
                    ChairNumber =  chairnumber,
                    Quantity =  1
                }
            }
            };

            await SendAsync(createOrderCommand);

            return createOrderCommand;
        }










        public static async Task<OrderDto> CreateOrderDelivery(Guid foodBusinessId,
          string? foodBusinessClientId,
          CreateDishCommand dishCommand,
          CreateProductCommand procuctCommand,string? language="0",string? longitude="0" )
        {
            OrderDishSpecificationDto CheckBox = new OrderDishSpecificationDto()
            {
                ContentType = ContentType.CheckBox,
                Names = new NamesDto() { AR = "Slaty ar", EN = "Slaty en", FR = "Slaty fr", TR = "Slaty tr", RU = "Slaty ru" },
                Title = "Slaty",
                CheckBoxContent = false,
                ComboBoxContent = null,
                CheckBoxSelection = false,
                ComboBoxSelection = null
            };

            OrderDishSpecificationDto ComboBox = new OrderDishSpecificationDto()
            {
                ContentType = ContentType.ComboBox,
                Names = new NamesDto() { AR = "Slaty ar", EN = "Slaty en", FR = "Slaty fr", TR = "Slaty tr", RU = "Slaty ru" },
                Title = "Cuission",
                ComboBoxContentTranslation = new List<TranslationItemDto>()
                        {
                            new TranslationItemDto()
                            {
                                Name="Bien Cuite",
                                Names=new NamesDto() {AR="Bien Cuite ar",EN="Bien Cuite en",FR="Bien Cuite fr",TR="Bien Cuite tr",RU="Bien Cuite ru"}
                            },
                            new Common.Dtos.TranslationItemDto()
                            {
                                    Name="Demi cuisson",
                                Names=new NamesDto() {AR="Demi cuisson ar",EN="Demi cuisson en",FR="Demi cuisson fr",TR="Demi cuisson tr",RU="Demi cuisson ru"}
                            }
                        },
                CheckBoxSelection = false,
                ComboBoxSelection = "Demi cuisson"
            };

            OrderDishIngredientDto Ingredient = new OrderDishIngredientDto()
            {
                IsPrimary = true,
                Amount = 10,
                MinimumAmount = 5,
                MaximumAmount = 25,
                AmountIncreasePerStep = 1,
                PriceIncreasePerStep = 1,
                MeasurementUnits = MeasurementUnits.Gramme,
                Steps = 0,
                OrderIngredient = new OrderIngredientDto()
                {
                    IngredientId = dishCommand.Ingredients[0].IngredientId,
                    Names = new List<IngredientNameDto>{
                    new IngredientNameDto() {Name = "Cooking oil Modified",Language = "en"},
                    new IngredientNameDto() {Name = "Modified زيت الطهي",Language = "ar"},
                    new IngredientNameDto() {Name = "Huile Modified",Language = "fr"}
                    },
                    EnergeticValue = new EnergeticValueDto
                    {
                        Fat = 0,
                        Protein = 0,
                        Carbohydrates = 0,
                        Energy = 0,
                        Amount = 1,
                        MeasurementUnit = MeasurementUnits.Gramme
                    }
                }
            };

            OrderDishSupplementDto Supplement = new OrderDishSupplementDto()
            {
                SupplementId = dishCommand.Supplements[0].SupplementId,
                IsSelected = true
            };
            var createOrderCommand = new CreateOrderCommand
            {
                GeoPosition = new GeoPositionDto{
                    Latitude=language,
                    Longitude=longitude
                } ,
                Type = OrderTypes.Delivery,
                FoodBusinessId = foodBusinessId.ToString(),
                FoodBusinessClientId = foodBusinessClientId,
                TakeoutDetails = new TakeoutDetailsDto()
                {
                    DeliveryTime = DateTime.Now,
                    Type = TakeoutType.Delayed
                },
                Dishes = new List<OrderDishCommandDto>() {
                     new OrderDishCommandDto {
                      DishId =dishCommand.Id.ToString(),
                      EnergeticValue =  0,
                      TableNumber =  4,
                      ChairNumber =  1,
                      Quantity =  2,
                      Specifications = new List<OrderDishSpecificationDto>() { CheckBox, ComboBox },
                      Ingredients =  new List<OrderDishIngredientDto>() { Ingredient },
                      Supplements = new List<OrderDishSupplementDto>() { Supplement },
                    }
                },
                Products = new List<OrderProductDto>() {
                    new OrderProductDto {
                    ProductId =procuctCommand.Id.ToString(),
                    TableNumber =  4,
                    ChairNumber =  1,
                    Quantity =  1
                }
            }
            };

          var myordercommand=   await SendAsync(createOrderCommand);

            return myordercommand;
        }











        public static async Task<CreateOrderCommand> CreateOrder2(Guid foodBusinessId,
           string? foodBusinessClientId, 
           CreateDishCommand dishCommand,
           CreateProductCommand procuctCommand)
        {
            OrderDishSpecificationDto CheckBox = new OrderDishSpecificationDto()
            {
                ContentType = ContentType.CheckBox,
                Names = new NamesDto() { AR = "Slaty ar", EN = "Slaty en", FR = "Slaty fr", TR = "Slaty tr", RU = "Slaty ru" },
                Title = "Slaty",
                CheckBoxContent = false,
                ComboBoxContent = null,
                CheckBoxSelection = false,
                ComboBoxSelection = null
            };

            OrderDishSpecificationDto ComboBox = new OrderDishSpecificationDto()
            {
                ContentType = ContentType.ComboBox,
                Names = new NamesDto() { AR = "Slaty ar", EN = "Slaty en", FR = "Slaty fr", TR = "Slaty tr", RU = "Slaty ru" },
                Title = "Cuission",
                ComboBoxContentTranslation = new List<TranslationItemDto>()
                        {
                            new TranslationItemDto()
                            {
                                Name="Bien Cuite",
                                Names=new NamesDto() {AR="Bien Cuite ar",EN="Bien Cuite en",FR="Bien Cuite fr",TR="Bien Cuite tr",RU="Bien Cuite ru"}
                            },
                            new Common.Dtos.TranslationItemDto()
                            {
                                    Name="Demi cuisson",
                                Names=new NamesDto() {AR="Demi cuisson ar",EN="Demi cuisson en",FR="Demi cuisson fr",TR="Demi cuisson tr",RU="Demi cuisson ru"}
                            }
                        },
                CheckBoxSelection = false,
                ComboBoxSelection = "Demi cuisson"
            };

            OrderDishIngredientDto Ingredient = new OrderDishIngredientDto()
            {
                IsPrimary = true,
                Amount = 10,
                MinimumAmount = 5,
                MaximumAmount = 25,
                AmountIncreasePerStep = 1,
                PriceIncreasePerStep = 1,
                MeasurementUnits = MeasurementUnits.Gramme,
                Steps = 0,
                OrderIngredient = new OrderIngredientDto()
                {
                    IngredientId = dishCommand.Ingredients[0].IngredientId,
                    Names = new List<IngredientNameDto>{
                    new IngredientNameDto() {Name = "Cooking oil Modified",Language = "en"},
                    new IngredientNameDto() {Name = "Modified زيت الطهي",Language = "ar"},
                    new IngredientNameDto() {Name = "Huile Modified",Language = "fr"}
                    },
                    EnergeticValue = new EnergeticValueDto
                    {
                        Fat = 0,
                        Protein = 0,
                        Carbohydrates = 0,
                        Energy = 0,
                        Amount = 1,
                        MeasurementUnit = MeasurementUnits.Gramme
                    }
                }
            };

            OrderDishSupplementDto Supplement = new OrderDishSupplementDto()
            {
                SupplementId = dishCommand.Supplements[0].SupplementId,
                IsSelected = true
            };

            var createOrderCommand = new CreateOrderCommand
            {
                Type = OrderTypes.DineIn,
                FoodBusinessId = foodBusinessId.ToString(),
                FoodBusinessClientId = foodBusinessClientId,
                TakeoutDetails = new TakeoutDetailsDto()
                {
                    DeliveryTime = DateTime.Now,
                    Type = TakeoutType.Delayed
                },
                OccupiedTables = new List<OrderOccupiedTableDto>() {

                    new OrderOccupiedTableDto { TableId = "44aedd78-59bb-7504-bfff-07c07129ab00" }
                },
                Dishes = new List<OrderDishCommandDto>() {
                     new OrderDishCommandDto {
                      DishId =dishCommand.Id.ToString(),
                      EnergeticValue =  0,
                      TableNumber =  4,
                      ChairNumber =  1,
                      Quantity =  2,
                      Specifications = new List<OrderDishSpecificationDto>() { CheckBox, ComboBox },
                      Ingredients =  new List<OrderDishIngredientDto>() { Ingredient },
                      Supplements = new List<OrderDishSupplementDto>() { Supplement },
                    }
                },
                Products = new List<OrderProductDto>() {
                    new OrderProductDto {
                    ProductId =procuctCommand.Id.ToString(),
                    TableNumber =  4,
                    ChairNumber =  1,
                    Quantity =  1
                }
            }
            };

            await SendAsync(createOrderCommand);

            return createOrderCommand;
        }
        public static  async Task<UpdateOrderStatusCommand> UpdateOrderStatus(CreateOrderCommand createOrderCommand)
        {
            var updateStatusOrderCommand = new UpdateOrderStatusCommand
            {
                Id = createOrderCommand.Id.ToString(),
                Status = OrderStatuses.Cancelled
            };
            await SendAsync(updateStatusOrderCommand);
            return updateStatusOrderCommand;
        }

         public static  async Task<UpdateOrderGeoLocalisationCommand> UpdateOrderGeoLocalisation(CreateOrderCommand createOrderCommand)
        {
            var updateStatusOrderCommand = new UpdateOrderGeoLocalisationCommand
            {
                Id = createOrderCommand.Id.ToString(),
                GeoPosition = new GeoPositionDto{
                    Latitude ="0",
                    Longitude ="0"
                }
            };
            await SendAsync(updateStatusOrderCommand);
            return updateStatusOrderCommand;
        }

    }
}
