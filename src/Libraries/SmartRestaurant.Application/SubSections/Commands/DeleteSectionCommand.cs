using System;
using MediatR;

namespace SmartRestaurant.Application.SubSections.Commands
{
    public class DeleteSubSectionCommand : IRequest
    {
        public Guid SubSectionId { get; set; }
    }
}