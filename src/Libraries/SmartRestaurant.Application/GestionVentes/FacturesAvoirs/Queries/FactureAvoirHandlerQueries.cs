using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.GestionVentes.FacturesAvoirs.Queries.FilterStrategy;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.GestionVentes.FacturesAvoirs.Queries
{
    public class FactureAvoirHandlerQueries :
        IRequestHandler<GetListOfFactureAvoirQuery, PagedListDto<FactureAvoirDto>>



    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public FactureAvoirHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PagedListDto<FactureAvoirDto>> Handle(GetListOfFactureAvoirQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetListOfFactureAvoirQueryValidator();


            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var filter = AvoirStrategies.GetFilterStrategy();
            var query = filter.FetchData(_context.FactureAvoirs, request);


            var data = _mapper.Map<List<FactureAvoirDto>>(query.Data.ToList());



            return new PagedListDto<FactureAvoirDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }





    }
}
