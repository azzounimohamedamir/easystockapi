using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace SmartRestaurant.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _mediator;
        private readonly ICollection<string> _errors = new List<string>();

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        protected ActionResult ApiCustomResponse()
        {
            if ( !_errors.Any())
                return Ok();
            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "ErrorMessages", _errors.ToArray() }
            }));
        }

        protected ActionResult ApiCustomResponse(ValidationResult validationResult)
        {
            if (validationResult?.Errors != null)
                foreach (var error in validationResult?.Errors)
                    _errors.Add(error.ErrorMessage);

            return ApiCustomResponse();
        }
       
    }
}
