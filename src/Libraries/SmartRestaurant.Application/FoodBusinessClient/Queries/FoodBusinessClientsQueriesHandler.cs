using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace SmartRestaurant.Application.FoodBusinessClient.Queries
{
    public class FoodBusinessClientsQueriesHandler :
        IRequestHandler<GetFoodBusinesClientListQuery, PagedListDto<FoodBusinessClientDto>>,
        IRequestHandler<GetFoodBusinessClientByIdQuery, FoodBusinessClientDto>,
        IRequestHandler<GetFoodBusinessClientByManagerIdQuery, FoodBusinessClientDto>,
        IRequestHandler<GetFoodBusinessClientByEmailQuery, FoodBusinessClientDto>,
        IRequestHandler<GetFoodBusinesClientListByFoodBusinessIdQuery, IEnumerable<FoodBusinessClientDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FoodBusinessClientsQueriesHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PagedListDto<FoodBusinessClientDto>> Handle(GetFoodBusinesClientListQuery request, CancellationToken cancellationToken)
        {
            var query =
                _context.FoodBusinessClients
                    .GetPaged(request.Page, request.PageSize);

            var data = _mapper.Map<List<FoodBusinessClientDto>>(await query.Data.ToListAsync(cancellationToken)
                .ConfigureAwait(false));

            var pagedResult = new PagedListDto<FoodBusinessClientDto>(query.CurrentPage, query.PageCount, query.PageSize,
                query.RowCount, data);
            return pagedResult;
        }

        public async Task<FoodBusinessClientDto> Handle(GetFoodBusinessClientByIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetFoodBusinessClientByIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var query = await _context.FoodBusinessClients.FindAsync(Guid.Parse(request.FoodBusinessClientId)).ConfigureAwait(false);
            if (query == null)
            {
                throw new NotFoundException(nameof(FoodBusinessClient), request.FoodBusinessClientId);
            }
            return _mapper.Map<FoodBusinessClientDto>(query);
        }

        public async Task<FoodBusinessClientDto> Handle(GetFoodBusinessClientByManagerIdQuery request,
           CancellationToken cancellationToken)
        {

            var validator = new GetFoodBusinessClientByManagerIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var query = await _context.FoodBusinessClients.SingleOrDefaultAsync(foodBusinessClient => foodBusinessClient.ManagerId == request.FoodBusinessClientManagerId);
            if (query == null)
            {
                throw new NotFoundException(nameof(FoodBusinessClient), request.FoodBusinessClientManagerId);
            }

            return _mapper.Map<FoodBusinessClientDto>(query);

        }

        public async Task<FoodBusinessClientDto> Handle(GetFoodBusinessClientByEmailQuery request,
           CancellationToken cancellationToken)
        {

            var validator = new GetFoodBusinessClientByEmailQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var query = await _context.FoodBusinessClients.FirstOrDefaultAsync(foodBusinessClient => foodBusinessClient.Email == request.Email);
            if (query == null)
            {
                throw new NotFoundException(nameof(FoodBusinessClient), request.Email);
            }
            return _mapper.Map<FoodBusinessClientDto>(query);

        }

        public async Task<IEnumerable<FoodBusinessClientDto>> Handle(GetFoodBusinesClientListByFoodBusinessIdQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetFoodBusinesClientListByFoodBusinessIdQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var query = await _context.FoodBusinessClients
                .Where(x => x.FoodBusinessId == Guid.Parse(request.FoodBusinessId))
                .ToArrayAsync(cancellationToken)
                .ConfigureAwait(false);
            return _mapper.Map<List<FoodBusinessClientDto>>(query);
        }
    }



}
