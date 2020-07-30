using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Suppliers.Commands
{
    public class SupplierCommandsHandler :
        IRequestHandler<CreateSupplierCommand, ValidationResult>,
        IRequestHandler<UpdateSupplierCommand, ValidationResult>,
        IRequestHandler<DeleteSupplierCommand>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SupplierCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public  async Task< ValidationResult> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            //var entity = await _context.Suppliers.FindAsync(request).ConfigureAwait(false);

            //if (entity == null)
            //    throw new NotFoundException(nameof(Supplier), request.SupplierId);

            //var validator = new UpdateSupplierCommandValidator();
            //var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            //if (!result.IsValid) return result;
            //entity = _mapper.Map<Supplier>(request);
            //await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        async Task<ValidationResult> IRequestHandler<CreateSupplierCommand, ValidationResult>.Handle(CreateSupplierCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSupplierCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var entity = _mapper.Map<Supplier>(request);
            if (request.RestaurantId.HasValue)
            {
                var restaurant = await _context.FoodBusinesses.FindAsync(request.RestaurantId).ConfigureAwait(false);
                if(restaurant!= null)
                    entity.Restaurants.Add(restaurant);
            }
           // _context.Suppliers.Add(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<Unit> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
          ////  var entity = await _context.Suppliers.FindAsync(request).ConfigureAwait(false);

          //  if (entity == null)
          //      throw new NotFoundException(nameof(Supplier), request.SupplierId);
          //  //_context.Suppliers.Remove(entity);
          //  await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return Unit.Value;
        }
    }
}
