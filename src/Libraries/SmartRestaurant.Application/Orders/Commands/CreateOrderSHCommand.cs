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
    public class CreateOrderSHCommand : CreateCommand
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
        public TakeoutDetailsDto TakeoutDetails { get; set; }
        public List<OrderDishCommandDto> Dishes { get; set; }
        public List<OrderProductDto> Products { get; set; }
        public List<OrderOccupiedTableDto> OccupiedTables { get; set; }
        public string FoodBusinessId { get; set; }
        public string FoodBusinessClientId { get; set; }
         public GeoPositionDto GeoPosition { get; set; }
        public string CheckinId { get; set; }
        public List<ParametresValue> ParametreValueClient { get; set; }
        public string ServiceId { get; set;}
    }

    public class CreateOrderSHCommandValidator : AbstractValidator<CreateOrderSHCommand>
    {
        public CreateOrderSHCommandValidator()
        {
            RuleFor(m => m.Type)
                .IsInEnum();

            RuleFor(x => x.TakeoutDetails)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotEmpty().WithMessage("'{PropertyName}' details must not be empty")
             .DependentRules(() => {
                 RuleFor(x => x.TakeoutDetails.Type)
                  .IsInEnum();

                 RuleFor(x => x.TakeoutDetails.DeliveryTime)
                    .Must(x => false).WithMessage("'{PropertyName}' must be null because you have set Takeout type as Instant")
                    .When(x => x.TakeoutDetails.Type == TakeoutType.Instant && x.TakeoutDetails.DeliveryTime != null);

                 RuleFor(x => x.TakeoutDetails.DeliveryTime)
                   .Must(x => false).WithMessage("You have to set Delivery Time because you have set Takeout type as Delayed")
                   .When(x => x.TakeoutDetails.Type == TakeoutType.Delayed && x.TakeoutDetails.DeliveryTime == default);
             })
             .When(x => x.Type == OrderTypes.Takeout);


          

        
           
          
        }
    }
}