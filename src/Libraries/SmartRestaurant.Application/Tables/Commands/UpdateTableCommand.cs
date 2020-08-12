using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.Tables.Commands
{
    public class UpdateTableCommand : SmartRestaurantCommand
    {
        public int TableNumber { get; set; }
        public Guid ZoneId { get; set; }
        public int Capacity { get; set; }
        public short TableState { get; set; }
    }
    public class UpdateTableCommandValidator : AbstractValidator<UpdateTableCommand>
    {
        public UpdateTableCommandValidator()
        {
            RuleFor(v => v.TableNumber)
                .GreaterThan(0);
            RuleFor(v => v.Capacity)
                .GreaterThan(0);
            RuleFor(v => v.ZoneId)
                .NotEmpty()
                .Must(v => v != Guid.Empty);

        }
    }
}
