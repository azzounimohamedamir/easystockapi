using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Ingredients.Commands;
using SmartRestaurant.Application.Products.Commands;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using Xunit;

namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class IngredientMappingTest : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;

        public IngredientMappingTest(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }


        [Fact]
        public void Map_CreateIngredientCommand_To_Ingredient_Valide_Test()
        {
            var createIngredientCommand = new CreateIngredientCommand
            {
                Names = @"[{'name':'Black pepper','language':'en'},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]",
                EnergeticValue = new EnergeticValue {
                    Amount = 10,
                    MeasurementUnit = MeasurementUnits.Gramme,
                    Fat = 2,
                    Protein = 1,
                    Carbohydrates = 3,
                    Energy = 10
                }
            };

            byte[] imageBytes = Properties.Resources.ingredients_1;
            using (var castStream = new MemoryStream(imageBytes))
            {
                createIngredientCommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "ingredient", "ingredient.png");
            };

            var ingredient = _mapper.Map<Ingredient>(createIngredientCommand);
            Assert.Equal(ingredient.IngredientId, createIngredientCommand.Id);
            Assert.Equal(ingredient.Names, createIngredientCommand.Names);
            Assert.Equal(ingredient.EnergeticValue.Amount, createIngredientCommand.EnergeticValue.Amount);
            Assert.Equal(ingredient.EnergeticValue.MeasurementUnit, createIngredientCommand.EnergeticValue.MeasurementUnit);
            Assert.Equal(ingredient.EnergeticValue.Fat, createIngredientCommand.EnergeticValue.Fat);
            Assert.Equal(ingredient.EnergeticValue.Protein, createIngredientCommand.EnergeticValue.Protein);
            Assert.Equal(ingredient.EnergeticValue.Carbohydrates, createIngredientCommand.EnergeticValue.Carbohydrates);
            Assert.Equal(ingredient.EnergeticValue.Energy, createIngredientCommand.EnergeticValue.Energy);
            Assert.NotNull(createIngredientCommand.Picture);
            Assert.Null(ingredient.Picture);



        }

        [Fact]
        public void Map_UpdateIngredientCommand_To_Ingredient_Valide_Test()
        {
            var ingredient = new Ingredient
            {
                IngredientId = Guid.NewGuid(),
                Names = @"[{'name':'Black pepper','language':'en'},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]",
                EnergeticValue = new EnergeticValue
                {
                    Amount = 10,
                    MeasurementUnit = MeasurementUnits.Gramme,
                    Fat = 2,
                    Protein = 1,
                    Carbohydrates = 3,
                    Energy = 10
                },
                Picture = new byte[3] { 22, 23, 25 }
            };
          
            var updateIngredientCommand = new UpdateIngredientCommand
            {
                Id = ingredient.IngredientId.ToString(),
                Names = @"[{'name':'Red pepper','language':'en'},{'name':'الفلفل الاحمر','language':'ar'},{'name':'Poivron rouge','language':'fr'}]",
                EnergeticValue = new EnergeticValue
                {
                    Amount = 2,
                    MeasurementUnit = MeasurementUnits.Gramme,
                    Fat = 1,
                    Protein = 0.5f,
                    Carbohydrates = 2,
                    Energy = 1
                }
            };

            var updatedIngredient = _mapper.Map(updateIngredientCommand, ingredient);
            Assert.Equal(updatedIngredient.IngredientId, Guid.Parse(updateIngredientCommand.Id));
            Assert.Equal(updatedIngredient.Names, updateIngredientCommand.Names);
            Assert.Equal(updatedIngredient.EnergeticValue.Amount, updateIngredientCommand.EnergeticValue.Amount);
            Assert.Equal(updatedIngredient.EnergeticValue.MeasurementUnit, updateIngredientCommand.EnergeticValue.MeasurementUnit);
            Assert.Equal(updatedIngredient.EnergeticValue.Fat, updateIngredientCommand.EnergeticValue.Fat);
            Assert.Equal(updatedIngredient.EnergeticValue.Protein, updateIngredientCommand.EnergeticValue.Protein);
            Assert.Equal(updatedIngredient.EnergeticValue.Carbohydrates, updateIngredientCommand.EnergeticValue.Carbohydrates);
            Assert.Equal(updatedIngredient.EnergeticValue.Energy, updateIngredientCommand.EnergeticValue.Energy);
            Assert.Equal(updatedIngredient.Picture, ingredient.Picture);

        }

        [Fact]
        public void Map_Ingredient_To_IngredientDto_Valide_Test()
        {
            var ingredient = new Ingredient
            {
                IngredientId = Guid.NewGuid(),
                Names = @"[{'name':'Black pepper','language':'en'},{'name':'الفلفل الاسود','language':'ar'},{'name':'Le poivre noir','language':'fr'}]",
                EnergeticValue = new EnergeticValue
                {
                    Amount = 10,
                    MeasurementUnit = MeasurementUnits.Gramme,
                    Fat = 2,
                    Protein = 1,
                    Carbohydrates = 3,
                    Energy = 10
                },
                Picture = new byte[3] { 22, 23, 25 }
            };

            var ingredientDto = _mapper.Map<IngredientDto>(ingredient);
            Assert.Equal(ingredientDto.IngredientId, ingredient.IngredientId);

            var IngredientNames = JsonConvert.DeserializeObject<List<IngredientNameDto>>(ingredient.Names);
            Assert.Contains(ingredientDto.Names, x => x.Name == IngredientNames[0].Name);
            Assert.Contains(ingredientDto.Names, x => x.Language == IngredientNames[0].Language);
            Assert.Contains(ingredientDto.Names, x => x.Name == IngredientNames[1].Name);
            Assert.Contains(ingredientDto.Names, x => x.Language == IngredientNames[1].Language); 
            Assert.Contains(ingredientDto.Names, x => x.Name == IngredientNames[2].Name);
            Assert.Contains(ingredientDto.Names, x => x.Language == IngredientNames[2].Language);


            Assert.Equal(ingredientDto.EnergeticValue.Amount, ingredient.EnergeticValue.Amount);
            Assert.Equal(ingredientDto.EnergeticValue.MeasurementUnit, ingredient.EnergeticValue.MeasurementUnit);
            Assert.Equal(ingredientDto.EnergeticValue.Fat, ingredient.EnergeticValue.Fat);
            Assert.Equal(ingredientDto.EnergeticValue.Protein, ingredient.EnergeticValue.Protein);
            Assert.Equal(ingredientDto.EnergeticValue.Carbohydrates, ingredient.EnergeticValue.Carbohydrates);
            Assert.Equal(ingredientDto.EnergeticValue.Energy, ingredient.EnergeticValue.Energy);
            Assert.Equal(ingredientDto.Picture, Convert.ToBase64String(ingredient.Picture));
        }
    }
}