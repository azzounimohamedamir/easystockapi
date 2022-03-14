using System;
using System.Collections.Generic;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.Validators;

namespace SmartRestaurant.Application.Dishes.Commands
{
    public class CreateDishCommand : CreateCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public float Price { get; set; } 
        public string FoodBusinessId { get; set; }
        public List<DishSpecificationDto> Specifications { get; set; }
        public List<DishIngredientCreateDto> Ingredients { get; set; }
        public List<DishSupplementCreateDto> Supplements { get; set; }
        public bool IsSupplement { get; set; }
        public int EstimatedPreparationTime { get; set; }
    }

    public class CreateDishCommandValidator : AbstractValidator<CreateDishCommand>
    {
        public CreateDishCommandValidator()
        {
            RuleFor(dish => dish.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(dish => dish.Picture)
                .NotEmpty();

            RuleFor(dish => dish.Price)
                .GreaterThanOrEqualTo(0);

            RuleFor(dish => dish.EstimatedPreparationTime)
                .GreaterThanOrEqualTo(0);

            RuleFor(dish => dish.Description)
               .MaximumLength(500);

            RuleFor(dish => dish.FoodBusinessId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

            RuleForEach(dish => dish.Ingredients)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("'Ingredient' must not be empty")
                .SetValidator(new DishIngredientCreateDtoValidator())
                .When(dish => dish.Ingredients != null);

            RuleForEach(dish => dish.Supplements)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("'Supplement' must not be empty")
               .SetValidator(new DishSupplementCreateDtoValidator())
               .When(dish => dish.Supplements != null);

            RuleForEach(dish => dish.Specifications)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty().WithMessage("'Specification' must not be empty")
              .SetValidator(new DishSpecificationDtoValidator())
              .When(dish => dish.Specifications != null);

            RuleFor(x => x.IsSupplement)
                .Must(x => false).WithMessage("Supplement dish can not have supplements")
                .When(x => x.IsSupplement == true && x.Supplements.Count > 0);
        }
    }  
}