using System;
using MediatR;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.Common.Commands
{
    public class CreateCommand : IRequest<Created>
    {
        public CreateCommand()
        {
            Id = Guid.NewGuid();
        }

        [JsonIgnore] public Guid Id { get; set; }
    }
}