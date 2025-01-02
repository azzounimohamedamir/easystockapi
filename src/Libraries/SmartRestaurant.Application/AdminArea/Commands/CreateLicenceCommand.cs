using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.AdminArea.Commands
{
    public class CreateLicenceCommand : CreateCommand
    {
        public string LicenceKey { get; set; }
        public Guid ClientId { get; set; }

        public string ClientName { get; set; }
        public bool Status { get; set; }
        public DateTime ExpDate { get; set; }

    }

    public class CreateLicenceCommandValidator : AbstractValidator<CreateLicenceCommand>
    {
        public CreateLicenceCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);

        }
    }
}