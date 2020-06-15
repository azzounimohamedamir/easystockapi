using MediatR;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Interfaces;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Restaurants.Commands.DeleteRestaurant
{
    public class DeleteRestaurantCommand : IRequest
    {
        public int Id { get; set; }
    }
    public class DeleteTodoItemCommandHandler : IRequestHandler<DeleteRestaurantCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteTodoItemCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Restaurants.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Restaurant), request.Id);
            }

            _context.Restaurants.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
