using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Domain.ValueObjects;
using System;
using FluentValidation;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Reclamation.Commands
{
    public class CreateReclamationCommand : CreateCommand
    {
        public string ClientId { get; set; }
        public string RoomId { get; set; }
        public string CheckinId { get; set; }
        public NamesDto ReclamationDescription { get; set; }
        public string TypeReclamationId { get; set; }

        public IFormFile Picture { get; set; }
        public DateTime ? CreatedAt { get; set; }
        public ReclamationStatus Status { get; set; }
    }

    public class CreateReclamationCommandValidator : AbstractValidator<CreateReclamationCommand>
    {
        public CreateReclamationCommandValidator()
        {
          
            RuleFor(l => l.Picture).NotEmpty();

        }
    }
}
