using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.WebResults;
using System;

namespace SmartRestaurant.Application.FoodBusinessClient.Commands
{
    public class ArchiveFoodBusinessClientCommand : IRequest<NoContent>
    {
        public Guid Id { get; set; }
        public Boolean Archived { get; set; }
    }
    public class ArchiveFoodBusinessClientCommandValidator : AbstractValidator<ArchiveFoodBusinessClientCommand>
    {
        public ArchiveFoodBusinessClientCommandValidator()
        {
            RuleFor(v => v.Archived).Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull()
               .NotEmpty()
               .Equals(Boolean.TrueString);
        }
    }
}