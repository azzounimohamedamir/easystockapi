using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Enums;
using FluentAssertions;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Application.Tables.Commands;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Orders.Commands;

namespace SmartRestaurant.Application.IntegrationTests.Orders.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateOrderDeliveryInWorkTimeTest : TestBase
    {
        [Test]
        public async Task CreateOrderDeliveryInWorkTime_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
            var createIngredientCommand = await IngredientTestTools.CreateIngredient();
            var createDishCommand = await DishTestTools.CreateDish(fastFood.FoodBusinessId, createIngredientCommand.Id);
            var createProductCommand = await ProductTestTools.CreateProduct();
            DateTime orderTime = new DateTime(2008, 3, 9, 16, 5, 7, 123);
            ConfigureDateTimeNow(orderTime);
            var OrderCommand = await OrderTestTools.CreateOrderDelivery(fastFood.FoodBusinessId, null, createDishCommand, createProductCommand);

            OrderCommand.ErrorDeliveryTimeAvailabilite.Should().Be(ErrorResult.None);

            var order = await GetOrder(Guid.Parse(OrderCommand.OrderId));

            var UsedSupplimentInCommand = await GetDish(Guid.Parse(createDishCommand.Supplements[0].SupplementId));

            order.Type.Should().Be(OrderTypes.Delivery);
            order.Status.Should().Be(OrderStatuses.InQueue);
            order.FoodBusinessId.Should().Be(Guid.Parse(OrderCommand.FoodBusinessId));
            order.FoodBusinessClientId.Should().BeNull();
            order.TotalToPay.Should().Be(910);
            order.Products[0].Name.Should().Be(createProductCommand.Name);
            order.Products[0].Names.AR.Should().Be(createProductCommand.Names.AR);
            order.Products[0].Names.EN.Should().Be(createProductCommand.Names.EN);
            order.Products[0].Names.FR.Should().Be(createProductCommand.Names.FR);
            order.Products[0].Names.TR.Should().Be(createProductCommand.Names.TR);
            order.Products[0].Names.RU.Should().Be(createProductCommand.Names.RU);

            order.Products[0].UnitPrice.Should().Be(createProductCommand.Price);
            order.Products[0].EnergeticValue.Should().Be(createProductCommand.EnergeticValue);
            order.Products[0].Description.Should().Be(createProductCommand.Description);
            order.Products[0].TableNumber.Should().Be(OrderCommand.Products[0].TableNumber);
            order.Products[0].ChairNumber.Should().Be(OrderCommand.Products[0].ChairNumber);
            order.Products[0].Quantity.Should().Be(OrderCommand.Products[0].Quantity);

            order.Dishes[0].Name.Should().Be(createDishCommand.Name);

            order.Dishes[0].Names.AR.Should().Be(createDishCommand.Names.AR);
            order.Dishes[0].Names.EN.Should().Be(createDishCommand.Names.EN);
            order.Dishes[0].Names.FR.Should().Be(createDishCommand.Names.FR);
            order.Dishes[0].Names.TR.Should().Be(createDishCommand.Names.TR);
            order.Dishes[0].Names.RU.Should().Be(createDishCommand.Names.RU);

            order.Dishes[0].InitialPrice.Should().Be(createDishCommand.Price);
            order.Dishes[0].UnitPrice.Should().Be(380);
            order.Dishes[0].EnergeticValue.Should().Be(OrderCommand.Dishes[0].EnergeticValue);
            order.Dishes[0].Description.Should().Be(createDishCommand.Description);
            order.Dishes[0].EstimatedPreparationTime.Should().Be(createDishCommand.EstimatedPreparationTime);
            order.Dishes[0].TableNumber.Should().Be(OrderCommand.Dishes[0].TableNumber);
            order.Dishes[0].ChairNumber.Should().Be(OrderCommand.Dishes[0].ChairNumber);
            order.Dishes[0].Quantity.Should().Be(OrderCommand.Dishes[0].Quantity);

            order.Dishes[0].Specifications[0].Title.Should().Be(createDishCommand.Specifications[0].Title);
            order.Dishes[0].Specifications[0].Names.AR.Should().Be(createDishCommand.Specifications[0].Names.AR);
            order.Dishes[0].Specifications[0].Names.EN.Should().Be(createDishCommand.Specifications[0].Names.EN);
            order.Dishes[0].Specifications[0].Names.FR.Should().Be(createDishCommand.Specifications[0].Names.FR);
            order.Dishes[0].Specifications[0].Names.TR.Should().Be(createDishCommand.Specifications[0].Names.TR);
            order.Dishes[0].Specifications[0].Names.RU.Should().Be(createDishCommand.Specifications[0].Names.RU);


            order.Dishes[0].Specifications[0].ComboBoxContent.Should().BeNull();
            order.Dishes[0].Specifications[0].ComboBoxSelection.Should().Be(OrderCommand.Dishes[0].Specifications[0].ComboBoxSelection);
            order.Dishes[0].Specifications[0].CheckBoxContent.Should().Be(OrderCommand.Dishes[0].Specifications[0].CheckBoxContent);
            order.Dishes[0].Specifications[0].CheckBoxSelection.Should().Be(OrderCommand.Dishes[0].Specifications[0].CheckBoxSelection);

            order.Dishes[0].Specifications[1].Title.Should().Be(OrderCommand.Dishes[0].Specifications[1].Title);
            order.Dishes[0].Specifications[1].Names.AR.Should().Be(createDishCommand.Specifications[0].Names.AR);
            order.Dishes[0].Specifications[1].Names.EN.Should().Be(createDishCommand.Specifications[0].Names.EN);
            order.Dishes[0].Specifications[1].Names.FR.Should().Be(createDishCommand.Specifications[0].Names.FR);
            order.Dishes[0].Specifications[1].Names.TR.Should().Be(createDishCommand.Specifications[0].Names.TR);
            order.Dishes[0].Specifications[1].Names.RU.Should().Be(createDishCommand.Specifications[0].Names.RU);

            order.Dishes[0].Specifications[1].ContentType.Should().Be(OrderCommand.Dishes[0].Specifications[1].ContentType);
            order.Dishes[0].Specifications[1].ComboBoxSelection.Should().Be(OrderCommand.Dishes[0].Specifications[1].ComboBoxSelection);
            order.Dishes[0].Specifications[1].CheckBoxContent.Should().Be(OrderCommand.Dishes[0].Specifications[1].CheckBoxContent);
            order.Dishes[0].Specifications[1].CheckBoxSelection.Should().Be(OrderCommand.Dishes[0].Specifications[1].CheckBoxSelection);

            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Name.Should().Be(createDishCommand.Specifications[1].ComboBoxContentTranslation[0].Name);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.AR.Should().Be(createDishCommand.Specifications[1].ComboBoxContentTranslation[0].Names.AR);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.EN.Should().Be(createDishCommand.Specifications[1].ComboBoxContentTranslation[0].Names.EN);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.FR.Should().Be(createDishCommand.Specifications[1].ComboBoxContentTranslation[0].Names.FR);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.TR.Should().Be(createDishCommand.Specifications[1].ComboBoxContentTranslation[0].Names.TR);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[0].Names.RU.Should().Be(createDishCommand.Specifications[1].ComboBoxContentTranslation[0].Names.RU);

            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Name.Should().Be(createDishCommand.Specifications[1].ComboBoxContentTranslation[1].Name);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.AR.Should().Be(createDishCommand.Specifications[1].ComboBoxContentTranslation[1].Names.AR);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.EN.Should().Be(createDishCommand.Specifications[1].ComboBoxContentTranslation[1].Names.EN);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.FR.Should().Be(createDishCommand.Specifications[1].ComboBoxContentTranslation[1].Names.FR);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.TR.Should().Be(createDishCommand.Specifications[1].ComboBoxContentTranslation[1].Names.TR);
            order.Dishes[0].Specifications[1].ComboBoxContentTranslation[1].Names.RU.Should().Be(createDishCommand.Specifications[1].ComboBoxContentTranslation[1].Names.RU);

            order.Dishes[0].Ingredients[0].IsPrimary.Should().Be(OrderCommand.Dishes[0].Ingredients[0].IsPrimary);
            order.Dishes[0].Ingredients[0].Amount.Should().Be(OrderCommand.Dishes[0].Ingredients[0].Amount);
            order.Dishes[0].Ingredients[0].MinimumAmount.Should().Be(OrderCommand.Dishes[0].Ingredients[0].MinimumAmount);
            order.Dishes[0].Ingredients[0].MaximumAmount.Should().Be(OrderCommand.Dishes[0].Ingredients[0].MaximumAmount);
            order.Dishes[0].Ingredients[0].AmountIncreasePerStep.Should().Be(OrderCommand.Dishes[0].Ingredients[0].AmountIncreasePerStep);
            order.Dishes[0].Ingredients[0].PriceIncreasePerStep.Should().Be(OrderCommand.Dishes[0].Ingredients[0].PriceIncreasePerStep);
            order.Dishes[0].Ingredients[0].Steps.Should().Be(OrderCommand.Dishes[0].Ingredients[0].Steps);
            order.Dishes[0].Ingredients[0].MeasurementUnits.Should().Be(OrderCommand.Dishes[0].Ingredients[0].MeasurementUnits);
            order.Dishes[0].Ingredients[0].OrderIngredient.IngredientId.Should().Be(OrderCommand.Dishes[0].Ingredients[0].OrderIngredient.IngredientId);
            order.Dishes[0].Ingredients[0].OrderIngredient.Names.Should().Be(JsonConvert.SerializeObject(OrderCommand.Dishes[0].Ingredients[0].OrderIngredient.Names));
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat.Should().Be(OrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein.Should().Be(OrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates.Should().Be(OrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy.Should().Be(OrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount.Should().Be(OrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit.Should().Be(OrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit);

            order.Dishes[0].Supplements[0].SupplementId.Should().Be(OrderCommand.Dishes[0].Supplements[0].SupplementId);
            order.Dishes[0].Supplements[0].Name.Should().Be(UsedSupplimentInCommand.Name);

            order.Dishes[0].Supplements[0].Names.AR.Should().Be(UsedSupplimentInCommand.Names.AR);
            order.Dishes[0].Supplements[0].Names.EN.Should().Be(UsedSupplimentInCommand.Names.EN);
            order.Dishes[0].Supplements[0].Names.FR.Should().Be(UsedSupplimentInCommand.Names.FR);
            order.Dishes[0].Supplements[0].Names.TR.Should().Be(UsedSupplimentInCommand.Names.TR);
            order.Dishes[0].Supplements[0].Names.RU.Should().Be(UsedSupplimentInCommand.Names.RU);

            order.Dishes[0].Supplements[0].Price.Should().Be(UsedSupplimentInCommand.Price);
            order.Dishes[0].Supplements[0].EnergeticValue.Should().Be(UsedSupplimentInCommand.EnergeticValue);
            order.Dishes[0].Supplements[0].Description.Should().Be(UsedSupplimentInCommand.Description);
            order.Dishes[0].Supplements[0].IsSelected.Should().Be(OrderCommand.Dishes[0].Supplements[0].IsSelected);

            order.CommissionConfigs.Value.Should().Be(0);
            order.CommissionConfigs.Type.Should().Be(CommissionType.PerPerson);
            order.CommissionConfigs.WhoPay.Should().Be(WhoPayCommission.FoodBusiness);

            order.GeoPosition.Longitude.Should().Be("0");
            order.GeoPosition.Latitude.Should().Be("0");

        }


    }


}
    