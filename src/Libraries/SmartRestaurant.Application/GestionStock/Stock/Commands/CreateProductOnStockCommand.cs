using System;
using System.Collections.Generic;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Stock.Commands
{
    public class CreateProductOnStockCommand : CreateCommand
    {
        public string Designaation { get; set; }
        public string Image { get; set; }

        public string CodeBar { get; set; }

      

        public string Rayonnage { get; set; }

        public int QteAlerte { get; set; }
        public int QteInitiale { get; set; }

        public int QteRestante { get; set; }
        public decimal PrixVenteDetail { get; set; }
        public decimal PrixAchat { get; set; }

        public decimal PrixVenteGros { get; set; }
        public decimal Tva { get; set; }
        public bool IsPerissable { get; set; }
        public DateTime DatePeremption { get; set; }
        public int JourAlerte { get; set; }
        public Guid CategoryId { get; set; }

        public List<AttributsNew> ProductAttributeValues { get;set;}
    }

    public class CreateProductOnStockCommandValidator : AbstractValidator<CreateProductOnStockCommand>
    {
        public CreateProductOnStockCommandValidator()
        {
            RuleFor(m => m.Designaation).NotEmpty().MaximumLength(200);
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);
         

        }
    }
}