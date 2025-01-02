using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Clients.Commands
{
    public class CreateClientCommand : CreateCommand
    {
        public string FullName { get; set; }
        public string RaisonSociale { get; set; }
        public string Commerce { get; set; }

        public string Email { get; set; }
        public string Addresse { get; set; }
        public string Tel { get; set; }
        public decimal Nrc { get; set; }
        public decimal Nif { get; set; }
        public decimal Nic { get; set; }

        public decimal Numarticle { get; set; }
        public decimal TotalCredits { get; set; }
        public decimal TotalAvances { get; set; }
        public bool IsBanned { get; set; }
        public DateTime DateEcheance { get; set; }

    }

    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);

        }
    }
}