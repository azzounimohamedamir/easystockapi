using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.GestionVentes.Caisses.Queries;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Exceptions;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.GestionVentes.Caisses.Queries.FilterStrategy;
using SmartRestaurant.Application.GestionVentes.VenteComptoir.Queries.FilterStrategy;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Application.Stock.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.Identity.Entities;
using SmartRestaurant.Domain.Identity.Enums;

namespace SmartRestaurant.Application.GestionVentes.Caisses.Queries
{
    public class CaissesHandlerQueries :
        IRequestHandler<GetCaissesListQuery, PagedListDto<Domain.Entities.Caisses>>,
                IRequestHandler<GetAllCaissiersListQuery, List<ApplicationUser>>


    {
        private readonly IApplicationDbContext _context;
        private readonly IIdentityContext _identitycontext;
        private readonly IMapper _mapper;

        public CaissesHandlerQueries(IApplicationDbContext context,IIdentityContext identitycontext, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _identitycontext = identitycontext;
        }

       
        public async Task<PagedListDto<Domain.Entities.Caisses>> Handle(GetCaissesListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCaissesListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

           

            var filter = CaisseStrategies.GetFilterStrategy(request.CurrentFilter);
            var query = filter.FetchData(_context.Caisses, request);


            foreach(var item in query.Data)
            {
                var vcRangeJ = _context.VenteComptoirs.Where(v => v.Date.Date == DateTime.Now.Date && v.Caisse==item.Numero).ToList();
                var facturesRangeJ = _context.Factures.Where(v => v.Date.Date == DateTime.Now.Date && v.Caisse == item.Numero).ToList();
                var blsrangeJ = _context.Bls.Where(v => v.Date.Date == DateTime.Now.Date && v.Caisse == item.Numero).ToList();

                var vcRangeM = _context.VenteComptoirs.Where(v => v.Date.Date.Month == DateTime.Now.Date.Month && v.Caisse == item.Numero).ToList();
                var facturesRangeM = _context.Factures.Where(v => v.Date.Date.Month == DateTime.Now.Date.Month && v.Caisse == item.Numero).ToList();
                var blsrangeM= _context.Bls.Where(v => v.Date.Date.Month == DateTime.Now.Date.Month && v.Caisse == item.Numero).ToList();
                item.SoldeJ = (vcRangeJ.Select(q => q.MontantTotalTTC).Sum())+ (facturesRangeJ.Select(q => q.MontantTotalTTC).Sum())                      +(blsrangeJ.Select(q => q.MontantTotalTTC).Sum());
                item.SoldeM = (vcRangeM.Select(q => q.MontantTotalTTC).Sum())+ (facturesRangeM.Select(q => q.MontantTotalTTC).Sum()) +
                              (blsrangeM.Select(q => q.MontantTotalTTC).Sum());
            }



            var data = _mapper.Map<List<Domain.Entities.Caisses>>(await query.Data.ToListAsync(cancellationToken).ConfigureAwait(false));
                
            return new PagedListDto<Domain.Entities.Caisses>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }

        public async Task<List<ApplicationUser>> Handle(GetAllCaissiersListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAllCaissiersListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var caissiers = _identitycontext.ApplicationUser.Where(a => a.UserRoles.Any(r => r.Role.Name == Roles.Caissier.ToString())).ToList();



            return caissiers;
        }


    }
        }
    