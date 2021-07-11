using System;
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

namespace SmartRestaurant.Application.Menus.Commands
{
    public class MenusCommandsHandler :
        IRequestHandler<CreateMenuCommand, ValidationResult>,
        IRequestHandler<UpdateMenuCommand, ValidationResult>,
        IRequestHandler<DeleteMenuCommand, ValidationResult>
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
            await UpdateMenuStateAsync(request.MenuState, request.FoodBusinessId, request.CmdId, cancellationToken)
                .ConfigureAwait(false);
            var menu = _mapper.Map<Menu>(request);
            _context.Menus.Add(menu);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<ValidationResult> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteMenuCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;

            var menu = await _context.Menus.FindAsync(request.CmdId).ConfigureAwait(false);
            if (menu == null)
                throw new NotFoundException(nameof(Menu), request.CmdId);
            _context.Menus.Remove(menu);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<ValidationResult> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMenuCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var menu = await _context.Menus.AsNoTracking()
                .FirstOrDefaultAsync(m => m.MenuId == request.CmdId, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            if (menu == null)
                throw new NotFoundException(nameof(Menu), request.CmdId);
            await UpdateMenuStateAsync(request.MenuState, request.FoodBusinessId, request.CmdId, cancellationToken)
                .ConfigureAwait(false);
            var entity = _mapper.Map<Menu>(request);
            _context.Menus.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        private async Task UpdateMenuStateAsync(int state, Guid foodBusinessId, Guid? menuId,
            CancellationToken cancellationToken)
        {
            if (state != (int) MenuState.Enabled) return;
            var menus = await _context.Menus
                .Where(x => x.FoodBusinessId == foodBusinessId
                            && x.MenuId != menuId
                            && x.MenuState == MenuState.Enabled)
                .ToListAsync(cancellationToken)
                .ConfigureAwait(false);
            if (menus.Any())
                foreach (var menu in menus)
                    menu.MenuState = MenuState.Disabled;
        }
    }
}