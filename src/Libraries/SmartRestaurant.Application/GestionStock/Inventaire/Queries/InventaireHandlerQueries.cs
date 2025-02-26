using AutoMapper;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.GestionStock.Inventaire.Queries.FilterStrategy;
using SmartRestaurant.Application.Menus.Queries;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.GestionStock.Inventaire.Queries
{
    public class InventaireHandlerQueries :
        //   IRequestHandler<GetInventoryValidatedListQuery, PagedListDto<InventaireDto>>,
        IRequestHandler<CheckInventaireEquipeQuery, CheckInventoryResultDto>,
        IRequestHandler<GetInventoryLignesFinalListQuery, PagedListDto<LignesInventaireFinalDto>>,
        IRequestHandler<GetInventoryValidatedListQuery, PagedListDto<InventaireDto>>


    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public InventaireHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<PagedListDto<LignesInventaireFinalDto>> Handle(GetInventoryLignesFinalListQuery request, CancellationToken cancellationToken)
        {




            var validator = new GetInventoryLignesFinalListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);





            var filter = InvStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchLignesFinal(_context.LignesInventaireFinals, request);
            var data = _mapper.Map<List<LignesInventaireFinalDto>>(query.Data.ToList());

            return new PagedListDto<LignesInventaireFinalDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }


        public async Task<PagedListDto<InventaireDto>> Handle(GetInventoryValidatedListQuery request, CancellationToken cancellationToken)
        {




            var validator = new GetInventoryValidatedListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);





            var filter = InvStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Inventaires, request);
            var data = _mapper.Map<List<InventaireDto>>(query.Data.ToList());

            return new PagedListDto<InventaireDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }


        public async Task<CheckInventoryResultDto> Handle(CheckInventaireEquipeQuery request, CancellationToken cancellationToken)
        {
            var validator = new CheckInventaireEquipeQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var equipeColumn = _context.InventaireEquipes.Select(item => item.Equipe).ToList();
            var inventoryfisnished = _context.Inventaires.Count() == 1 ? true : false;

            CheckInventoryResultDto check = new CheckInventoryResultDto
            {
                EquipesFinished = equipeColumn,
                InventaireFinished = inventoryfisnished
            };



            return check;
        }


    }
}
