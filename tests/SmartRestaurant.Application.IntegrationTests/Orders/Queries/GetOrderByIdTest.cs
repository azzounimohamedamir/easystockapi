using FluentAssertions;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Application.Orders.Queries;
using SmartRestaurant.Application.Tables.Commands;
using SmartRestaurant.Application.Zones.Commands;
using System;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Orders.Commands
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
            var createZoneCommand = await CreateZone(fastFood);
            await CreateTable(createZoneCommand);
            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId);
            var order = await GetOrder(createOrderCommand.Id);





            var selectedOrder = await SendAsync(new GetOrderByIdQuery { Id = order.OrderId.ToString() });


            selectedOrder.Should().NotBeNull();



            selectedOrder.Type.Should().Be(order.Type);
            selectedOrder.Status.Should().Be(order.Status);
            selectedOrder.FoodBusinessId.Should().Be(order.FoodBusinessId);
            selectedOrder.CreatedAt.Should().Be(order.CreatedAt);
            selectedOrder.TotalToPay.Should().Be(order.TotalToPay);
            selectedOrder.MoneyReceived.Should().Be(order.MoneyReceived);
            selectedOrder.MoneyReturned.Should().Be(order.MoneyReturned);
            selectedOrder.Number.Should().Be(order.Number);
            selectedOrder.OrderId.Should().Be(order.OrderId);
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
            selectedOrder.Dishes[0].UnitPrice.Should().Be(order.Dishes[0].UnitPrice);
            selectedOrder.Dishes[0].EnergeticValue.Should().Be(order.Dishes[0].EnergeticValue);
            selectedOrder.Dishes[0].Description.Should().Be(order.Dishes[0].Description);
            selectedOrder.Dishes[0].EstimatedPreparationTime.Should().Be(order.Dishes[0].EstimatedPreparationTime);
            selectedOrder.Dishes[0].TableNumber.Should().Be(order.Dishes[0].TableNumber);
            selectedOrder.Dishes[0].ChairNumber.Should().Be(order.Dishes[0].ChairNumber);
            selectedOrder.Dishes[0].Quantity.Should().Be(order.Dishes[0].Quantity);

            selectedOrder.Dishes[0].Specifications[0].Title.Should().Be(order.Dishes[0].Specifications[0].Title);
            selectedOrder.Dishes[0].Specifications[0].ContentType.Should().Be(order.Dishes[0].Specifications[0].ContentType);
            selectedOrder.Dishes[0].Specifications[0].ComboBoxContent.Should().BeEquivalentTo(new string[0]);
            selectedOrder.Dishes[0].Specifications[0].ComboBoxSelection.Should().Be(order.Dishes[0].Specifications[0].ComboBoxSelection); ; ; ; ; ; ; ;
            selectedOrder.Dishes[0].Specifications[0].CheckBoxContent.Should().Be(order.Dishes[0].Specifications[0].CheckBoxContent);
            selectedOrder.Dishes[0].Specifications[0].CheckBoxSelection.Should().Be(order.Dishes[0].Specifications[0].CheckBoxSelection);
            selectedOrder.Dishes[0].Specifications[1].Title.Should().Be(order.Dishes[0].Specifications[1].Title);
            selectedOrder.Dishes[0].Specifications[1].ContentType.Should().Be(order.Dishes[0].Specifications[1].ContentType);
            selectedOrder.Dishes[0].Specifications[1].ComboBoxContent.Should().BeEquivalentTo(order.Dishes[0].Specifications[1].ComboBoxContent.Split(';'));
            selectedOrder.Dishes[0].Specifications[1].ComboBoxSelection.Should().Be(order.Dishes[0].Specifications[1].ComboBoxSelection);
            selectedOrder.Dishes[0].Specifications[1].CheckBoxContent.Should().Be(order.Dishes[0].Specifications[1].CheckBoxContent);
            selectedOrder.Dishes[0].Specifications[1].CheckBoxSelection.Should().Be(order.Dishes[0].Specifications[1].CheckBoxSelection);

            selectedOrder.Dishes[0].Ingredients[0].IsPrimary.Should().Be(order.Dishes[0].Ingredients[0].IsPrimary);
            selectedOrder.Dishes[0].Ingredients[0].Amount.Should().Be(order.Dishes[0].Ingredients[0].Amount);
            selectedOrder.Dishes[0].Ingredients[0].MinimumAmount.Should().Be(order.Dishes[0].Ingredients[0].MinimumAmount);
            selectedOrder.Dishes[0].Ingredients[0].MaximumAmount.Should().Be(order.Dishes[0].Ingredients[0].MaximumAmount);
            selectedOrder.Dishes[0].Ingredients[0].AmountIncreasePerStep.Should().Be(order.Dishes[0].Ingredients[0].AmountIncreasePerStep);
            selectedOrder.Dishes[0].Ingredients[0].PriceIncreasePerStep.Should().Be(order.Dishes[0].Ingredients[0].PriceIncreasePerStep);
            selectedOrder.Dishes[0].Ingredients[0].Steps.Should().Be(order.Dishes[0].Ingredients[0].Steps);
            selectedOrder.Dishes[0].Ingredients[0].MeasurementUnits.Should().Be(order.Dishes[0].Ingredients[0].MeasurementUnits);
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.IngredientId.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.IngredientId);
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.Names.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.Names);
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat);
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein);
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates);
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy);
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount);
            selectedOrder.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit.Should().Be(order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit);

            selectedOrder.Dishes[0].Supplements[0].SupplementId.Should().Be(order.Dishes[0].Supplements[0].SupplementId);
            selectedOrder.Dishes[0].Supplements[0].Name.Should().Be(order.Dishes[0].Supplements[0].Name);
            selectedOrder.Dishes[0].Supplements[0].Price.Should().Be(order.Dishes[0].Supplements[0].Price);
            selectedOrder.Dishes[0].Supplements[0].EnergeticValue.Should().Be(order.Dishes[0].Supplements[0].EnergeticValue);
            selectedOrder.Dishes[0].Supplements[0].Description.Should().Be(order.Dishes[0].Supplements[0].Description);
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

        private static async Task<CreateZoneCommand> CreateZone(Domain.Entities.FoodBusiness fastFood)
        {
            var createZoneCommand = new CreateZoneCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                ZoneTitle = "zone 45"
            };
            await SendAsync(createZoneCommand);
            return createZoneCommand;
        }
    }
}
