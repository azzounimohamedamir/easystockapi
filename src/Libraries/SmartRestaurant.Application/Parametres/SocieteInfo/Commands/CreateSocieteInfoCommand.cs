using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Parametres.SocieteInfo.Commands
{
    public class CreateSocieteInfoCommand : CreateCommand
    {
        public string NomSociete { get; set; }
        public string Activite { get; set; }
        public string Telephone { get; set; }
        public string Email { get; set; }
        public string Siteweb { get; set; }
        public string Adresse { get; set; }
        public Guid Categorie { get; set; }
        public string RegistreCommerce { get; set; }
        public string Rib { get; set; }
        public string Nif { get; set; }
        public string Nis { get; set; }
        public string NumeroArticle { get; set; }
        public string Logo { get; set; } // Assuming the logo is stored as a URL in the backend

    }

    public class CreateSocieteInfoCommandValidator : AbstractValidator<CreateSocieteInfoCommand>
    {
        public CreateSocieteInfoCommandValidator()
        {           
        }
    }
}