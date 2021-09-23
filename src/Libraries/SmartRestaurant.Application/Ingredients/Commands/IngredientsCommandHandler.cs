using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Ingredients.Commands
{
    public class IngredientsCommandHandler : IRequestHandler<CreateIngredientCommand, Created>,
        IRequestHandler<UpdateIngredientCommand, NoContent>,
        IRequestHandler<DeleteIngredientCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public IngredientsCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateIngredientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var foodBusiness = await _context.FoodBusinesses.FindAsync(request.FoodBusinessId);
            if (foodBusiness == null) throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);
            var ingredient = _mapper.Map<Ingredient>(request);
            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

        public async Task<NoContent> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteIngredientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var ingredient = await _context.Ingredients.FindAsync(request.Id);
            if (ingredient == null) throw new NotFoundException(nameof(Ingredient), request.Id);
            _context.Ingredients.Remove(ingredient);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

        public async Task<NoContent> Handle(UpdateIngredientCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateIngredientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var foodBusiness = await _context.FoodBusinesses.FindAsync(request.FoodBusinessId);
            if (foodBusiness == null) throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);
            var ingredient = _mapper.Map<Ingredient>(request);
            _context.Ingredients.Update(ingredient);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}