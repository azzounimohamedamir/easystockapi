using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Tables.Commands
{
    public class CreateTableCommand : CreateCommand
    {
        public string ZoneId { get; set; }
        public int Capacity { get; set; }
    }

    public class CreateTableCommandValidator : AbstractValidator<CreateTableCommand>
    {
        public CreateTableCommandValidator()
        {
            RuleFor(table => table.Capacity)
                .GreaterThan(0)
                .LessThanOrEqualTo(99);

            RuleFor(table => table.ZoneId)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

        }
    }
}