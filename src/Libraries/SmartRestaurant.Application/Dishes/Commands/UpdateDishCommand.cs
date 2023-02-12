using System;
using System.Collections.Generic;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos.DishDtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.Validators;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;

namespace SmartRestaurant.Application.Dishes.Commands
{
    public class UpdateDishCommand : IRequest<NoContent>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
        public string Name { get; set; }
        public NamesDto Names { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public float Price { get; set; }
        [SwaggerSchema(ReadOnly = true)] public float EnergeticValue { get; set; }
        public List<DishSpecificationDto> Specifications { get; set; }
        public List<DishIngredientCreateDto> Ingredients { get; set; }
        public List<DishSupplementCreateDto> Supplements { get; set; }
        public bool IsSupplement { get; set; }
        public int Quantity { get; set; }
        public bool IsQuantityChecked { get; set; }



        public int EstimatedPreparationTime { get; set; }
    }

    public class UpdateDishCommandValidator : AbstractValidator<UpdateDishCommand>
    {
        public UpdateDishCommandValidator()
        {
            RuleFor(dish => dish.Id)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty()
               .NotEqual(Guid.Empty.ToString())
               .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

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
                   RuleFor(dish => dish.Quantity)
                .GreaterThanOrEqualTo(0);
            
            RuleFor(v => v.Names)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .DependentRules(() => {
                   RuleFor(v => v.Names.AR)
                      .Cascade(CascadeMode.StopOnFirstFailure)
                      .NotEmpty()
                      .MaximumLength(200);

                   RuleFor(v => v.Names.EN)
                      .Cascade(CascadeMode.StopOnFirstFailure)
                      .NotEmpty()
                      .MaximumLength(200);

                   RuleFor(v => v.Names.FR)
                      .Cascade(CascadeMode.StopOnFirstFailure)
                      .NotEmpty()
                      .MaximumLength(200);

                   RuleFor(v => v.Names.TR)
                      .Cascade(CascadeMode.StopOnFirstFailure)
                      .NotEmpty()
                      .MaximumLength(200);

                   RuleFor(v => v.Names.RU)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty()
                    .MaximumLength(200);
                });
        }
    }
}