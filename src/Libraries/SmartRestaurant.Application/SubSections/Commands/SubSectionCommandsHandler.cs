using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.SubSections.Commands
{
    public class SubSectionsCommandsHandler :
        IRequestHandler<CreateSubSectionCommand, Created>,
        IRequestHandler<UpdateSubSectionCommand, NoContent>,
        IRequestHandler<DeleteSubSectionCommand, NoContent>,
        IRequestHandler<AddProductToSubSectionCommand, NoContent>,
        IRequestHandler<AddDishToSubSectionCommand, NoContent>,
        IRequestHandler<RemoveProductFromSubSectionCommand, NoContent>,
        IRequestHandler<RemoveDishFromSubSectionCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SubSectionsCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateSubSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSubSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var subSection = _mapper.Map<SubSection>(request);
            _context.SubSections.Add(subSection);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteSubSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteSubSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var subSection = await _context.SubSections.FindAsync(request.Id).ConfigureAwait(false);
            if (subSection == null)
                throw new NotFoundException(nameof(subSection), request.Id);
            _context.SubSections.Remove(subSection);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateSubSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSubSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var subSection = await _context.SubSections.AsNoTracking()
                .FirstOrDefaultAsync(s => s.SubSectionId == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (subSection == null)
                throw new NotFoundException(nameof(subSection), request.Id);
            subSection = _mapper.Map<SubSection>(request);
            _context.SubSections.Update(subSection);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(AddProductToSubSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddProductToSubSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var subSection = await _context.SubSections.AsNoTracking()
                .FirstOrDefaultAsync(s => s.SubSectionId == Guid.Parse(request.SubSectionId), cancellationToken)
                .ConfigureAwait(false);
            if (subSection == null)
                throw new NotFoundException(nameof(SubSection), request.SubSectionId);

            var product = await _context.Products.AsNoTracking()
               .FirstOrDefaultAsync(s => s.ProductId == Guid.Parse(request.ProductId), cancellationToken)
               .ConfigureAwait(false);
            if (product == null)
                throw new NotFoundException(nameof(Product), request.ProductId);

            var subSectionProductExistance = await _context.SubSectionProducts.AsNoTracking().FirstOrDefaultAsync(s =>
             s.ProductId == Guid.Parse(request.ProductId) &&
             s.SubSectionId == Guid.Parse(request.SubSectionId),
             cancellationToken).ConfigureAwait(false);
            if (subSectionProductExistance != null)
                throw new ConflictException("The product you are trying to add already exist");


            var subSectionProduct = _mapper.Map<SubSectionProduct>(request);
            _context.SubSectionProducts.Add(subSectionProduct);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(AddDishToSubSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddDishToSubSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var subSection = await _context.SubSections.AsNoTracking()
                .FirstOrDefaultAsync(s => s.SubSectionId == Guid.Parse(request.SubSectionId), cancellationToken)
                .ConfigureAwait(false);
            if (subSection == null)
                throw new NotFoundException(nameof(SubSection), request.SubSectionId);

            var dish = await _context.Dishes.AsNoTracking()
               .FirstOrDefaultAsync(s => s.DishId == Guid.Parse(request.DishId), cancellationToken)
               .ConfigureAwait(false);
            if (dish == null)
                throw new NotFoundException(nameof(Dish), request.DishId);

            var subSectionDishExistance = await _context.SubSectionDishes.AsNoTracking().FirstOrDefaultAsync(s =>
            s.DishId == Guid.Parse(request.DishId) &&
            s.SubSectionId == Guid.Parse(request.SubSectionId),
            cancellationToken).ConfigureAwait(false);
            if (subSectionDishExistance != null)
                throw new ConflictException("The dish you are trying to add already exist");

            var subSectionDish = _mapper.Map<SubSectionDish>(request);
            _context.SubSectionDishes.Add(subSectionDish);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(RemoveProductFromSubSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new RemoveProductFromSubSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var subSectionProduct = await _context.SubSectionProducts.AsNoTracking().FirstOrDefaultAsync(s =>
               s.ProductId == Guid.Parse(request.ProductId) &&
               s.SubSectionId == Guid.Parse(request.SubSectionId),
               cancellationToken).ConfigureAwait(false);
            if (subSectionProduct == null)
                throw new NotFoundException(nameof(SubSectionProduct), "The product to be removed does not exist within menu subSection");

            _context.SubSectionProducts.Remove(subSectionProduct);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(RemoveDishFromSubSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new RemoveDishFromSubSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var subSectionDish = await _context.SubSectionDishes.AsNoTracking().FirstOrDefaultAsync(s =>
               s.DishId == Guid.Parse(request.DishId) &&
               s.SubSectionId == Guid.Parse(request.SubSectionId),
               cancellationToken).ConfigureAwait(false);
            if (subSectionDish == null)
                throw new NotFoundException(nameof(SubSectionDish), "The dish to be removed does not exist within menu subSection");

            _context.SubSectionDishes.Remove(subSectionDish);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}