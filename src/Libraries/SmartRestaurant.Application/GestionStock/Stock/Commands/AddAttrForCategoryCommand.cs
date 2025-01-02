using System;
using System.Collections.Generic;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Stock.Commands
{
    public class AddAttrForCategoryCommand : CreateCommand
    {
         public Guid CategoryId {  get; set; }
         public string AttributName { get; set; }
    }

    public class AddAttrForCategoryCommandValidator : AbstractValidator<AddAttrForCategoryCommand>
    {
        public AddAttrForCategoryCommandValidator()
        {
            RuleFor(m => m.AttributName).NotEmpty().MaximumLength(200);
            RuleFor(m => m.CategoryId).NotEmpty().Must(id => id != Guid.Empty);
        }
    }
}