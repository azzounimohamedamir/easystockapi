using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Common.Enums;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Orders.Commands
{
    public class AcceptOrderSHCommand : IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
        public SHOrderStat Status { get; set; }

    }

    public class AcceptOrderSHCommandValidator : AbstractValidator<AcceptOrderSHCommand>
    {
        public AcceptOrderSHCommandValidator()
        {
            RuleFor(o => o.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(m => m.Status)
                .IsInEnum();

         
        }
    }
}
