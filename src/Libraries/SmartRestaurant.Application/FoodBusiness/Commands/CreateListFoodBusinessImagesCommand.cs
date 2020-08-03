using MediatR;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class CreateListFoodBusinessImagesCommand : IRequest
    {
        public CreateListFoodBusinessImagesCommand()
        {
            ImageCommands = new List<CreateFoodBusinessImageCommand>();
        }
        public Guid FoodBusinessId { get; set; }
        public List<CreateFoodBusinessImageCommand> ImageCommands { get; set; }
    }
}
