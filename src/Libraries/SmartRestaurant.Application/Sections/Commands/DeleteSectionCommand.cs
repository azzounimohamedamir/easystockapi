using System;
using MediatR;

namespace SmartRestaurant.Application.Sections.Commands
{
    public class DeleteSectionCommand : IRequest
    {
        public Guid SectionId { get; set; }
    }
}
