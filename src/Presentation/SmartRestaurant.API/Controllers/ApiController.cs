using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace SmartRestaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private readonly IEmailSender _emailSender;
        private readonly ICollection<string> _errors = new List<string>();
        private IMediator _mediator;

        protected ApiController()
        {
        }

        protected ApiController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult ApiCustomResponse()
        {
            if (!_errors.Any())
                return Ok();
            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                {"ErrorMessages", _errors.ToArray()}
            }));
        }

        protected ActionResult ApiCustomResponse(ValidationResult validationResult)
        {
            if (validationResult?.Errors != null)
                foreach (var error in validationResult.Errors)
                    _errors.Add(error.ErrorMessage);

            return ApiCustomResponse();
        }

        protected ActionResult ApiCustomResponse(ValidationResult validationResult
            , ActionResult actionResult)
        {
            if (validationResult?.Errors != null)
            {
                foreach (var error in validationResult.Errors)
                {
                    _errors.Add(error.ErrorMessage);
                }
                                    
            }
                
            if (!_errors.Any())
            {
                return actionResult;
            }
            else
            {
                return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
                {
                    {"ErrorMessages", _errors.ToArray()}
                }));
            }       
        }

        protected ActionResult ApiCustomResponse(IdentityResult result)
        {
            if (!result.Succeeded)
                foreach (var error in result.Errors)
                    _errors.Add(error.Description);

            return ApiCustomResponse();
        }

        public Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            return Mediator.Send(request);
        }

        protected Task SendEmailConfirmation(ApplicationUser user, string code)
        {
            var url = string.Format("{0}://{1}.{2}", Request.Scheme, Request.Host.Value, Request.PathBase);
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