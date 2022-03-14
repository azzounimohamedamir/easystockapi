using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Users.Commands
{
    public class UpdateUserCommand : IRequest<NoContent>
    {
        [JsonIgnore] public string Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public List<string> Roles { get; set; }
    }

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(updateUser => updateUser.FullName).NotEmpty();
            RuleFor(updateUser => updateUser.PhoneNumber).NotEmpty();
            RuleFor(updateUser => updateUser.Roles).NotEmpty();

            RuleFor(updateUser => updateUser.Id)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'User Id' must be a valid GUID");

            RuleForEach(updateUser => updateUser.Roles)            
                .ChildRules(role => role.RuleFor(x => x)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotEmpty().WithMessage("'Role' can not be empty")
                    .Must(ValidatorHelper.ValidateUsersRoles).WithMessage("'Role: {PropertyValue}' is invalide"));
        }
    }
}