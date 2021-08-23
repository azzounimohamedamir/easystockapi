using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class FoodBusinessCommandHandler :
        IRequestHandler<CreateFoodBusinessCommand, Created>,
        IRequestHandler<UpdateFourDigitCodeCommand, NoContent>,
        IRequestHandler<UpdateFoodBusinessCommand, NoContent>,
        IRequestHandler<DeleteFoodBusinessCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;

        public FoodBusinessCommandHandler(IApplicationDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<Created> Handle(CreateFoodBusinessCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new CreateFoodBusinessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var entity = _mapper.Map<Domain.Entities.FoodBusiness>(request);
            _context.FoodBusinesses.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }

        public async Task<NoContent> Handle(DeleteFoodBusinessCommand request,
            CancellationToken cancellationToken)
        {
            var validator = new DeleteFoodBusinessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var entity = await _context.FoodBusinesses.FindAsync(request.Id).ConfigureAwait(false);

            if (entity == null)
                throw new NotFoundException(nameof(FoodBusiness), request.Id);

            _context.FoodBusinesses.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return default;
        }

        public async Task<NoContent> Handle(UpdateFoodBusinessCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.FoodBusinesses.FindAsync(request.Id).ConfigureAwait(false);

            if (entity == null)
                throw new NotFoundException(nameof(FoodBusiness), request.Id);

            var validator = new UpdateFoodBusinessCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            entity = _mapper.Map<Domain.Entities.FoodBusiness>(request);
            _context.FoodBusinesses.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateFourDigitCodeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.FoodBusinesses.FindAsync(request.Id).ConfigureAwait(false);

            if (entity == null)
                throw new NotFoundException(nameof(FoodBusiness), request.Id);

            var validator = new UpdateFourDigitCodeCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            entity = _mapper.Map<Domain.Entities.FoodBusiness>(request);
            entity.FourDigitCode = request.FourDigitCode;
            _context.FoodBusinesses.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}