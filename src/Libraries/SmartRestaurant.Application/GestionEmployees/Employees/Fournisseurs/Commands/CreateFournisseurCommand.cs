using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Enums;
using System;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Fournisseurs.Commands
{
    public class CreateFournisseurCommand : CreateCommand
    {
        public string FullName { get; set; }
        public TypeEmploye TypeEmploye { get; set; }
        public string RaisonSociale { get; set; }
        public string Commerce { get; set; }

        public string Email { get; set; }
        public string Addresse { get; set; }
        public string Tel { get; set; }
        public decimal Nrc { get; set; }
        public decimal Nif { get; set; }
        public decimal Nic { get; set; }

        public decimal Numarticle { get; set; }

    }

    public class CreateFournisseurCommandValidator : AbstractValidator<CreateFournisseurCommand>
    {
        public CreateFournisseurCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);

        }
    }
}