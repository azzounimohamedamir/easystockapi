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
using SmartRestaurant.Application.Depenses.Queries.FilterStrategy;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Application.Stock.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Depenses.Queries
{
    public class DepenseHandlerQueries :
        IRequestHandler<GetDepensesListQuery, PagedListDto<Depense>>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DepenseHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        public async Task<PagedListDto<Depense>> Handle(GetDepensesListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetDepensesListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

           

            var filter = DepenseStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Depenses, request);

            var data = _mapper.Map<List<Depense>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<Depense>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

       
            }
        }
    