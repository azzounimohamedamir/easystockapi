using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Common.Enums;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.AdminArea.Commands
{
    public class ResetLicenceCommand : UpdateCommand
    {
        public Guid IdClient { get; set; }

        public string FullName { get; set; }
        public string NewMacAdresse { get; set; }
        public string NewLicenceKey { get; set; }

    }

    public class ResetLicenceCommandValidator : AbstractValidator<ResetLicenceCommand>
    {
        public ResetLicenceCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);
          
        }
    }
}