using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Buildings.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using System.Text.Json.Serialization;

namespace SmartRestaurant.Application.Buildings.Commands
{
    public class UpdateBuildingCommand: UpdateCommand
    {
        public string Picture { get; set; }

        public string Name { get; set; }
      
    }
    public class UpdateBuildingCommandValidator : AbstractValidator<UpdateBuildingCommand>
    {
        public UpdateBuildingCommandValidator()
        {
            RuleFor(building => building.Id)
              .NotEmpty();

           
        }

    }
}
