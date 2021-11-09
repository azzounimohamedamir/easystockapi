using System;
using System.Threading.Tasks;
using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using AutoMapper;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using Xunit;
using FluentAssertions;

namespace SmartRestaurant.Application.IntegrationTests.Orders.Commands
{
    using static Testing;

    [TestFixture]
    public class CreateOrderTest : TestBase
    {
        [Test]
        public async Task CreateOrder_ShouldSaveToDB()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);

            var createOrderCommand = await OrderTestTools.CreateOrder(fastFood.FoodBusinessId);
            var order = await GetOrder(createOrderCommand.Id);


            order.Type.Should().Be(OrderTypes.DineIn);
            order.FoodBusinessId.Should().Be( Guid.Parse(createOrderCommand.FoodBusinessId));

            order.OccupiedTables[0].TableId.Should().Be(createOrderCommand.OccupiedTables[0].TableId);

            order.Products[0].Name.Should().Be( createOrderCommand.Products[0].Name);
            order.Products[0].UnitPrice.Should().Be( createOrderCommand.Products[0].UnitPrice);
            order.Products[0].EnergeticValue.Should().Be( createOrderCommand.Products[0].EnergeticValue);
            order.Products[0].Description.Should().Be( createOrderCommand.Products[0].Description);
            order.Products[0].TableNumber.Should().Be( createOrderCommand.Products[0].TableNumber);
            order.Products[0].ChairNumber.Should().Be( createOrderCommand.Products[0].ChairNumber);
            order.Products[0].Quantity.Should().Be( createOrderCommand.Products[0].Quantity);

            order.Dishes[0].Name.Should().Be( createOrderCommand.Dishes[0].Name);
            order.Dishes[0].UnitPrice.Should().Be( createOrderCommand.Dishes[0].UnitPrice);
            order.Dishes[0].EnergeticValue.Should().Be( createOrderCommand.Dishes[0].EnergeticValue);
            order.Dishes[0].Description.Should().Be( createOrderCommand.Dishes[0].Description);
            order.Dishes[0].EstimatedPreparationTime.Should().Be( createOrderCommand.Dishes[0].EstimatedPreparationTime);
            order.Dishes[0].TableNumber.Should().Be( createOrderCommand.Dishes[0].TableNumber);
            order.Dishes[0].ChairNumber.Should().Be( createOrderCommand.Dishes[0].ChairNumber);
            order.Dishes[0].Quantity.Should().Be( createOrderCommand.Dishes[0].Quantity);

            order.Dishes[0].Specifications[0].Title.Should().Be( createOrderCommand.Dishes[0].Specifications[0].Title);
            order.Dishes[0].Specifications[0].ContentType.Should().Be( createOrderCommand.Dishes[0].Specifications[0].ContentType);
            order.Dishes[0].Specifications[0].ComboBoxContent.Should().BeNull();
            order.Dishes[0].Specifications[0].ComboBoxSelection.Should().Be( createOrderCommand.Dishes[0].Specifications[0].ComboBoxSelection); ; ; ; ; ; ; ;
            order.Dishes[0].Specifications[0].CheckBoxContent.Should().Be( createOrderCommand.Dishes[0].Specifications[0].CheckBoxContent);
            order.Dishes[0].Specifications[0].CheckBoxSelection.Should().Be( createOrderCommand.Dishes[0].Specifications[0].CheckBoxSelection);
            order.Dishes[0].Specifications[1].Title.Should().Be( createOrderCommand.Dishes[0].Specifications[1].Title);
            order.Dishes[0].Specifications[1].ContentType.Should().Be( createOrderCommand.Dishes[0].Specifications[1].ContentType);
            order.Dishes[0].Specifications[1].ComboBoxContent.Should().Be( string.Join(";", createOrderCommand.Dishes[0].Specifications[1].ComboBoxContent));
            order.Dishes[0].Specifications[1].ComboBoxSelection.Should().Be( createOrderCommand.Dishes[0].Specifications[1].ComboBoxSelection);
            order.Dishes[0].Specifications[1].CheckBoxContent.Should().Be( createOrderCommand.Dishes[0].Specifications[1].CheckBoxContent);
            order.Dishes[0].Specifications[1].CheckBoxSelection.Should().Be( createOrderCommand.Dishes[0].Specifications[1].CheckBoxSelection);

            order.Dishes[0].Ingredients[0].IsPrimary.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].IsPrimary);
            order.Dishes[0].Ingredients[0].Amount.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].Amount);
            order.Dishes[0].Ingredients[0].MinimumAmount.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].MinimumAmount);
            order.Dishes[0].Ingredients[0].MaximumAmount.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].MaximumAmount);
            order.Dishes[0].Ingredients[0].AmountIncreasePerStep.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].AmountIncreasePerStep);
            order.Dishes[0].Ingredients[0].PriceIncreasePerStep.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].PriceIncreasePerStep);
            order.Dishes[0].Ingredients[0].Steps.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].Steps);
            order.Dishes[0].Ingredients[0].MeasurementUnits.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].MeasurementUnits);
            order.Dishes[0].Ingredients[0].OrderIngredient.IngredientId.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.IngredientId);
            order.Dishes[0].Ingredients[0].OrderIngredient.Names.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.Names);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Fat);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Protein);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Carbohydrates);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Energy);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.Amount);
            order.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit.Should().Be( createOrderCommand.Dishes[0].Ingredients[0].OrderIngredient.EnergeticValue.MeasurementUnit);

            order.Dishes[0].Supplements[0].SupplementId.Should().Be( createOrderCommand.Dishes[0].Supplements[0].SupplementId);
            order.Dishes[0].Supplements[0].Name.Should().Be( createOrderCommand.Dishes[0].Supplements[0].Name);
            order.Dishes[0].Supplements[0].Price.Should().Be( createOrderCommand.Dishes[0].Supplements[0].Price);
            order.Dishes[0].Supplements[0].EnergeticValue.Should().Be( createOrderCommand.Dishes[0].Supplements[0].EnergeticValue);
            order.Dishes[0].Supplements[0].Description.Should().Be( createOrderCommand.Dishes[0].Supplements[0].Description);
            order.Dishes[0].Supplements[0].IsSelected.Should().Be( createOrderCommand.Dishes[0].Supplements[0].IsSelected);
        }     
    }
}