using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using System;
using Newtonsoft.Json;

namespace SmartRestaurant.Application.Users.Commands
{
    public class UpdateProfileCommand : IRequest<NoContent>
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class UpdateProfileCommandValidator : AbstractValidator<UpdateProfileCommand>
    {
        public UpdateProfileCommandValidator()
        {
            RuleFor(updateUser => updateUser.FullName).NotEmpty();
            RuleFor(updateUser => updateUser.PhoneNumber).NotEmpty();

        }
    }
}