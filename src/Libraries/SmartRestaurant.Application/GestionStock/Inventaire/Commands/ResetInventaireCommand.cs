using System;
using System.Collections.Generic;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.GestionStock.Inventaire.Commands
{
    public class ResetInventaireCommand : UpdateCommand
    {
        public Equipe  Equipe { get; set; }

    }

    public class ResetInventaireCommandValidator : AbstractValidator<ResetInventaireCommand>
    {
        public ResetInventaireCommandValidator()
        {
           
        }
    }
}