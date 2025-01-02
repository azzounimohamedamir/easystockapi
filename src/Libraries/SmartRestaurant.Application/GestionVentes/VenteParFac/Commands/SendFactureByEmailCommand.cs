using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dto;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionVentes.VenteParFac.Commands
{
    public class SendFactureByEmailCommand : CreateCommand
    {

        public string Email { get; set; }
        public string PdfLink { get; set; }
        public Guid FactureId { get; set; } 

    }

    public class SendFactureByEmailCommandValidator : AbstractValidator<SendFactureByEmailCommand>
    {
        public SendFactureByEmailCommandValidator()
        {
            RuleFor(m => m.PdfLink).NotEmpty();

        }
    }
}