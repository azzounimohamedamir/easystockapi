using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.SubSections.Queries
{
    public class GetSubSectionByIdQuery : IRequest<SubSectionDto>
    {
        [JsonIgnore] public string Id { get; set; }
    }

    public class GetSubSectionByIdQueryValidator : AbstractValidator<GetSubSectionByIdQuery>
    {
        public GetSubSectionByIdQueryValidator()
        {
            RuleFor(section => section.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}