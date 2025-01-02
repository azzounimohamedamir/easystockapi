using System;
using System.Collections.Generic;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dto;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionVentes.VenteComptoir.Commands
{
    public class CreateVenteComptoirCommand : CreateCommand
    {
        public decimal Remise { get; set; }
        public decimal MontantTotal { get; set; }
        public decimal MontantAprRemise { get; set; }
        public string VendeurId { get; set; }
        public List<VenteComptoirProducts> VenteComptoirIncludedProducts { get; set; }

    }

    public class CreateVenteComptoirCommandValidator : AbstractValidator<CreateVenteComptoirCommand>
    {
        public CreateVenteComptoirCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);
           

        }
    }
}