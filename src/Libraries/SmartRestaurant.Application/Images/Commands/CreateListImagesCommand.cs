using MediatR;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Images.Commands
{
    public class CreateListImagesCommand : IRequest
    {
        public CreateListImagesCommand()
        {
            ImageCommands = new List<CreateImageCommand>();
        }
        public Guid EntityId { get; set; }
        public List<CreateImageCommand> ImageCommands { get; set; }
    }
}
