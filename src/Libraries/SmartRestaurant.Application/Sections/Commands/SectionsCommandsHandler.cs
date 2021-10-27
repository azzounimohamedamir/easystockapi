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

namespace SmartRestaurant.Application.Sections.Commands
{
    public class SectionsCommandsHandler :
        IRequestHandler<CreateSectionCommand, Created>,
        IRequestHandler<UpdateSectionCommand, NoContent>,
        IRequestHandler<DeleteSectionCommand, NoContent>,
        IRequestHandler<AddProductToSectionCommand, NoContent>,
        IRequestHandler<AddDishToSectionCommand, NoContent>,
        IRequestHandler<RemoveProductFromSectionCommand, NoContent>,
        IRequestHandler<RemoveDishFromSectionCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public SectionsCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var section = _mapper.Map<Section>(request);
            _context.Sections.Add(section);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var section = await _context.Sections.FindAsync(request.Id).ConfigureAwait(false);
            if (section == null)
                throw new NotFoundException(nameof(Section), request.Id);
            _context.Sections.Remove(section);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var section = await _context.Sections.AsNoTracking()
                .FirstOrDefaultAsync(s => s.SectionId == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (section == null)
                throw new NotFoundException(nameof(Section), request.Id);
            var entity = _mapper.Map<Section>(request);
            _context.Sections.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(AddProductToSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddProductToSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var section = await _context.Sections.AsNoTracking()
                .FirstOrDefaultAsync(s => s.SectionId == Guid.Parse(request.SectionId), cancellationToken)
                .ConfigureAwait(false);
            if (section == null)
                throw new NotFoundException(nameof(Section), request.SectionId);

            var product = await _context.Products.AsNoTracking()
               .FirstOrDefaultAsync(s => s.ProductId == Guid.Parse(request.ProductId), cancellationToken)
               .ConfigureAwait(false);
            if (product == null)
                throw new NotFoundException(nameof(Product), request.ProductId);

            var sectionProduct = _mapper.Map<SectionProduct>(request);
            _context.SectionProducts.Add(sectionProduct);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(AddDishToSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddDishToSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var section = await _context.Sections.AsNoTracking()
                .FirstOrDefaultAsync(s => s.SectionId == Guid.Parse(request.SectionId), cancellationToken)
                .ConfigureAwait(false);
            if (section == null)
                throw new NotFoundException(nameof(Section), request.SectionId);

            var dish = await _context.Dishes.AsNoTracking()
               .FirstOrDefaultAsync(s => s.DishId == Guid.Parse(request.DishId), cancellationToken)
               .ConfigureAwait(false);
            if (dish == null)
                throw new NotFoundException(nameof(Dish), request.DishId);

            var sectionDish = _mapper.Map<SectionDish>(request);
            _context.SectionDishes.Add(sectionDish);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(RemoveProductFromSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new RemoveProductFromSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var sectionProduct = await _context.SectionProducts.AsNoTracking().FirstOrDefaultAsync(s =>
               s.ProductId == Guid.Parse(request.ProductId) &&
               s.SectionId == Guid.Parse(request.SectionId),
               cancellationToken).ConfigureAwait(false);
            if (sectionProduct == null)
                throw new NotFoundException(nameof(SectionProduct), "The product to be removed does not exist within menu section");

            _context.SectionProducts.Remove(sectionProduct);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(RemoveDishFromSectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new RemoveDishFromSectionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var sectionDish = await _context.SectionDishes.AsNoTracking().FirstOrDefaultAsync(s => 
               s.DishId == Guid.Parse(request.DishId) && 
               s.SectionId == Guid.Parse(request.SectionId), 
               cancellationToken).ConfigureAwait(false);
            if (sectionDish == null)
                throw new NotFoundException(nameof(SectionDish), "The dish to be removed does not exist within menu section");

            _context.SectionDishes.Remove(sectionDish);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}