using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using System;

namespace SmartRestaurant.Application.Sections.Queries
{
    public class GetSectionByIdQuery : IRequest<SectionDto>
    {
        [JsonIgnore] public string Id { get; set; }
    }

    public class GetSectionByIdQueryValidator : AbstractValidator<GetSectionByIdQuery>
    {
        public GetSectionByIdQueryValidator()
        {
            RuleFor(section => section.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}