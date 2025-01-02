using System;
using System.Collections.Generic;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionVentes.VenteComptoir.Commands
{
    public class UpdateVenteComptoirCommand : UpdateCommand
    {
        public DateTime Date { get; set; }
        public decimal Remise { get; set; }
        public decimal MontantTotal { get; set; }
        public decimal MontantAprRemise { get; set; }
        public Guid VendeurId { get; set; }
        public List<VenteComptoirProducts> VenteComptoirIncludedProducts { get; set; }

    }

    public class UpdateVenteComptoirCommandValidator : AbstractValidator<UpdateVenteComptoirCommand>
    {
        public UpdateVenteComptoirCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);
           
        }
    }
}