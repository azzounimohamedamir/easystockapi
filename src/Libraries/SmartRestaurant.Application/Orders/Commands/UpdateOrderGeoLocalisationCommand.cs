using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Enums;
using Swashbuckle.AspNetCore.Annotations;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Orders.Commands
{
    public class UpdateOrderGeoLocalisationCommand : IRequest<Order>
    {
        [SwaggerSchema(ReadOnly = true)] public string Id { get; set; }
        public GeoPositionDto GeoPosition { get; set; }
    }

    public class UpdateOrderGeoLocalisationCommandValidator : AbstractValidator<UpdateOrderGeoLocalisationCommand>
    {
        public UpdateOrderGeoLocalisationCommandValidator()
        {
            RuleFor(order => order.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");

                  RuleFor(order => order.GeoPosition)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .DependentRules(() => {
                    RuleFor(order => order.GeoPosition.Latitude)
                        .Cascade(CascadeMode.StopOnFirstFailure)
                        .NotEmpty();
                    

                    RuleFor(order => order.GeoPosition.Longitude)
                        .Cascade(CascadeMode.StopOnFirstFailure)
                        .NotEmpty();
                      

                 
                });

         
        }          
    }
}