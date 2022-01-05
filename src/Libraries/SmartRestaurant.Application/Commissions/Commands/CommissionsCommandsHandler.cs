using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.commisiones.Commands;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Identity.Entities;

namespace SmartRestaurant.Application.Commissions.Commands
{
    public class FoodBusinessCommandHandler :
        IRequestHandler<SetFoodBusinessCommissionCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FoodBusinessCommandHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        public async Task<NoContent> Handle(SetFoodBusinessCommissionCommand request, CancellationToken cancellationToken)
        {
            var validator = new SetFoodBusinessCommissionCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var foodBusinesses = await _context.FoodBusinesses.AsNoTracking()
                .FirstOrDefaultAsync(foodBusinesses => foodBusinesses.FoodBusinessId == Guid.Parse(request.FoodBusinessId), cancellationToken)
                .ConfigureAwait(false);
            if (foodBusinesses == null)
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);

            _mapper.Map(request, foodBusinesses);
            _context.FoodBusinesses.Update(foodBusinesses);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}