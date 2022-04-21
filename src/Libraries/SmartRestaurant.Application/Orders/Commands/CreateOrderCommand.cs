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
using SmartRestaurant.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.Application.Orders.Commands
{
    public class CreateOrderCommand : IRequest<OrderIdDto>
    {
        public CreateOrderCommand()
        {
            Id = Guid.NewGuid();
        }

        [SwaggerSchema(ReadOnly = true)]
        [JsonIgnore]
        public Guid Id { get; set; }
        public OrderTypes Type { get; set; }
        public TakeoutDetailsDto TakeoutDetails { get; set; }
        public List<OrderDishCommandDto> Dishes { get; set; }
        public List<OrderProductDto> Products { get; set; }
        public List<OrderOccupiedTableDto> OccupiedTables { get; set; }
        public string FoodBusinessId { get; set; }
        public string FoodBusinessClientId { get; set; }
    }

    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
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


            RuleFor(m => m.FoodBusinessId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(m => m.FoodBusinessClientId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID")
                .When(x => x.FoodBusinessClientId != null);

            RuleFor(x => x.Dishes)
                 .Must(x => false).WithMessage("Order can not be empty, please select at least a dish or product")
                 .When(x => ChecksHelper.IsEmptyList(x.Dishes) == true && ChecksHelper.IsEmptyList(x.Products) == true);

            RuleFor(x => x.OccupiedTables)
                 .Must(x => false).WithMessage("Please select the Occupied Tables because the order type is DineIn")
                 .When(x => ChecksHelper.IsEmptyList(x.OccupiedTables) == true && x.Type == OrderTypes.DineIn);

            RuleFor(x => x.OccupiedTables)
                 .Must(x => false).WithMessage("You can not occupy tables if Order type is Takeout or Delivery")
                 .When(x => ChecksHelper.IsEmptyList(x.OccupiedTables) == false && (x.Type == OrderTypes.Takeout || x.Type == OrderTypes.Delivery));

            RuleForEach(x => x.OccupiedTables)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("'Dish Occupied Table' must not be empty")
                .SetValidator(new OrderOccupiedTableDtoValidator())
                .When(x => ChecksHelper.IsEmptyList(x.OccupiedTables) == false && x.Type == OrderTypes.DineIn);
           
            RuleForEach(x => x.Products)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("'Ingredient' must not be empty")
                .SetValidator(new OrderProductDtoValidator())
                .When(x => ChecksHelper.IsEmptyList(x.Products) == false);

            RuleForEach(x => x.Dishes)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("'Dish' must not be empty")
                .SetValidator(new OrderDishCommandDtoValidator())
                .When(x => ChecksHelper.IsEmptyList(x.Dishes) == false);
        }
    }
}