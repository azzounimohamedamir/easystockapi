using System;
using System.Collections.Generic;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Stock.Commands
{
    public class AddValuesForAttributCommand : CreateCommand
    {
        public Guid AttributId { get; set; }
        public List<string> Values { get; set; }
    }

    public class AddValuesForAttributCommandValidator : AbstractValidator<AddValuesForAttributCommand>
    {
        public AddValuesForAttributCommandValidator()
        {
            RuleForEach(m => m.Values).NotEmpty().MaximumLength(200);
            RuleFor(m => m.AttributId).NotEmpty().Must(id => id != Guid.Empty);
        }
    }
}