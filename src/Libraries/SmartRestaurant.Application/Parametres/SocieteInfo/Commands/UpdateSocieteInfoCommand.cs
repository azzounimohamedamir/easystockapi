using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.Parametres.SocieteInfo.Commands
{
    public class UpdateSocieteInfoCommand : UpdateCommand
    {
        public string NomSociete { get; set; }
        public string Activite { get; set; }
        public string Email { get; set; }
        public string Siteweb { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string RegistreCommerce { get; set; }
        public string Rib { get; set; }
        public string Nif { get; set; }
        public string Nis { get; set; }
        public string NumeroArticle { get; set; }
        public string Logo { get; set; } // Assuming the logo is stored as a URL in the backend

    }

    public class UpdateSocieteInfoCommandValidator : AbstractValidator<UpdateSocieteInfoCommand>
    {
        public UpdateSocieteInfoCommandValidator()
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);

        }
    }
}