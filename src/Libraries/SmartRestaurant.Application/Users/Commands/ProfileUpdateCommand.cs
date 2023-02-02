using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using System;
using Newtonsoft.Json;

namespace SmartRestaurant.Application.Users.Commands
{
    public class ProfileUpdateCommand : IRequest<NoContent>
    {
        [JsonIgnore] public string Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class ProfileUpdateCommandValidator : AbstractValidator<ProfileUpdateCommand>
    {
        public ProfileUpdateCommandValidator()
        {
            RuleFor(updateUser => updateUser.FullName).NotEmpty();
            RuleFor(updateUser => updateUser.PhoneNumber).NotEmpty();

        }
    }
}