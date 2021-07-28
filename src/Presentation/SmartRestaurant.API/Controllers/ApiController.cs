using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private IMediator _mediator;

        protected ApiController()
        {
        }

        protected ApiController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();


        public Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            return Mediator.Send(request);
        }

        public async Task<IActionResult> SendWithErrorsHandlingAsync<TRequest>(IRequest<TRequest> request)
        {
            try
            {
                var result = await Mediator.Send(request);
                if (result.GetType() != typeof(ValidationResult)) return Ok(result);
                var errors = ExtractValidationErrors(result);
                return BadRequest(new Dictionary<string, string[]>
                {
                    {"ErrorMessages", errors.ToArray()}
                });
            }
            catch (Exception exception)
            {
                if (exception.GetType().IsSubclassOf(typeof(BaseException)))
                    if (exception is BaseException result)
                        return StatusCode(result.StatusCode, result.Message);

                return StatusCode(500);
            }
        }

        public IActionResult SendWithIdentityErrorsHandlingAsync<TRequest>(TRequest result)
        {
            var errors = new List<string>();
            var validationFailures = (result as ValidationResult)?.Errors;
            if (validationFailures != null) errors.AddRange(validationFailures.Select(error => error.ErrorMessage));
            return BadRequest(new Dictionary<string, string[]>
            {
                {"ErrorMessages", errors.ToArray()}
            });
        }

        private static List<string> ExtractValidationErrors<TRequest>(TRequest result)
        {
            var errors = new List<string>();
            var validationFailures = (result as ValidationResult)?.Errors;
            if (validationFailures != null) errors.AddRange(validationFailures.Select(error => error.ErrorMessage));
            return errors;
        }

        protected Task SendEmailConfirmation(ApplicationUser user, string code)
        {
            var url = $"{Request.Scheme}://{Request.Host.Value}.{Request.PathBase}";
            var callBack = url + "/account/confirmEmail/" + user.Id + "?token=" + HttpUtility.UrlEncode(code);
            return _emailSender.SendEmailAsync(user.Email, "Confirm your email",
                $"Please confirm your account by <a href='{callBack}'>clicking here</a>.");
        }

        protected Task SendPassword(string email, string password)
        {
            return _emailSender.SendEmailAsync(email, "Password",
                $"Please use this Password: {password} to sign in to your account");
        }
    }
}