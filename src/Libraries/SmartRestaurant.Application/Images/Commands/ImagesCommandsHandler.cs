using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Images.Commands
{
    public class ImagesCommandsHandler : IRequestHandler<CreateListImagesCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ImagesCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateListImagesCommand request, CancellationToken cancellationToken)
        {
            foreach (var entity in request.ImageCommands.Select(createFoodBusinessImageCommand => _mapper.Map<FoodBusinessImage>(createFoodBusinessImageCommand)))
            {
                entity.EntityId = request.EntityId;
                _context.FoodBusinessImages.Add(entity);
            }

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return Unit.Value;
        }
    }
}
