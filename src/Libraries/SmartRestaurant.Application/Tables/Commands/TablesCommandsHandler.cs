using System;
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

namespace SmartRestaurant.Application.Tables.Commands
{
    public class TablesCommandsHandler : 
        IRequestHandler<CreateTableCommand, ValidationResult>,
        IRequestHandler<UpdateTableCommand, ValidationResult>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public TablesCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ValidationResult> Handle(CreateTableCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateTableCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var table = await _context.Tables
                .FirstOrDefaultAsync(x => x.ZoneId == request.ZoneId && x.TableNumber == request.TableNumber, cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            if(table!= null)
                throw new InvalidOperationException("There is a table with this number in the database.");
            table = _mapper.Map<Table>(request);
            _context.Tables.Add(table);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<ValidationResult> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTableCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) return result;
            var table = await _context.Tables.FindAsync(request.CmdId).ConfigureAwait(false);
            if (table == null)
                throw new NotFoundException(nameof(Table) , request.CmdId);
            table.ZoneId = request.ZoneId;
            table.TableNumber = request.TableNumber;
            table.Capacity = request.Capacity;
            table.TableState = (TableState) request.TableState;
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;

        }

       
    }
}
