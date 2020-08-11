using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Menus.Commands
{
    public class MenusCommandsHandler :
        IRequestHandler<CreateMenuCommand, ValidationResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public MenusCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ValidationResult> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMenuCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            if (request.MenuState == (int)MenuState.Enabled)
            {
                var menus = await _context.Menus
                    .Where(x => x.FoodBusinessId == request.FoodBusinessId && x.MenuState == MenuState.Enabled)
                    .ToListAsync(cancellationToken: cancellationToken)
                    .ConfigureAwait(false);
                if (menus.Any())
                    foreach (var menu1 in menus)
                        menu1.MenuState = MenuState.Disabled;
            }
            var menu = _mapper.Map<Menu>(request);
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}
