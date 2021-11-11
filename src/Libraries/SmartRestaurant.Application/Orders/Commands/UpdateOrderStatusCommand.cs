using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.Application.Orders.Commands
{
    public class UpdateOrderStatusCommand : IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
        public OrderStatuses Status { get; set; }
    }

    public class UpdateOrderStatusCommandValidator : AbstractValidator<UpdateOrderStatusCommand>
    {
        public UpdateOrderStatusCommandValidator()
        {
            RuleFor(product => product.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(m => m.Status)
                .IsInEnum();
        }          
    }
}