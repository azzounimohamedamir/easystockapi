using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dto;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionAchats.BonsAchat.Commands
{
    public class AjouterRegAcompteBACommand : CreateCommand
    {

        public Guid FournisseurId { get; set; }
        public Guid BAId { get; set; }
        public decimal Montant { get; set; }
        public DateTime Date { get; set; }
        public string Libelle { get; set; }
        public string Type { get; set; }

    }

    public class AjouterRegAcompteBACommandValidator : AbstractValidator<AjouterRegAcompteBACommand>
    {
        public AjouterRegAcompteBACommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);
           
        }
    }
}