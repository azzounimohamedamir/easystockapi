using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;
using FluentAssertions;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using System.Collections.Generic;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.FoodBusinessClient.Commands;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Dishes.Commands;
using SmartRestaurant.Application.Products.Commands;

namespace SmartRestaurant.Application.IntegrationTests.Orders.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateOrderTest : TestBase
    {
        OrderDishSpecificationDto CheckBoxModified = new OrderDishSpecificationDto()
        {
            Title = "Spicy Modified",
            Names = new NamesDto() { AR = "Spicy ar", EN = "Spicy en", FR = "Spicy fr", TR = "Slaty tr", RU = "Spicy ru" },
            ContentType = ContentType.CheckBox,
            CheckBoxContent = false,
            ComboBoxContent = null,
            CheckBoxSelection = true,
            ComboBoxSelection = null
        };

        OrderDishSpecificationDto ComboBoxModified = new OrderDishSpecificationDto()
        {
            Title = "Cuisson Modified",
            Names = new NamesDto() { AR = "Cuisson Modified ar", EN = "Cuisson Modified en", FR = "Cuisson Modified fr", TR = "Cuisson Modified tr", RU = "Cuisson Modified ru" },
            ContentType = ContentType.ComboBox,
            CheckBoxContent = true,
            ComboBoxContentTranslation = new List<TranslationItemDto>()
                        {
                            new TranslationItemDto()
                            {
                                Name="Bien Cuite Modified",
                                Names=new NamesDto() {AR="Bien Cuite Modified ar",EN="Bien Cuite Modified en",FR="Bien Cuite Modified fr",TR="Bien Cuite Modified tr",RU="Bien Cuite Modified ru"}
                            },
                            new Common.Dtos.TranslationItemDto()
                            {
                                    Name="Demi cuisson Modified",
                                Names=new NamesDto() {AR="Demi cuisson Modified ar",EN="Demi cuisson Modified en",FR="Demi cuisson Modified fr",TR="Demi cuisson tr",RU="Demi cuisson Modified ru"}
                            }
                        },
            CheckBoxSelection = false,
            ComboBoxSelection = "Demi cuisson Modified"
        };

        OrderDishIngredientDto IngredientModified = new OrderDishIngredientDto()
        {
            IsPrimary = false,
            Amount = 15,
            MinimumAmount = 10,
            MaximumAmount = 20,
            AmountIncreasePerStep = 5,
            PriceIncreasePerStep = 3,
            MeasurementUnits = MeasurementUnits.MilliLiter,
            Steps = 2,
            OrderIngredient = new OrderIngredientDto()
            {
                IngredientId = "72867405-75a6-44bc-ac82-407ea918c8dc",
                Names = new List<IngredientNameDto>{
                    new IngredientNameDto() {Name = "Cooking oil Modified",Language = "en"},
                    new IngredientNameDto() {Name = "Modified زيت الطهي",Language = "ar"},
                    new IngredientNameDto() {Name = "Huile Modified",Language = "fr"}
                    },
                EnergeticValue = new EnergeticValueDto
                {
                    Fat = 1,
                    Protein = 1,
                    Carbohydrates = 1,
                    Energy = 10,
                    Amount = 0.5f,
                    MeasurementUnit = MeasurementUnits.MilliLiter
                }
            }
        };



        [Test]
        public async Task UpdateOrder_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var foodBusinessClient = await CreateFoodBusinessClient(fastFood);
            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);
            await CreateTable(createZoneCommand);

            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createProductCommand = await ProductTestTools.CreateProduct();
            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand);


            var createIngredientCommandToUpdate = await IngredientTestTools.CreateIngredient();
            var createDishCommandToUpdate = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommandToUpdate.Id);
            var createProductCommandToUpdated = await ProductTestTools.CreateProduct();

            var updateOrderCommand = await UpdateOrder(createOrderCommand, foodBusinessClient, 
                createDishCommandToUpdate, createProductCommandToUpdated);

            var order = await GetOrder(Guid.Parse(updateOrderCommand.Id));
            
            var UsedSupplimentInCommand = await GetDish(Guid.Parse(createDishCommandToUpdate.Supplements[0].SupplementId));

            order.OrderId.Should().Be(createOrderCommand.Id);
            order.TotalToPay.Should().Be(836);
            order.FoodBusinessId.Should().Be(Guid.Parse(createOrderCommand.FoodBusinessId));

            order.FoodBusinessClientId.Should().Be(Guid.Parse(updateOrderCommand.FoodBusinessClientId));
            order.OccupiedTables[0].TableId.Should().Be(updateOrderCommand.OccupiedTables[0].TableId);
            order.Products[0].Name.Should().Be(createProductCommandToUpdated.Name);
            order.Products[0].Names.AR.Should().Be(createProductCommandToUpdated.Names.AR);
            order.Products[0].Names.EN.Should().Be(createProductCommandToUpdated.Names.EN);
            order.Products[0].Names.FR.Should().Be(createProductCommandToUpdated.Names.FR);
            order.Products[0].Names.TR.Should().Be(createProductCommandToUpdated.Names.TR);
            order.Products[0].Names.RU.Should().Be(createProductCommandToUpdated.Names.RU);

            order.Products[0].UnitPrice.Should().Be(createProductCommandToUpdated.Price);
            order.Products[0].EnergeticValue.Should().Be(createProductCommandToUpdated.EnergeticValue);
            order.Products[0].Description.Should().Be(createProductCommandToUpdated.Description);
            order.Products[0].TableNumber.Should().Be(updateOrderCommand.Products[0].TableNumber);
            order.Products[0].ChairNumber.Should().Be(updateOrderCommand.Products[0].ChairNumber);
            order.Products[0].Quantity.Should().Be(updateOrderCommand.Products[0].Quantity);

            order.Dishes[0].Name.Should().Be(createDishCommandToUpdate.Name);
            order.Dishes[0].Names.AR.Should().Be(createDishCommandToUpdate.Names.AR);
            order.Dishes[0].Names.EN.Should().Be(createDishCommandToUpdate.Names.EN);
            order.Dishes[0].Names.FR.Should().Be(createDishCommandToUpdate.Names.FR);
            order.Dishes[0].Names.TR.Should().Be(createDishCommandToUpdate.Names.TR);
            order.Dishes[0].Names.RU.Should().Be(createDishCommandToUpdate.Names.RU);

            order.Dishes[0].InitialPrice.Should().Be(createDishCommandToUpdate.Price);
            order.Dishes[0].UnitPrice.Should().Be(386);
            order.Dishes[0].EnergeticValue.Should().Be(300);
            order.Dishes[0].Description.Should().Be(createDishCommandToUpdate.Description);
            order.Dishes[0].EstimatedPreparationTime.Should().Be(createDishCommandToUpdate.EstimatedPreparationTime);
            order.Dishes[0].TableNumber.Should().Be(updateOrderCommand.Dishes[0].TableNumber);
            order.Dishes[0].ChairNumber.Should().Be(updateOrderCommand.Dishes[0].ChairNumber);
            order.Dishes[0].Quantity.Should().Be(updateOrderCommand.Dishes[0].Quantity);

            order.Dishes[0].Specifications[0].Title.Should().Be(updateOrderCommand.Dishes[0].Specifications[0].Title);
            order.Dishes[0].Specifications[0].Names.AR.Should().Be(updateOrderCommand.Dishes[0].Specifications[0].Names.AR);
            order.Dishes[0].Specifications[0].Names.EN.Should().Be(updateOrderCommand.Dishes[0].Specifications[0].Names.EN);
            order.Dishes[0].Specifications[0].Names.FR.Should().Be(updateOrderCommand.Dishes[0].Specifications[0].Names.FR);
            order.Dishes[0].Specifications[0].Names.TR.Should().Be(updateOrderCommand.Dishes[0].Specifications[0].Names.TR);
            order.Dishes[0].Specifications[0].Names.RU.Should().Be(updateOrderCommand.Dishes[0].Specifications[0].Names.RU);

            order.Dishes[0].Specifications[0].ContentType.Should().Be(updateOrderCommand.Dishes[0].Specifications[0].ContentType);
            order.Dishes[0].Specifications[0].ComboBoxContent.Should().BeNull();
            order.Dishes[0].Specifications[0].ComboBoxSelection.Should().Be(updateOrderCommand.Dishes[0].Specifications[0].ComboBoxSelection);
            order.Dishes[0].Specifications[0].CheckBoxContent.Should().Be(updateOrderCommand.Dishes[0].Specifications[0].CheckBoxContent);
            order.Dishes[0].Specifications[0].CheckBoxSelection.Should().Be(updateOrderCommand.Dishes[0].Specifications[0].CheckBoxSelection);
            
            order.Dishes[0].Specifications[1].Title.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].Title);
            order.Dishes[0].Specifications[1].Names.AR.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].Names.AR);
            order.Dishes[0].Specifications[1].Names.EN.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].Names.EN);
            order.Dishes[0].Specifications[1].Names.FR.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].Names.FR);
            order.Dishes[0].Specifications[1].Names.TR.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].Names.TR);
            order.Dishes[0].Specifications[1].Names.RU.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].Names.RU);

            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Name.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Name);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.AR.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.AR);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.EN.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.EN);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.FR.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.FR);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.TR.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.TR);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.RU.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.RU);
                        
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Name.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Name);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.AR.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.AR);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.EN.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.EN);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.FR.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.FR);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.TR.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.TR);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.RU.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.RU);

            order.Dishes[0].Specifications[1].ContentType.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].ContentType);
            
            order.Dishes[0].Specifications[1].ComboBoxSelection.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].ComboBoxSelection);
            order.Dishes[0].Specifications[1].CheckBoxContent.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].CheckBoxContent);
            order.Dishes[0].Specifications[1].CheckBoxSelection.Should().Be(updateOrderCommand.Dishes[0].Specifications[1].CheckBoxSelection);

            order.Dishes[0].Ingredients[0].IsPrimary.Should().Be(updateOrderCommand.Dishes[0].Ingredients[0].IsPrimary);
            order.Dishes[0].Ingredients[0].Amount.Should().Be(updateOrderCommand.Dishes[0].Ingredients[0].Amount);
            order.Dishes[0].Ingredients[0].MinimumAmount.Should().Be(updateOrderCommand.Dishes[0].Ingredients[0].MinimumAmount);
            order.Dishes[0].Ingredients[0].MaximumAmount.Should().Be(updateOrderCommand.Dishes[0].Ingredients[0].MaximumAmount);
            order.Dishes[0].Ingredients[0].AmountIncreasePerStep.Should().Be(updateOrderCommand.Dishes[0].Ingredients[0].AmountIncreasePerStep);
            order.Dishes[0].Ingredients[0].PriceIncreasePerStep.Should().Be(updateOrderCommand.Dishes[0].Ingredients[0].PriceIncreasePerStep);
            order.Dishes[0].Ingredients[0].Steps.Should().Be(updateOrderCommand.Dishes[0].Ingredients[0].Steps);
            order.Dishes[0].Ingredients[0].MeasurementUnits.Should().Be(updateOrderCommand.Dishes[0].Ingredients[0].MeasurementUnits);
            order.Dishes[0].Ingredients[0].OrderIngredient.IngredientId.Should().Be(updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.IngredientId);
            order.Dishes[0].Ingredients[0].OrderIngredient.Names.Should().Be(JsonConvert.SerializeObject(updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.Names));
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat.Should().Be(updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein.Should().Be(updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates.Should().Be(updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy.Should().Be(updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount.Should().Be(updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit.Should().Be(updateOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit);

            order.Dishes[0].Supplements[0].SupplementId.Should().Be(updateOrderCommand.Dishes[0].Supplements[0].SupplementId);
            order.Dishes[0].Supplements[0].Name.Should().Be(UsedSupplimentInCommand.Name);
            order.Dishes[0].Supplements[0].Names.AR.Should().Be(UsedSupplimentInCommand.Names.AR);
            order.Dishes[0].Supplements[0].Names.EN.Should().Be(UsedSupplimentInCommand.Names.EN);
            order.Dishes[0].Supplements[0].Names.FR.Should().Be(UsedSupplimentInCommand.Names.FR);
            order.Dishes[0].Supplements[0].Names.TR.Should().Be(UsedSupplimentInCommand.Names.TR);
            order.Dishes[0].Supplements[0].Names.RU.Should().Be(UsedSupplimentInCommand.Names.RU);

            order.Dishes[0].Supplements[0].Price.Should().Be(UsedSupplimentInCommand.Price);
            order.Dishes[0].Supplements[0].EnergeticValue.Should().Be(UsedSupplimentInCommand.EnergeticValue);
            order.Dishes[0].Supplements[0].Description.Should().Be(UsedSupplimentInCommand.Description);
            order.Dishes[0].Supplements[0].IsSelected.Should().Be(updateOrderCommand.Dishes[0].Supplements[0].IsSelected);

            order.CommissionConfigs.Value.Should().Be(0);
            order.CommissionConfigs.Type.Should().Be(CommissionType.PerPerson);
            order.CommissionConfigs.WhoPay.Should().Be(WhoPayCommission.FoodBusiness);
        }

        private static async Task<Domain.Entities.FoodBusinessClient> CreateFoodBusinessClient(Domain.Entities.FoodBusiness fastFood)
        {
            var createFoodBusinessClientCommand = new CreateFoodBusinessClientCommand
            {
                Address = new AddressDto
                {
                    City = "Algiers",
                    Country = "Algeria",
                    GeoPosition = new GeoPositionDto
                    {
                        Latitude = "0",
                        Longitude = "0"
                    },
                    StreetAddress = "Didouche Mourad"
                },
                Description = "",
                Name = "G22 REI",
                PhoneNumber = new PhoneNumberDto { CountryCode = 213, Number = 670217536 },
                Email = "test@g22rei.com",
                Website = "http://g22rei.com",
                FoodBusinessId = fastFood.FoodBusinessId.ToString()
            };


            await SendAsync(createFoodBusinessClientCommand);
            return await FindAsync<Domain.Entities.FoodBusinessClient>(createFoodBusinessClientCommand.Id);

        }

        private static async Task CreateTable(CreateZoneCommand createZoneCommand)
        {
            var createTableCommand01 = new CreateTableCommand
            {
                Id = Guid.Parse("44aecd78-59bb-7504-bfff-07c07129ab00"),
                Capacity = 4,
                ZoneId = createZoneCommand.Id.ToString()
            };
            await SendAsync(createTableCommand01);

            var createTableCommand02 = new CreateTableCommand
            {
                Id = Guid.Parse("44aecd78-59bb-7504-bfff-07c07129ab20"),
                Capacity = 5,
                ZoneId = createZoneCommand.Id.ToString()
            };
            await SendAsync(createTableCommand02);
        }

        private async Task<UpdateOrderCommand> UpdateOrder(CreateOrderCommand createOrderCommand, 
            Domain.Entities.FoodBusinessClient foodBusinessClient,
            CreateDishCommand dishCommand,
            CreateProductCommand procuctCommand)
        {
            var updateOrderCommand = new UpdateOrderCommand
            {
                Id = createOrderCommand.Id.ToString(),
                FoodBusinessClientId = foodBusinessClient.FoodBusinessClientId.ToString(),
                Type = OrderTypes.DineIn,
                OccupiedTables = new List<OrderOccupiedTableDto>() {
                new OrderOccupiedTableDto { TableId = "44aecd78-59bb-7504-bfff-07c07129ab20" }
                },
                Dishes = new List<OrderDishCommandDto>() {
                new OrderDishCommandDto {
                    DishId =  dishCommand.Id.ToString(),
                    TableNumber =  5,
                    ChairNumber =  2,
                    Quantity =  1,
                    Specifications = new List<OrderDishSpecificationDto>() { CheckBoxModified, ComboBoxModified },
                    Ingredients =  new List<OrderDishIngredientDto>() { IngredientModified },
                    Supplements = new List<OrderDishSupplementDto>() { new OrderDishSupplementDto()
                        {
                            SupplementId =dishCommand.Supplements[0].SupplementId,
                            IsSelected = true
                        } },
                    }
                },
                Products = new List<OrderProductDto>() {
                new OrderProductDto {
                    ProductId =  procuctCommand.Id.ToString(),
                    TableNumber =  5,
                    ChairNumber =  3,
                    Quantity =  3
                    }
                }
            };
            await SendAsync(updateOrderCommand);
            return updateOrderCommand;
        }
    }
}