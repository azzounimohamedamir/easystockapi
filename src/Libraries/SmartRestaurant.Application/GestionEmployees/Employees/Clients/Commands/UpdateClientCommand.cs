﻿using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Clients.Commands
{
    public class UpdateClientCommand : UpdateCommand
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

    public class UpdateClientCommandValidator : AbstractValidator<UpdateClientCommand>
    {
        public UpdateClientCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);

        }
    }
}