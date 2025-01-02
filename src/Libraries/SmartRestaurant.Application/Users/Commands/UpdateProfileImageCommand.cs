using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.WebResults;
using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Domain.Identity.Entities;

namespace SmartRestaurant.Application.Users.Commands
{
	public class UpdateProfileImageCommand : IRequest<NoContent>
	{
        public string Picture { get; set; }

    }

	public class UpdateProfileImageCommandValidator : AbstractValidator<UpdateProfileImageCommand>
	{
		public UpdateProfileImageCommandValidator()
		{
            RuleFor(updateUser => updateUser.Picture).NotEmpty();

        }
	}
}