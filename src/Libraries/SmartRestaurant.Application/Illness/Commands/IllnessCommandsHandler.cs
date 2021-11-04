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

namespace SmartRestaurant.Application.Illness.Commands
{
    public class IllnessCommandsHandler :
        IRequestHandler<CreateIllnessCommand, Created>,
        IRequestHandler<AddIngredientToIllnessCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public IllnessCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateIllnessCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateIllnessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var illness = _mapper.Map<Domain.Entities.Illness>(request);
            _context.Illnesses.Add(illness);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(AddIngredientToIllnessCommand request, CancellationToken cancellationToken)
        {
            var validator = new AddIngredientToIllnessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var illness = await _context.Illnesses.AsNoTracking()
                .FirstOrDefaultAsync(s => s.IllnessId == Guid.Parse(request.IllnessId), cancellationToken)
                .ConfigureAwait(false);
            if (illness == null)
                throw new NotFoundException(nameof(illness), request.IllnessId);

            var Ingredient = await _context.Ingredients.AsNoTracking()
               .FirstOrDefaultAsync(s => s.IngredientId == Guid.Parse(request.IngredientId), cancellationToken)
               .ConfigureAwait(false);
            if (Ingredient == null)
                throw new NotFoundException(nameof(Ingredient), request.IngredientId);

            var ingredientIllnessExistance = await _context.IngredientIllnesses.AsNoTracking().FirstOrDefaultAsync(s =>
             s.IngredientId == Guid.Parse(request.IngredientId) &&
             s.IllnessId == Guid.Parse(request.IllnessId),
             cancellationToken).ConfigureAwait(false);
            if (ingredientIllnessExistance != null)
                throw new ConflictException("The Ingredient you are trying to add already exist");


            var ingredientIllness = _mapper.Map<IngredientIllness>(request);
            _context.IngredientIllnesses.Add(ingredientIllness);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}
