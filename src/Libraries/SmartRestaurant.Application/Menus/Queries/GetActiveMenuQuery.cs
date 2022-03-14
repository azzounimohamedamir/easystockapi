using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Menus.Queries
{
    public class GetActiveMenuQuery : IRequest<ActiveMenuDto>
    {
        public string FoodBusinessId { get; set; }
    }

    public class GetActiveMenuQueryValidator : AbstractValidator<GetActiveMenuQuery>
    {
        public GetActiveMenuQueryValidator()
        {
            RuleFor(product => product.FoodBusinessId)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}