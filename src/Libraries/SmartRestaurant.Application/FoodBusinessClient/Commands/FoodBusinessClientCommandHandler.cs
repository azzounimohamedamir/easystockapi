using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Identity.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.FoodBusinessClient.Commands
{
    public class FoodBusinessClientCommandHandler :
        IRequestHandler<CreateFoodBusinessClientCommand, Created>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        public FoodBusinessClientCommandHandler(IApplicationDbContext context, IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<Created> Handle(CreateFoodBusinessClientCommand request,
           CancellationToken cancellationToken)
        {
            var validator = new CreateFoodBusinessClientCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var user = await _userManager.FindByIdAsync(request.ManagerId).ConfigureAwait(false);
            if (user == null)
                throw new NotFoundException(nameof(ApplicationUser), request.ManagerId);

            var entity = _mapper.Map<Domain.Entities.FoodBusinessClient>(request);
            _context.FoodBusinessClients.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return default;
        }
    }
}
