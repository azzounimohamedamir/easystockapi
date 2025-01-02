using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Domain.Entities;

using SmartRestaurant.Application.GestionEmployees.Employees.Fournisseurs.Queries.FilterStrategy;

namespace SmartRestaurant.Application.GestionEmployees.Employees.Fournisseurs.Queries
{
    public class FournisseurHandlerQueries :
        IRequestHandler<GetFournisseurListQuery, PagedListDto<Fournisseur>>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FournisseurHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PagedListDto<Fournisseur>> Handle(GetFournisseurListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetFournisseurListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var filter = FrStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Fournisseurs, request);

            var data = _mapper.Map<List<Fournisseur>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));

            return new PagedListDto<Fournisseur>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }









    }
}
