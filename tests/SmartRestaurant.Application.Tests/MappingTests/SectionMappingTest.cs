using System;
using System.Collections.Generic;
using AutoMapper;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using Xunit;

namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class SectionMappingTest : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;
 
        public SectionMappingTest(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        [Fact]
        public void Map_AddProductToSectionCommand_To_SectionProduct_Valide_Test()
        {
            var addProductToSectionCommand = new AddProductToSectionCommand
            {
                SectionId = Guid.NewGuid().ToString(),
                ProductId = Guid.NewGuid().ToString()
            };

            var sectionProduct = _mapper.Map<SectionProduct>(addProductToSectionCommand);
            Assert.Equal(sectionProduct.SectionId, Guid.Parse(addProductToSectionCommand.SectionId));
            Assert.Equal(sectionProduct.ProductId, Guid.Parse(addProductToSectionCommand.ProductId));
        }

        [Fact]
        public void Map_AddDishToSectionCommand_To_SectionDish_Valide_Test()
        {
            var addDishToSectionCommand = new AddDishToSectionCommand
            {
                SectionId = Guid.NewGuid().ToString(),
                DishId = Guid.NewGuid().ToString()
            };

            var sectionDish = _mapper.Map<SectionDish>(addDishToSectionCommand);
            Assert.Equal(sectionDish.SectionId, Guid.Parse(addDishToSectionCommand.SectionId));
            Assert.Equal(sectionDish.DishId, Guid.Parse(addDishToSectionCommand.DishId));
        }

        [Fact]
        public void Map_Product_To_MenuItemDto_Test()
        {
            var product = new Product
            {
                ProductId = Guid.NewGuid(),
                Name = "hamoud 2L",
                Names = new Names()
                {
                    AR = "hamoud 2L AR",
                    EN = "hamoud 2L EN",
                    FR = "hamoud 2L FR",
                    TR = "hamoud 2L TR",
                    RU = "hamoud 2L RU"
                },
                Description = "description test",
                Price = 150,
                EnergeticValue = 200,
                Picture = new byte[3] { 22, 23, 25 }
            };


            var menuItemDto = _mapper.Map<MenuItemDto>(product);
            Assert.Equal(menuItemDto.MenuItemId, product.ProductId);
            Assert.Equal(menuItemDto.Name, product.Name);

            Assert.Equal(product.Names.AR, menuItemDto.Names.AR);
            Assert.Equal(product.Names.EN, menuItemDto.Names.EN);
            Assert.Equal(product.Names.FR, menuItemDto.Names.FR);
            Assert.Equal(product.Names.TR, menuItemDto.Names.TR);
            Assert.Equal(product.Names.RU, menuItemDto.Names.RU);

            Assert.Equal(menuItemDto.Description, product.Description);
            Assert.Equal(menuItemDto.Price, product.Price);
            Assert.Equal(menuItemDto.EnergeticValue, product.EnergeticValue);
            Assert.Equal(menuItemDto.Picture, Convert.ToBase64String(product.Picture));
            Assert.Equal(menuItemDto.Type, MenuItemType.Product);

        }

        [Fact]
        public void Map_Dish_To_MenuItemDto_Test()
        {
            var dish = new Dish
            {
                DishId = Guid.NewGuid(),
                Name = "Fakhitasse",
                Names = new Names()
                {
                    AR = "Fakhitasse AR",
                    EN = "Fakhitasse EN",
                    FR = "Fakhitasse FR",
                    TR = "Fakhitasse TR",
                    RU = "Fakhitasse RU"
                },
                Description = "Fakhitasse description",
                Picture = Convert.FromBase64String(Properties.Resources.picture),
                Price = 280,
                FoodBusinessId = Guid.NewGuid(),
                Specifications = new List<DishSpecification>() {
                    new  DishSpecification()   {ContentType =  ContentType.CheckBox, Title = "Slaty", CheckBoxContent = false},
                    new  DishSpecification()   {ContentType = ContentType.ComboBox,  Title = "Cuission", ComboBoxContent = "Bien Cuite;Demi cuisson" }
                },
                Ingredients = new List<DishIngredient>() {
                    new  DishIngredient()   {
                        InitialAmount = 20,
                        MinimumAmount = 10,
                        MaximumAmount = 50,
                        MeasurementUnits = MeasurementUnits.KiloGramme,
                        AmountIncreasePerStep = 10,
                        PriceIncreasePerStep = 20,
                        IngredientId = Guid.NewGuid()
                    },
                },
                Supplements = new List<DishSupplement>() {
                    new  DishSupplement()   {SupplementId =  Guid.NewGuid()},
                    new  DishSupplement()   {SupplementId =  Guid.NewGuid()},
                },
                IsSupplement = true,
                IsQuantityChecked = true,
                Quantity = 200,
                EstimatedPreparationTime = 1200
            };


            var menuItemDto = _mapper.Map<MenuItemDto>(dish);
            Assert.Equal(menuItemDto.MenuItemId, dish.DishId);
            Assert.Equal(menuItemDto.Name, dish.Name);

            Assert.Equal(dish.Names.AR, menuItemDto.Names.AR);
            Assert.Equal(dish.Names.EN, menuItemDto.Names.EN);
            Assert.Equal(dish.Names.FR, menuItemDto.Names.FR);
            Assert.Equal(dish.Names.TR, menuItemDto.Names.TR);
            Assert.Equal(dish.Names.RU, menuItemDto.Names.RU);

            Assert.Equal(menuItemDto.Description, dish.Description);
            Assert.Equal(menuItemDto.Price, dish.Price);
            Assert.Equal(menuItemDto.EnergeticValue, dish.EnergeticValue);
            Assert.Equal(menuItemDto.Picture, Convert.ToBase64String(dish.Picture));
            Assert.Equal(menuItemDto.Type, MenuItemType.Dish);

        }       
    }
}