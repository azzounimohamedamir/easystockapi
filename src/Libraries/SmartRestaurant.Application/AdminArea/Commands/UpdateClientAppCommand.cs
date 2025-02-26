using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.AdminArea.Commands
{
    public class UpdateClientAppCommand : UpdateCommand
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string MacAdresse { get; set; }

    }

#pragma warning disable CS0101 // L'espace de noms 'SmartRestaurant.Application.AdminArea.Commands' contient déjà une définition pour 'UpdateClientAppCommandValidator'
    public class UpdateClientAppCommandValidator : AbstractValidator<UpdateClientAppCommand>
#pragma warning restore CS0101 // L'espace de noms 'SmartRestaurant.Application.AdminArea.Commands' contient déjà une définition pour 'UpdateClientAppCommandValidator'
    {
#pragma warning disable CS0111 // Le type 'UpdateClientAppCommandValidator' définit déjà un membre appelé 'UpdateClientAppCommandValidator' avec les mêmes types de paramètre
        public UpdateClientAppCommandValidator()
#pragma warning restore CS0111 // Le type 'UpdateClientAppCommandValidator' définit déjà un membre appelé 'UpdateClientAppCommandValidator' avec les mêmes types de paramètre
        {
            RuleFor(m => m.Id).NotEmpty().Must(id => id != Guid.Empty);

        }
    }
}