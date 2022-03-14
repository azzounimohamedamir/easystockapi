using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;
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
        private readonly IUserService _userService;

        public IngredientsCommandHandler(IApplicationDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Created> Handle(CreateIngredientCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateIngredientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var userId = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);         
            var ingredient = _mapper.Map<Ingredient>(request);
            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);
                ingredient.Picture = ms.ToArray();
                ingredient.CreatedBy = userId;
                ingredient.CreatedAt = DateTime.Now;
            }

            _context.Ingredients.Add(ingredient);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

        public async Task<NoContent> Handle(DeleteIngredientCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteIngredientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var ingredient = await _context.Ingredients.FindAsync(Guid.Parse(request.Id));
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

            var userId = ChecksHelper.GetUserIdFromToken_ThrowExceptionIfUserIdIsNullOrEmpty(_userService);
            var ingredient = await _context.Ingredients.AsNoTracking().FirstOrDefaultAsync(r => r.IngredientId == Guid.Parse(request.Id), cancellationToken).ConfigureAwait(false);
            if (ingredient == null)
                throw new NotFoundException(nameof(Ingredient), request.Id);

            _mapper.Map(request, ingredient);
            using (var ms = new MemoryStream())
            {
                request.Picture.CopyTo(ms);
                ingredient.Picture = ms.ToArray();
                ingredient.LastModifiedBy = userId;
                ingredient.LastModifiedAt = DateTime.Now;
            }

            _context.Ingredients.Update(ingredient);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}