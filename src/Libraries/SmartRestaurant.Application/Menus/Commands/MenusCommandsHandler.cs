using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation.Results;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.Menus.Commands
{
    public class MenusCommandsHandler :
        IRequestHandler<CreateMenuCommand , ValidationResult>,
        IRequestHandler<UpdateMenuCommand, ValidationResult>,
        IRequestHandler<DeleteMenuCommand>
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
            await UpdateMenuStateAsync(request.MenuState, request.FoodBusinessId, request.CmdId,cancellationToken).ConfigureAwait(false);
            var menu = _mapper.Map<Menu>(request);
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<ValidationResult> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMenuCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var menu = await _context.Menus.FindAsync(request.CmdId).ConfigureAwait(false);
            if(menu==null)
                throw new NotFoundException(nameof(Menu), request.CmdId);
            await UpdateMenuStateAsync(request.MenuState, request.FoodBusinessId, request.CmdId, cancellationToken).ConfigureAwait(false);
            menu.MenuState =(MenuState) request.MenuState;
            menu.Name = request.Name;
            menu.FoodBusinessId = menu.FoodBusinessId;
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<Unit> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await _context.Menus.FindAsync(request.MenuId).ConfigureAwait(false);
            if (menu == null)
                throw new NotFoundException(nameof(Menu), request.MenuId);
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return Unit.Value;
        }

        private async Task UpdateMenuStateAsync(int state, Guid foodBusinessId, Guid? menuId, CancellationToken cancellationToken)
        {
            if (state != (int) MenuState.Enabled) return;
            var menus = await _context.Menus
                .Where(x => x.FoodBusinessId == foodBusinessId
                            && x.MenuId != menuId
                            && x.MenuState == MenuState.Enabled)
                .ToListAsync(cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            if (menus.Any())
                foreach (var menu in menus)
                    menu.MenuState = MenuState.Disabled;

        }
    }
}
