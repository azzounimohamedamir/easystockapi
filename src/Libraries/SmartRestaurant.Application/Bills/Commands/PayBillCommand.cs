using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.Application.Bills.Commands
{
    public class PayBillCommand : IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
    }

    public class PayBillCommandValidator : AbstractValidator<PayBillCommand>
    {
        public PayBillCommandValidator()
        {
            RuleFor(product => product.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");        
        }
    }
}