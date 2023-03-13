using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Orders.Queries;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Zones.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Orders.Queries
{
    using static Testing;

    [TestFixture]
    public class GetOrderByIdTest : TestBase
    {   
        [Test]
        public async Task GetOrderById_ShouldReturnSelectedOrder()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createZoneCommand = await ZoneTestTools.CreateZone(fastFood);
            await CreateTable(createZoneCommand);
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createProductCommand = await ProductTestTools.CreateProduct(fastFood.FoodBusinessId);
            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand);
            var order = await GetOrder(createOrderCommand.Id);

            var userDish= await GetDish(createDishCommand.Id);


            var selectedOrder = await SendAsync(new GetOrderByIdQuery { Id = order.OrderId.ToString() });


            selectedOrder.Should().NotBeNull();



            selectedOrder.Type.Should().Be(order.Type);
            selectedOrder.Status.Should().Be(order.Status);
            selectedOrder.FoodBusinessId.Should().Be(order.FoodBusinessId.ToString());
            selectedOrder.CreatedAt.Should().Be(order.CreatedAt);
            selectedOrder.TotalToPay.Should().Be(order.TotalToPay);
            selectedOrder.MoneyReceived.Should().Be(order.MoneyReceived);
            selectedOrder.MoneyReturned.Should().Be(order.MoneyReturned);
            selectedOrder.Number.Should().Be(order.Number);
            selectedOrder.OrderId.Should().Be(order.OrderId.ToString());
            selectedOrder.TakeoutDetails.Type.Should().Be(order.TakeoutDetails.Type);
            selectedOrder.TakeoutDetails.DeliveryTime.Should().Be(order.TakeoutDetails.DeliveryTime);

            selectedOrder.OccupiedTables[0].TableId.Should().Be(order.OccupiedTables[0].TableId);

            selectedOrder.Products[0].Name.Should().Be(order.Products[0].Name);
            selectedOrder.Products[0].UnitPrice.Should().Be(order.Products[0].UnitPrice);
            selectedOrder.Products[0].EnergeticValue.Should().Be(order.Products[0].EnergeticValue);
            selectedOrder.Products[0].Description.Should().Be(order.Products[0].Description);
            selectedOrder.Products[0].TableNumber.Should().Be(order.Products[0].TableNumber);
            selectedOrder.Products[0].ChairNumber.Should().Be(order.Products[0].ChairNumber);
            selectedOrder.Products[0].Quantity.Should().Be(order.Products[0].Quantity);

            selectedOrder.Dishes[0].Name.Should().Be(order.Dishes[0].Name);
            selectedOrder.Dishes[0].Names.AR.Should().Be(userDish.Names.AR);
            selectedOrder.Dishes[0].Names.EN.Should().Be(userDish.Names.EN);
            selectedOrder.Dishes[0].Names.FR.Should().Be(userDish.Names.FR);
            selectedOrder.Dishes[0].Names.TR.Should().Be(userDish.Names.TR);
            selectedOrder.Dishes[0].Names.RU.Should().Be(userDish.Names.RU);

            selectedOrder.Dishes[0].UnitPrice.Should().Be(order.Dishes[0].UnitPrice);
            selectedOrder.Dishes[0].InitialPrice.Should().Be(order.Dishes[0].InitialPrice);
            selectedOrder.Dishes[0].EnergeticValue.Should().Be(order.Dishes[0].EnergeticValue);
            selectedOrder.Dishes[0].Description.Should().Be(userDish.Description);
            selectedOrder.Dishes[0].EstimatedPreparationTime.Should().Be(userDish.EstimatedPreparationTime);
            selectedOrder.Dishes[0].TableNumber.Should().Be(order.Dishes[0].TableNumber);
            selectedOrder.Dishes[0].ChairNumber.Should().Be(order.Dishes[0].ChairNumber);
            selectedOrder.Dishes[0].Quantity.Should().Be(order.Dishes[0].Quantity);

            selectedOrder.Dishes[0].Specifications[0].Title.Should().Be(order.Dishes[0].Specifications[0].Title);
            selectedOrder.Dishes[0].Specifications[0].Names.AR.Should().Be(order.Dishes[0].Specifications[0].Names.AR);
            selectedOrder.Dishes[0].Specifications[0].Names.EN.Should().Be(order.Dishes[0].Specifications[0].Names.EN);
            selectedOrder.Dishes[0].Specifications[0].Names.FR.Should().Be(order.Dishes[0].Specifications[0].Names.FR);
            selectedOrder.Dishes[0].Specifications[0].Names.TR.Should().Be(order.Dishes[0].Specifications[0].Names.TR);
            selectedOrder.Dishes[0].Specifications[0].Names.RU.Should().Be(order.Dishes[0].Specifications[0].Names.RU);

            selectedOrder.Dishes[0].Specifications[0].ContentType.Should().Be(order.Dishes[0].Specifications[0].ContentType);
            selectedOrder.Dishes[0].Specifications[0].ComboBoxContent.Should().BeEquivalentTo(new string[0]);
            selectedOrder.Dishes[0].Specifications[0].ComboBoxSelection.Should().Be(order.Dishes[0].Specifications[0].ComboBoxSelection);
            selectedOrder.Dishes[0].Specifications[0].CheckBoxContent.Should().Be(order.Dishes[0].Specifications[0].CheckBoxContent);
            selectedOrder.Dishes[0].Specifications[0].CheckBoxSelection.Should().Be(order.Dishes[0].Specifications[0].CheckBoxSelection);
            selectedOrder.Dishes[0].Specifications[1].Title.Should().Be(order.Dishes[0].Specifications[1].Title);

            selectedOrder.Dishes[0].Specifications[1].Names.AR.Should().Be(order.Dishes[0].Specifications[1].Names.AR);
            selectedOrder.Dishes[0].Specifications[1].Names.EN.Should().Be(order.Dishes[0].Specifications[1].Names.EN);
            selectedOrder.Dishes[0].Specifications[1].Names.FR.Should().Be(order.Dishes[0].Specifications[1].Names.FR);
            selectedOrder.Dishes[0].Specifications[1].Names.TR.Should().Be(order.Dishes[0].Specifications[1].Names.TR);
            selectedOrder.Dishes[0].Specifications[1].Names.RU.Should().Be(order.Dishes[0].Specifications[1].Names.RU);

            selectedOrder.Dishes[0].Specifications[1].ContentType.Should().Be(order.Dishes[0].Specifications[1].ContentType);

            selectedOrder.Dishes[0].Specifications[1].ComboBoxSelection.Should().Be(order.Dishes[0].Specifications[1].ComboBoxSelection);
            selectedOrder.Dishes[0].Specifications[1].CheckBoxContent.Should().Be(order.Dishes[0].Specifications[1].CheckBoxContent);
            selectedOrder.Dishes[0].Specifications[1].CheckBoxSelection.Should().Be(order.Dishes[0].Specifications[1].CheckBoxSelection);

            selectedOrder.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Name.Should().Be(order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Name);
            selectedOrder.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.AR.Should().Be(order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.AR);
            selectedOrder.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.EN.Should().Be(order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.EN);
            selectedOrder.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.FR.Should().Be(order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.FR);
            selectedOrder.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.TR.Should().Be(order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.TR);
            selectedOrder.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.RU.Should().Be(order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.RU);
            
            selectedOrder.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Name.Should().Be(order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Name);
            selectedOrder.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.AR.Should().Be(order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.AR);
            selectedOrder.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.EN.Should().Be(order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.EN);
            selectedOrder.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.FR.Should().Be(order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.FR);
            selectedOrder.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.TR.Should().Be(order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.TR);
            selectedOrder.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.RU.Should().Be(order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.RU);

            selectedOrder.Dishes[0].Ingredients[0].IsPrimary.Should().Be(order.Dishes[0].Ingredients[0].IsPrimary);
            selectedOrder.Dishes[0].Ingredients[0].Amount.Should().Be(order.Dishes[0].Ingredients[0].Amount);
            selectedOrder.Dishes[0].Ingredients[0].MinimumAmount.Should().Be(order.Dishes[0].Ingredients[0].MinimumAmount);
            selectedOrder.Dishes[0].Ingredients[0].MaximumAmount.Should().Be(order.Dishes[0].Ingredients[0].MaximumAmount);
            selectedOrder.Dishes[0].Ingredients[0].AmountIncreasePerStep.Should().Be(order.Dishes[0].Ingredients[0].AmountIncreasePerStep);
            selectedOrder.Dishes[0].Ingredients[0].PriceIncreasePerStep.Should().Be(order.Dishes[0].Ingredients[0].PriceIncreasePerStep);
            selectedOrder.Dishes[0].Ingredients[0].Steps.Should().Be(order.Dishes[0].Ingredients[0].Steps);
            selectedOrder.Dishes[0].Ingredients[0].MeasurementUnits.Should().Be(order.Dishes[0].Ingredients[0].MeasurementUnits);
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.IngredientId.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.IngredientId);
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.Names.Should().BeEquivalentTo(JsonConvert.DeserializeObject<List<IngredientNameDto>>(order.Dishes[0].Ingredients[0].OrderIngredient.Names));
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat);
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein);
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates);
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy);
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount);
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit);

            selectedOrder.Dishes[0].Supplements[0].SupplementId.Should().Be(order.Dishes[0].Supplements[0].SupplementId);
            selectedOrder.Dishes[0].Supplements[0].Name.Should().Be(userDish.Supplements[0].Supplement.Name);
            selectedOrder.Dishes[0].Supplements[0].Names.AR.Should().Be(userDish.Supplements[0].Supplement.Names.AR);
            selectedOrder.Dishes[0].Supplements[0].Names.EN.Should().Be(userDish.Supplements[0].Supplement.Names.EN);
            selectedOrder.Dishes[0].Supplements[0].Names.FR.Should().Be(userDish.Supplements[0].Supplement.Names.FR);
            selectedOrder.Dishes[0].Supplements[0].Names.TR.Should().Be(userDish.Supplements[0].Supplement.Names.TR);
            selectedOrder.Dishes[0].Supplements[0].Names.RU.Should().Be(userDish.Supplements[0].Supplement.Names.RU);
            selectedOrder.Dishes[0].Supplements[0].Price.Should().Be(100);
            selectedOrder.Dishes[0].Supplements[0].EnergeticValue.Should().Be(userDish.Supplements[0].Supplement.EnergeticValue);
            selectedOrder.Dishes[0].Supplements[0].Description.Should().Be(userDish.Supplements[0].Supplement.Description);

            selectedOrder.Dishes[0].Supplements[0].IsSelected.Should().Be(order.Dishes[0].Supplements[0].IsSelected);
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
        }

    }
}
