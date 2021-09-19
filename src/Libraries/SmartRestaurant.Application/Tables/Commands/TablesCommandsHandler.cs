using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Tables.Commands
{
    public class TablesCommandsHandler :
        IRequestHandler<CreateTableCommand, Created>,
        IRequestHandler<UpdateTableCommand, NoContent>,
        IRequestHandler<DeleteTableCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TablesCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Created> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTableCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var zone = await _context.Zones
                .FirstOrDefaultAsync(x => x.ZoneId == Guid.Parse(request.ZoneId), cancellationToken)
                .ConfigureAwait(false);
            if (zone == null)
                throw new NotFoundException(nameof(Zone), request.ZoneId);

            var maxTableNumber = _context.Tables
               .Where(x => x.ZoneId == Guid.Parse(request.ZoneId))
               .OrderByDescending(p => p.TableNumber)
               .Select(x => x.TableNumber)
               .FirstOrDefault();
            
            var table = _mapper.Map<Table>(request);
            table.TableNumber = maxTableNumber + 1; 
            _context.Tables.Add(table);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(DeleteTableCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteTableCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var table = await _context.Tables.FindAsync(request.Id).ConfigureAwait(false);
            if (table == null)
                throw new NotFoundException(nameof(Table), request.Id);
            _context.Tables.Remove(table);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTableCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var table = await _context.Tables.AsNoTracking()
                .FirstOrDefaultAsync(t => t.TableId == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (table == null)
                throw new NotFoundException(nameof(Table), request.Id);
            var entity = _mapper.Map<Table>(request);
            _context.Tables.Update(entity);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
    }
}