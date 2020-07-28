using System;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Suppliers.Commands
{
    public class UpdateSupplierCommand :IRequest<ValidationResult>
    {
        public Guid SupplierId { get; set; }
        public string NameArabic { get; set; }
        public string NameFrench { get; set; }
        public string NameEnglish { get; set; }
        public int NRC { get; set; }
        public int NIF { get; set; }
        public int NIS { get; set; }
        public PhoneNumberDto PhoneNumber { get; set; }
        public string Email { get; set; }
        public AddressDto Address { get; set; }
        public string Website { get; set; }
        public ApplicationUser UserManager { get; set; }
        public Guid? RestaurantId { get; set; }
    }
    public class UpdateSupplierCommandValidator : AbstractValidator<UpdateSupplierCommand>
    {
        public UpdateSupplierCommandValidator()
        {
            RuleFor(v => v.NameEnglish)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}
