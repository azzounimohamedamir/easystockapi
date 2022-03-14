using System;
using System.Collections.Generic;
using AutoMapper;
using SmartRestaurant.Application.Common.Dtos.BillDtos;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Orders.Commands;
using SmartRestaurant.Application.Tests.Configuration;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using Xunit;

namespace SmartRestaurant.Application.Tests.MappingTests
{
    public class BillMappingTest : IClassFixture<MappingTestsFixture>
    {
        private readonly IMapper _mapper;

        public BillMappingTest(MappingTestsFixture fixture)
        {
            _mapper = fixture.Mapper;
        }

        private Domain.Entities.FoodBusiness CreateFoodBusiness()
        {
          return new Domain.Entities.FoodBusiness () {
                FoodBusinessId= Guid.NewGuid(),
                AcceptsCreditCards = true,
                AcceptTakeout = true,
                Address = new Address
                {
                    City = "Algiers",
                    Country = "Algeria",
                    GeoPosition = new GeoPosition
                    {
                        Latitude = "0",
                        Longitude = "0"
                    },
                    StreetAddress = "Didouche Mourad"
                },
                Description = "",
                HasCarParking = true,
                IsHandicapFriendly = true,
                Name = "Taj mahal",
                OffersTakeout = true,
                PhoneNumber = new PhoneNumber { CountryCode = 213, Number = 670217536 },
                Tags = "",
                Email = "test@g22.com",
                Website = "",
                FoodBusinessAdministratorId = Guid.NewGuid().ToString(),
                FoodBusinessCategory = FoodBusinessCategory.Restaurant,
                DefaultCurrency = Currencies.USD
            };
        }

        private Domain.Entities.FoodBusinessClient CreateFoodBusinessClient()
        {
            return new Domain.Entities.FoodBusinessClient()
            {
                FoodBusinessId = Guid.NewGuid(),
                Address = new Address
                {
                    City = "Algiers",
                    Country = "Algeria",
                    GeoPosition = new GeoPosition
                    {
                        Latitude = "0",
                        Longitude = "0"
                    },
                    StreetAddress = "Didouche Mourad"
                },
                Description = "",
                Name = "G22",
                PhoneNumber = new PhoneNumber { CountryCode = 213, Number = 670217536 },
                Email = "test@g22.com",
                Website = "",
            };
        }


        private Order CreateOrder()
        {
            var order = _mapper.Map<Order>(new CreateOrderCommand
            {
                Type = OrderTypes.DineIn,
                FoodBusinessId = "3cbf3570-4444-4673-8746-29b7cf568093",
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
                    DishId =  "0e0b853c-9518-499f-b5ca-07afdd5f1e6f",
                    Name =  "Rice",
                    InitialPrice = 200,
                    EnergeticValue =  0,
                    Description =  "",
                    EstimatedPreparationTime =  15,
                    TableNumber =  4,
                    ChairNumber =  1,
                    Quantity =  2,
                    Specifications = new List<OrderDishSpecificationDto>() { },
                    Ingredients =  new List<OrderDishIngredientDto>() {  },
                    Supplements = new List<OrderDishSupplementDto>() {  },
                }
            },
                Products = new List<OrderProductDto>() {
                new OrderProductDto {
                    ProductId =  "7d0bf292-b9bf-404c-a50f-99c9631b3e18",
                    Name =  "Hamooud 1L",
                    UnitPrice =  120,
                    EnergeticValue =  200,
                    Description =  null,
                    TableNumber =  4,
                    ChairNumber =  1,
                    Quantity =  1
                }
            },            
            });
            order.CreatedAt = DateTime.Now;
            order.FoodBusiness = CreateFoodBusiness();
            order.FoodBusinessClient = CreateFoodBusinessClient();
            order.CommissionConfigs = new CommissionConfigs
            {
                Value = 20,
                Type = CommissionType.PerPerson,
                WhoPay = WhoPayCommission.FoodBusiness
            };
            return order;
        }


        [Fact]
         public void Map_Order_To_BillDto_Valide_Test()
        {
            var order = CreateOrder();
            var billDto = _mapper.Map<BillDto>(order);

            Assert.Equal(billDto.Type, order.Type);
            Assert.Equal(billDto.Status, order.Status);
            Assert.Equal(billDto.CreatedAt, order.CreatedAt);
            Assert.Equal(billDto.TotalToPay, order.TotalToPay);
            Assert.Equal(billDto.Discount, order.Discount);
            Assert.Equal(billDto.Number, order.Number);
            Assert.Equal(billDto.OrderId, order.OrderId);

            Assert.Equal(billDto.FoodBusiness.FoodBusinessId, order.FoodBusiness.FoodBusinessId);
            Assert.Equal(billDto.FoodBusiness.Name, order.FoodBusiness.Name);
            Assert.Equal(billDto.FoodBusiness.Email, order.FoodBusiness.Email);
            Assert.Equal(billDto.FoodBusiness.Address.StreetAddress, order.FoodBusiness.Address.StreetAddress); 
            Assert.Equal(billDto.FoodBusiness.Address.City, order.FoodBusiness.Address.City);
            Assert.Equal(billDto.FoodBusiness.Address.Country, order.FoodBusiness.Address.Country);
            Assert.Equal(billDto.FoodBusiness.PhoneNumber.CountryCode, order.FoodBusiness.PhoneNumber.CountryCode);
            Assert.Equal(billDto.FoodBusiness.PhoneNumber.Number, order.FoodBusiness.PhoneNumber.Number);
            Assert.Equal(billDto.FoodBusiness.Website, order.FoodBusiness.Website);
            Assert.Equal(billDto.FoodBusiness.DefaultCurrency, order.FoodBusiness.DefaultCurrency);

            Assert.Equal(billDto.FoodBusinessClient.FoodBusinessClientId, order.FoodBusinessClient.FoodBusinessClientId);
            Assert.Equal(billDto.FoodBusinessClient.Name, order.FoodBusinessClient.Name);
            Assert.Equal(billDto.FoodBusinessClient.Email, order.FoodBusinessClient.Email);
            Assert.Equal(billDto.FoodBusinessClient.Address.StreetAddress, order.FoodBusinessClient.Address.StreetAddress);
            Assert.Equal(billDto.FoodBusinessClient.Address.City, order.FoodBusinessClient.Address.City);
            Assert.Equal(billDto.FoodBusinessClient.Address.Country, order.FoodBusinessClient.Address.Country);
            Assert.Equal(billDto.FoodBusinessClient.PhoneNumber.CountryCode, order.FoodBusinessClient.PhoneNumber.CountryCode);
            Assert.Equal(billDto.FoodBusinessClient.PhoneNumber.Number, order.FoodBusinessClient.PhoneNumber.Number);
            Assert.Equal(billDto.FoodBusinessClient.Website, order.FoodBusinessClient.Website);

            Assert.Equal(billDto.Tables[0].TableId, order.Products[0].TableId);
            Assert.Equal(billDto.Tables[0].TableNumber, order.Products[0].TableNumber);
            Assert.Equal(billDto.Tables[0].Chairs[0].Products[0].Name, order.Products[0].Name);
            Assert.Equal(billDto.Tables[0].Chairs[0].Products[0].InitialPrice, order.Products[0].InitialPrice);
            Assert.Equal(billDto.Tables[0].Chairs[0].Products[0].UnitPrice, order.Products[0].UnitPrice);
            Assert.Equal(billDto.Tables[0].Chairs[0].Products[0].Discount, order.Products[0].Discount);
            Assert.Equal(billDto.Tables[0].Chairs[0].Products[0].Quantity, order.Products[0].Quantity);

            Assert.Equal(billDto.Tables[0].TableId, order.Dishes[0].TableId);
            Assert.Equal(billDto.Tables[0].TableNumber, order.Dishes[0].TableNumber);
            Assert.Equal(billDto.Tables[0].Chairs[0].Dishes[0].Name, order.Dishes[0].Name);
            Assert.Equal(billDto.Tables[0].Chairs[0].Dishes[0].InitialPrice, order.Dishes[0].InitialPrice);
            Assert.Equal(billDto.Tables[0].Chairs[0].Dishes[0].UnitPrice, order.Dishes[0].UnitPrice);
            Assert.Equal(billDto.Tables[0].Chairs[0].Dishes[0].Discount, order.Dishes[0].Discount);
            Assert.Equal(billDto.Tables[0].Chairs[0].Dishes[0].Quantity, order.Dishes[0].Quantity);

            Assert.Equal(20, order.CommissionConfigs.Value);
            Assert.Equal(CommissionType.PerPerson, order.CommissionConfigs.Type);
            Assert.Equal(WhoPayCommission.FoodBusiness, order.CommissionConfigs.WhoPay);
        }
    }
}