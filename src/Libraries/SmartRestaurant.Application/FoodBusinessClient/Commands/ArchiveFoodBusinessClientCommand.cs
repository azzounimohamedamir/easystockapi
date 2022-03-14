using FluentValidation;
using MediatR;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using System;

namespace SmartRestaurant.Application.FoodBusinessClient.Commands
{
    public class ArchiveFoodBusinessClientCommand : IRequest<NoContent>
    {
        [JsonIgnore] public string Id { get; set; }
        public bool Archived { get; set; }
    }
    public class ArchiveFoodBusinessClientCommandValidator : AbstractValidator<ArchiveFoodBusinessClientCommand>
    {
        public ArchiveFoodBusinessClientCommandValidator()
        {
            RuleFor(foodBusinessClient => foodBusinessClient.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleFor(v => v.Archived).Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull();
        }
    }
}