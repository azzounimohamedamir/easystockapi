using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos.OrdersDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.Validators;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.Application.Orders.Commands
{
    public class CreateOrderSHCommand : IRequest<HotelOrder>
    {
        public CreateOrderSHCommand()
        {
            Id = Guid.NewGuid();
        }

        [SwaggerSchema(ReadOnly = true)]
        [JsonIgnore]
        public Guid Id { get; set; }
        public Guid SectionId { get; set; }
        public OrderTypes Type { get; set; }
        public List<OrderDishCommandDto> Dishes { get; set; }
        public List<OrderProductDto> Products { get; set; }
        public List<OrderOccupiedTableDto> OccupiedTables { get; set; }
        public string FoodBusinessId { get; set; }
        public string FoodBusinessClientId { get; set; }
         public GeoPositionDto GeoPosition { get; set; }
        public string CheckinId { get; set; }
        public string RoomId { get; set; }
        public string HotelId { get; set; }

        public List<ParametresValue>? ParametreValueClient { get; set; }

        public int? Quantity { get; set; }
        
        public string ServiceId { get; set;}
    }

    public class CreateOrderSHCommandValidator : AbstractValidator<CreateOrderSHCommand>
    {
        public CreateOrderSHCommandValidator()
        {
            RuleFor(m => m.Type)
                .IsInEnum();
 
        }
    }
}