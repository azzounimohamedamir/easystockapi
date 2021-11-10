using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.Illness.Queries
{
    public class GetIllnessByIdQuery : IRequest<IllnessDto>
    {
        public string Id { get; set; }
    }

    public class GetIllnessByIdQueryValidator : AbstractValidator<GetIllnessByIdQuery>
    {
        public GetIllnessByIdQueryValidator()
        {
            RuleFor(illness => illness.Id)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
