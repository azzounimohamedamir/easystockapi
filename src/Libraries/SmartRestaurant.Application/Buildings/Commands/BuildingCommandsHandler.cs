using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.WebResults;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SmartRestaurant.Application.Buildings.Commands;

using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using System.Data;
using System.Diagnostics;
using System.Linq;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Buildings.Commands
{
    public class BuildingCommandsHandler :
        IRequestHandler<CreateBuildingCommand, Created>,
        IRequestHandler<UpdateBuildingCommand, NoContent>,
        IRequestHandler<DeleteBuildingCommand, NoContent>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BuildingCommandsHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<Created> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
        {
            var BuildingName = await _context.Buildings
           .FirstOrDefaultAsync(u => u.Name.ToUpper() == request.Name.ToUpper(), cancellationToken)
           .ConfigureAwait(false); 
            if (BuildingName != null)
            {
                throw new ConflictException("Building '" + request.Name + "' already exists");
            }
            var validator = new CreateBuildingCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);


            var building = _mapper.Map<Domain.Entities.Building>(request);
           
            _context.Buildings.Add(building);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }
        public async Task<NoContent> Handle(DeleteBuildingCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeleteBuildingCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var building = await _context.Buildings.FindAsync(request.Id).ConfigureAwait(false);
            if (building == null)
                throw new NotFoundException(nameof(Building), request.Id);
            _context.Buildings.Remove(building);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

        public async Task<NoContent> Handle(UpdateBuildingCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBuildingCommandValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var building = await _context.Buildings
                .FirstOrDefaultAsync(b => b.Id == request.Id, cancellationToken)
                .ConfigureAwait(false);
            if (building == null)
                throw new NotFoundException(nameof(Building), request.Id);

            _mapper.Map(request, building);
           
            _context.Buildings.Update(building);
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            return default;
        }

    }
}




