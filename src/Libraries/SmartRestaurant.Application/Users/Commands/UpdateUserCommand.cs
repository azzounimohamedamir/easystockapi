using FluentValidation;
using MediatR;
using System;

namespace SmartRestaurant.Application.Users.Commands
{
    public class UpdateUserCommand : IRequest<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(v => v.FirstName)
                .MaximumLength(200)
                .NotEmpty();

            RuleFor(v => v.LastName)
                .MaximumLength(200)
                .NotEmpty();
        }
    }
}