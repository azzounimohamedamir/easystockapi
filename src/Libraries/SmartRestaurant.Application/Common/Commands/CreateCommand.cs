using MediatR;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.WebResults;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace SmartRestaurant.Application.Common.Commands
{
    public class CreateCommand : IRequest<Created>
    {
        public CreateCommand()
        {
            Id = Guid.NewGuid();
        }

        [SwaggerSchema(ReadOnly = true)]
        [JsonIgnore]
        public Guid Id { get; set; }
    }
}