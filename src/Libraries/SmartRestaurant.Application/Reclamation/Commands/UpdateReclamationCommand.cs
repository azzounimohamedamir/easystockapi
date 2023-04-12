using FluentValidation;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Reclamation.Commands
{
    public class UpdateReclamationCommand : UpdateCommand
    {
        public string TypeReclamationId { get; set; }

        public IFormFile Picture { get; set; }
    }
    public class UpdateReclamationCommandValidator : AbstractValidator<UpdateReclamationCommand>
    {
        public UpdateReclamationCommandValidator()
        {
            
            RuleFor(l => l.Picture).NotEmpty();
            RuleFor(l => l.TypeReclamationId).NotEmpty();

        }
    }

}
