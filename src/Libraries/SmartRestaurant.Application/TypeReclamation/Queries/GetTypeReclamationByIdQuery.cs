using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace SmartRestaurant.Application.TypeReclamation.Queries
{
    public class GetTypeReclamationByIdQuery : IRequest<TypeReclamationDto>
    {
        [JsonIgnore] public string TypeReclamationId { get; set; }
    }

    public class GetTypeReclamationByIdQueryValidator : AbstractValidator<GetTypeReclamationByIdQuery>
    {
        public GetTypeReclamationByIdQueryValidator()
        {
            RuleFor(type => type.TypeReclamationId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
