using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Tables.Commands
{
    public class UpdateTableCommand : UpdateCommand
    {
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public short TableState { get; set; }
        public Guid ZoneId { get; set; }
    }

    public class UpdateTableCommandValidator : AbstractValidator<UpdateTableCommand>
    {
        public UpdateTableCommandValidator()
        {
            RuleFor(v => v.TableNumber).GreaterThan(0);
            RuleFor(v => v.Capacity).GreaterThan(0);
            RuleFor(v => v.ZoneId).NotNull().NotEmpty().NotEqual(Guid.Empty);
            RuleFor(m => m.Id).NotNull().NotEmpty().NotEqual(Guid.Empty);
        }
    }
}