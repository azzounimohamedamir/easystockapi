﻿using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;
using FluentAssertions;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Tables.Commands;
using Newtonsoft.Json;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Dtos;
using System.Collections.Generic;
using SmartRestaurant.Application.Dishes.Commands;
using SmartRestaurant.Application.Products.Commands;

namespace SmartRestaurant.Application.IntegrationTests.Orders.Commands
{
    using static Testing;

    [TestFixture]
    public class AddSeatOrderTest : TestBase
    {
        [Test]
        public async Task AddSeatOrder_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);
            await TablesTestTools.CreateTable(createZoneCommand);

            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createProductCommand = await ProductTestTools.CreateProduct(fastFood.FoodBusinessId);
            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand);


            var createIngredientCommandToAdd = await IngredientTestTools.CreateIngredient();
            var createDishCommandToAdd = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommandToAdd.Id);
            var createProductCommandToAdd = await ProductTestTools.CreateProduct(fastFood.FoodBusinessId);

            var addSeatOrderCommand = await AddSeatOrderToTableOrder(createOrderCommand.Id.ToString(), "44aecd78-59bb-7504-bfff-07c07129ab00", 2, createDishCommandToAdd, createProductCommandToAdd);

            var UsedSupplimentInCommand = await GetDish(Guid.Parse(createDishCommandToAdd.Supplements[0].SupplementId));

            var order = await GetOrder(createOrderCommand.Id);
            var indexOfAddedOrder = 1;
            order.OrderId.Should().Be(createOrderCommand.Id);

            order.Type.Should().Be(OrderTypes.DineIn);
            order.Status.Should().Be(OrderStatuses.InQueue);
            order.FoodBusinessId.Should().Be(Guid.Parse(createOrderCommand.FoodBusinessId));
            order.FoodBusinessClientId.Should().BeNull();
            order.TotalToPay.Should().Be(1746);
            order.OccupiedTables[0].TableId.Should().Be(createOrderCommand.OccupiedTables[0].TableId);


            order.OccupiedTables[0].TableId.Should().Be(addSeatOrderCommand.TableId);
            order.Products[indexOfAddedOrder].Name.Should().Be(createProductCommandToAdd.Name);
            order.Products[indexOfAddedOrder].Names.AR.Should().Be(createProductCommandToAdd.Names.AR);
            order.Products[indexOfAddedOrder].Names.EN.Should().Be(createProductCommandToAdd.Names.EN);
            order.Products[indexOfAddedOrder].Names.FR.Should().Be(createProductCommandToAdd.Names.FR);
            order.Products[indexOfAddedOrder].Names.TR.Should().Be(createProductCommandToAdd.Names.TR);
            order.Products[indexOfAddedOrder].Names.RU.Should().Be(createProductCommandToAdd.Names.RU);

            order.Products[indexOfAddedOrder].UnitPrice.Should().Be(createProductCommandToAdd.Price);
            order.Products[indexOfAddedOrder].EnergeticValue.Should().Be(createProductCommandToAdd.EnergeticValue);
            order.Products[indexOfAddedOrder].Description.Should().Be(createProductCommandToAdd.Description);
            order.Products[indexOfAddedOrder].TableNumber.Should().Be(addSeatOrderCommand.Products[0].TableNumber);
            order.Products[indexOfAddedOrder].ChairNumber.Should().Be(addSeatOrderCommand.Products[0].ChairNumber);
            order.Products[indexOfAddedOrder].Quantity.Should().Be(addSeatOrderCommand.Products[0].Quantity);

            order.Dishes[indexOfAddedOrder].Name.Should().Be(createDishCommandToAdd.Name);
            order.Dishes[indexOfAddedOrder].Names.AR.Should().Be(createDishCommandToAdd.Names.AR);
            order.Dishes[indexOfAddedOrder].Names.EN.Should().Be(createDishCommandToAdd.Names.EN);
            order.Dishes[indexOfAddedOrder].Names.FR.Should().Be(createDishCommandToAdd.Names.FR);
            order.Dishes[indexOfAddedOrder].Names.TR.Should().Be(createDishCommandToAdd.Names.TR);
            order.Dishes[indexOfAddedOrder].Names.RU.Should().Be(createDishCommandToAdd.Names.RU);

            order.Dishes[indexOfAddedOrder].InitialPrice.Should().Be(createDishCommandToAdd.Price);
            order.Dishes[indexOfAddedOrder].UnitPrice.Should().Be(386);
            order.Dishes[indexOfAddedOrder].EnergeticValue.Should().Be(1100);
            order.Dishes[indexOfAddedOrder].Description.Should().Be(createDishCommandToAdd.Description);
            order.Dishes[indexOfAddedOrder].EstimatedPreparationTime.Should().Be(createDishCommandToAdd.EstimatedPreparationTime);
            order.Dishes[indexOfAddedOrder].TableNumber.Should().Be(addSeatOrderCommand.Dishes[0].TableNumber);
            order.Dishes[indexOfAddedOrder].ChairNumber.Should().Be(addSeatOrderCommand.Dishes[0].ChairNumber);
            order.Dishes[indexOfAddedOrder].Quantity.Should().Be(addSeatOrderCommand.Dishes[0].Quantity);

            order.Dishes[indexOfAddedOrder].Specifications[0].Title.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].Title);
            
            order.Dishes[indexOfAddedOrder].Specifications[0].Title.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].Title);
            order.Dishes[indexOfAddedOrder].Specifications[0].Names.AR.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].Names.AR);
            order.Dishes[indexOfAddedOrder].Specifications[0].Names.EN.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].Names.EN);
            order.Dishes[indexOfAddedOrder].Specifications[0].Names.FR.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].Names.FR);
            order.Dishes[indexOfAddedOrder].Specifications[0].Names.TR.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].Names.TR);
            order.Dishes[indexOfAddedOrder].Specifications[0].Names.RU.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].Names.RU);

            order.Dishes[indexOfAddedOrder].Specifications[0].ContentType.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].ContentType);
            order.Dishes[indexOfAddedOrder].Specifications[0].ComboBoxContent.Should().BeNull();
            order.Dishes[indexOfAddedOrder].Specifications[0].ComboBoxSelection.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].ComboBoxSelection);
            order.Dishes[indexOfAddedOrder].Specifications[0].CheckBoxContent.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].CheckBoxContent);
            order.Dishes[indexOfAddedOrder].Specifications[0].CheckBoxSelection.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[0].CheckBoxSelection);
            
            order.Dishes[indexOfAddedOrder].Specifications[1].Title.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].Title);
            order.Dishes[indexOfAddedOrder].Specifications[1].Names.AR.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].Names.AR);
            order.Dishes[indexOfAddedOrder].Specifications[1].Names.EN.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].Names.EN);
            order.Dishes[indexOfAddedOrder].Specifications[1].Names.FR.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].Names.FR);
            order.Dishes[indexOfAddedOrder].Specifications[1].Names.TR.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].Names.TR);
            order.Dishes[indexOfAddedOrder].Specifications[1].Names.RU.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].Names.RU);

            order.Dishes[indexOfAddedOrder].Specifications[1].ContentType.Should().Be(createDishCommand.Specifications[1].ContentType);

            order.Dishes[indexOfAddedOrder].Specifications[1].ComboBoxSelection.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxSelection);
            order.Dishes[indexOfAddedOrder].Specifications[1].CheckBoxContent.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].CheckBoxContent);
            order.Dishes[indexOfAddedOrder].Specifications[1].CheckBoxSelection.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].CheckBoxSelection);

            order.Dishes[indexOfAddedOrder].Specifications[1].ComboBoxContentTranslation[0].Name.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Name);
            order.Dishes[indexOfAddedOrder].Specifications[1].ComboBoxContentTranslation[0].Names.AR.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.AR);
            order.Dishes[indexOfAddedOrder].Specifications[1].ComboBoxContentTranslation[0].Names.EN.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.EN);
            order.Dishes[indexOfAddedOrder].Specifications[1].ComboBoxContentTranslation[0].Names.FR.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.FR);
            order.Dishes[indexOfAddedOrder].Specifications[1].ComboBoxContentTranslation[0].Names.TR.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.TR);
            order.Dishes[indexOfAddedOrder].Specifications[1].ComboBoxContentTranslation[0].Names.RU.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.RU);

            order.Dishes[indexOfAddedOrder].Specifications[1].ComboBoxContentTranslation[1].Name.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Name);
            order.Dishes[indexOfAddedOrder].Specifications[1].ComboBoxContentTranslation[1].Names.AR.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.AR);
            order.Dishes[indexOfAddedOrder].Specifications[1].ComboBoxContentTranslation[1].Names.EN.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.EN);
            order.Dishes[indexOfAddedOrder].Specifications[1].ComboBoxContentTranslation[1].Names.FR.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.FR);
            order.Dishes[indexOfAddedOrder].Specifications[1].ComboBoxContentTranslation[1].Names.TR.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.TR);
            order.Dishes[indexOfAddedOrder].Specifications[1].ComboBoxContentTranslation[1].Names.RU.Should().Be(addSeatOrderCommand.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.RU);

            order.Dishes[indexOfAddedOrder].Ingredients[0].IsPrimary.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].IsPrimary);
            order.Dishes[indexOfAddedOrder].Ingredients[0].Amount.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].Amount);
            order.Dishes[indexOfAddedOrder].Ingredients[0].MinimumAmount.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].MinimumAmount);
            order.Dishes[indexOfAddedOrder].Ingredients[0].MaximumAmount.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].MaximumAmount);
            order.Dishes[indexOfAddedOrder].Ingredients[0].AmountIncreasePerStep.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].AmountIncreasePerStep);
            order.Dishes[indexOfAddedOrder].Ingredients[0].PriceIncreasePerStep.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].PriceIncreasePerStep);
            order.Dishes[indexOfAddedOrder].Ingredients[0].Steps.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].Steps);
            order.Dishes[indexOfAddedOrder].Ingredients[0].MeasurementUnits.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].MeasurementUnits);
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.IngredientId.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.IngredientId);
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.Names.Should().Be(JsonConvert.SerializeObject(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.Names));
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.EnergeticValue.Fat.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat);
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.EnergeticValue.Protein.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein);
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates);
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.EnergeticValue.Energy.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy);
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.EnergeticValue.Amount.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount);
            order.Dishes[indexOfAddedOrder].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit.Should().Be(addSeatOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit);
           
            order.Dishes[indexOfAddedOrder].Supplements[0].SupplementId.Should().Be(addSeatOrderCommand.Dishes[0].Supplements[0].SupplementId);
            order.Dishes[indexOfAddedOrder].Supplements[0].Name.Should().Be(UsedSupplimentInCommand.Name);
            order.Dishes[indexOfAddedOrder].Supplements[0].Names.AR.Should().Be(UsedSupplimentInCommand.Names.AR);
            order.Dishes[indexOfAddedOrder].Supplements[0].Names.EN.Should().Be(UsedSupplimentInCommand.Names.EN);
            order.Dishes[indexOfAddedOrder].Supplements[0].Names.FR.Should().Be(UsedSupplimentInCommand.Names.FR);
            order.Dishes[indexOfAddedOrder].Supplements[0].Names.TR.Should().Be(UsedSupplimentInCommand.Names.TR);
            order.Dishes[indexOfAddedOrder].Supplements[0].Names.RU.Should().Be(UsedSupplimentInCommand.Names.RU);
            order.Dishes[indexOfAddedOrder].Supplements[0].Price.Should().Be(100);
            order.Dishes[indexOfAddedOrder].Supplements[0].EnergeticValue.Should().Be(UsedSupplimentInCommand.EnergeticValue);
            order.Dishes[indexOfAddedOrder].Supplements[0].Description.Should().Be(UsedSupplimentInCommand.Description);
            order.Dishes[indexOfAddedOrder].Supplements[0].IsSelected.Should().Be(addSeatOrderCommand.Dishes[0].Supplements[0].IsSelected);

            order.CommissionConfigs.Value.Should().Be(0);
            order.CommissionConfigs.Type.Should().Be(CommissionType.PerPerson);
            order.CommissionConfigs.WhoPay.Should().Be(WhoPayCommission.FoodBusiness);

        }
        OrderDishSpecificationDto CheckBoxModified = new OrderDishSpecificationDto()
        {
            Title = "Spicy Modified",
            Names = new NamesDto() { AR = "Spicy Modified ar", EN = "Spicy Modified en", FR = "Spicy Modified fr", TR = "Spicy Modified tr", RU = "Spicy Modified ru" },
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
                                Names=new NamesDto() {AR="Bien Cuite Modified ar",EN="Bien Cuite Modified en",FR="Bien Cuite Modified fr",TR="Bien Cuite Modified tr",RU="Bien Cuite Modifiede ru"}
                            },
                            new TranslationItemDto()
                            {
                                    Name="Demi cuisson Modified",
                                Names=new NamesDto() {AR="Demi cuisson Modified ar",EN="Demi cuisson Modified en",FR="Demi cuisson Modified fr",TR="Demi cuisson tr",RU="Demi cuisson Modified ru"}
                            }
                        },
            CheckBoxSelection = false,
            ComboBoxSelection = "Demi cuisson Modified"
        };



        private async Task<AddSeatOrderToTableOrderCommand> AddSeatOrderToTableOrder(string orderId,string tabelId,int chairNumber, CreateDishCommand dish, CreateProductCommand prodact)
        {
            var addSeatOrderCommand = new AddSeatOrderToTableOrderCommand
            {
                Id = orderId,
                TableId = tabelId,
                ChairNumber = chairNumber,

                Dishes = new List<OrderDishCommandDto>() {
                new OrderDishCommandDto {
                    DishId =  dish.Id.ToString(),
                    EnergeticValue =  800,
                    TableNumber =  5,
                    ChairNumber =  2,
                    Quantity =  1,
                    Specifications = new List<OrderDishSpecificationDto>() { CheckBoxModified, ComboBoxModified },
                    Ingredients =  new List<OrderDishIngredientDto>() { new OrderDishIngredientDto()
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
                            IngredientId =dish.Ingredients[0].IngredientId,
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
                    } },
                    Supplements = new List<OrderDishSupplementDto>() { 
                                            new OrderDishSupplementDto()
                                            {
                                                SupplementId =dish.Supplements[0].SupplementId,
                                                IsSelected = true
                                            }
                    },
                    }
                },
                Products = new List<OrderProductDto>() {
                new OrderProductDto {
                    ProductId =prodact.Id.ToString(),
                    TableNumber =  5,
                    ChairNumber =  3,
                    Quantity =  3
                    }
                }
            };
            await SendAsync(addSeatOrderCommand);
            return addSeatOrderCommand;
        }
      


    }
}
