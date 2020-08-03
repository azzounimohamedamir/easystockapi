using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.FoodBusiness.Queries
{
    public class FoodBusinessQueriesHandler :
        IRequestHandler<GetFoodBusinessListQuery, List<FoodBusinessDto>>, 
        IRequestHandler<GetFoodBusinessByIdQuery, FoodBusinessDto>,
        IRequestHandler<GetFoodBusinessListByAdmin, List<FoodBusinessDto>>,
        IRequestHandler<GetImagesByFoodBusinessIdQuery, IEnumerable<Byte[]>>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FoodBusinessQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<FoodBusinessDto>> Handle(GetFoodBusinessListQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.FoodBusiness> entities = await _context.FoodBusinesses.ToListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
            return _mapper.Map<List<FoodBusinessDto>>(entities);
        }

        public async Task<FoodBusinessDto> Handle(GetFoodBusinessByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.FoodBusinesses.FindAsync(request.FoodBusinessId).ConfigureAwait(false);

            if (entity == null)
            {
                throw new NotFoundException(nameof(FoodBusiness), request.FoodBusinessId);
            }
            return _mapper.Map<FoodBusinessDto>(entity);
        }

        public async Task<List<FoodBusinessDto>> Handle(GetFoodBusinessListByAdmin request, CancellationToken cancellationToken)
        {
            if (request.FoodBusinessAdministratorId == String.Empty || string.IsNullOrWhiteSpace(request.FoodBusinessAdministratorId))
                throw new InvalidOperationException("FoodBusinessAdministratorId shouldn't be null or  empty");

            List<Domain.Entities.FoodBusiness> foodBusinesses = await _context.FoodBusinesses
                .Where(x=>x.FoodBusinessAdministratorId == request.FoodBusinessAdministratorId).ToListAsync(cancellationToken: cancellationToken)
                .ConfigureAwait(false);
            return _mapper.Map<List<FoodBusinessDto>>(foodBusinesses);
        }

        public async Task<IEnumerable<byte[]>> Handle(GetImagesByFoodBusinessIdQuery request, CancellationToken cancellationToken)
        {
            if(request.FoodBusinessId == Guid.Empty)
                throw new InvalidOperationException("FoodBusiness Id shouldn't be null or  empty");
            return await _context.FoodBusinessImages.Where(f => f.FoodBusinessId == request.FoodBusinessId)
                .Select(im => im.ImageBytes).ToArrayAsync(cancellationToken: cancellationToken).ConfigureAwait(false);

        }
    }
}
