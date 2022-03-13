using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Illness.Queries
{
    public class GetDeshesIllnessQuery : IRequest<IList<DisheIllnessDto>>
    {
        public List<string> disheIds { get; set; }
        public List<string> illnesIds { get; set; }
    }
    public class GetDeshesIllnessQueryValidator : AbstractValidator<GetDeshesIllnessQuery>
    {
        public GetDeshesIllnessQueryValidator()
        {
            RuleFor(x => x.disheIds)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithMessage("'{PropertyName}' must be a valid GUID");
            RuleFor(x => x.illnesIds)
                 .Cascade(CascadeMode.StopOnFirstFailure)
                 .NotEmpty()
                 .WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}
