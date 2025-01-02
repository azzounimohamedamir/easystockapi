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
using SmartRestaurant.Application.Dashboard.Queries;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Application.Stock.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Famille.Queries
{
    public class DashboardHandlerQueries :
        IRequestHandler<GetMonthStatsQuery, MonthStatsDto>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public DashboardHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        public async Task<MonthStatsDto> Handle(GetMonthStatsQuery request, CancellationToken cancellationToken)
        {

            var validator = new GetMonthStatsQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);
            var currentMonth = DateTime.Now.Date.Month;



            var vcRange = _context.VenteComptoirs.Where(v => v.Date.Month == DateTime.Now.Month).ToList();
            var facturesRange = _context.Factures.Where(v => v.Date.Month == DateTime.Now.Month).ToList();
            var blsrange = _context.Bls.Where(v => v.Date.Month == DateTime.Now.Month).ToList();
            var barange = _context.BonAchats.Where(v => v.Date.Month == DateTime.Now.Month).ToList();

          

            var venteComptoirIds = vcRange.Select(vc => vc.Id).ToList();
            var FacIds = facturesRange.Select(fac => fac.Id).ToList();
            var BlsIds = blsrange.Select(bl => bl.Id).ToList();
            var BAIds = barange.Select(ba => ba.Id).ToList();


            var baProductsCurrentMonth = (_context.BAProducts
            .Where(ba => BAIds.Contains(ba.BAId))
            ).ToList().GroupBy(p => p.Designation)
                .Select(g => new ProduitVQteDto
                {
                    Designation = g.Key,
                    TotalQuantity = g.Sum(p => p.Qte)
                }).ToList();





            var vcProductsCurrentMonth = (_context.VenteComptoirProducts
            .Where(vp => venteComptoirIds.Contains(vp.VenteComptoirId))
            ).ToList().GroupBy(p => p.Designation)
                .Select(g => new
                {
                    Designation = g.Key,
                    TotalQuantity = g.Sum(p => p.Qte)
                }).ToList();

            var blProductsCurrentMonth = (_context.BlProducts
            .Where(bl => BlsIds.Contains(bl.BlId))
            ).ToList().GroupBy(p => p.Designation)
                .Select(g => new
                {
                    Designation = g.Key,
                    TotalQuantity = g.Sum(p => p.Qte)
                }).ToList(); ;

            var facProductsCurrentMonth = (_context.FacProducts
            .Where(fac => FacIds.Contains(fac.FactureId))
            ).ToList().GroupBy(p => p.Designation)
                .Select(g => new
                {
                    Designation = g.Key,
                    TotalQuantity = g.Sum(p => p.Qte)
                }).ToList();


            var allProducts = vcProductsCurrentMonth
    .Concat(blProductsCurrentMonth)
    .Concat(facProductsCurrentMonth)
    .GroupBy(p => p.Designation)
    .Select(g => new ProduitVQteDto
    {
        Designation = g.Key,
        TotalQuantity = g.Sum(p => p.TotalQuantity)
    }).ToList();



            







            var top10ProductsV = allProducts
    .OrderByDescending(p => p.TotalQuantity)
    .Take(10)
    .ToList();










            // Grouping and summing by Designation


            // January
            var vcRange1 = _context.VenteComptoirs.Where(v => v.Date.Month == 1).ToList();
            var facturesRange1 = _context.Factures.Where(v => v.Date.Month == 1).ToList();
            var blsrange1 = _context.Bls.Where(v => v.Date.Month == 1).ToList();
            var barange1 = _context.BonAchats.Where(v => v.Date.Month == 1).ToList();
            var bccrange1 = _context.BonCommandeClients.Where(v => v.Date.Month == 1).ToList();
            var bcfrange1 = _context.BonCommandeFournisseurs.Where(v => v.Date.Month == 1).ToList();
            var fprange1 = _context.factureProformats.Where(v => v.Date.Month == 1).ToList();

            // February
            var vcRange2 = _context.VenteComptoirs.Where(v => v.Date.Month == 2).ToList();
            var facturesRange2 = _context.Factures.Where(v => v.Date.Month == 2).ToList();
            var blsrange2 = _context.Bls.Where(v => v.Date.Month == 2).ToList();
            var barange2 = _context.BonAchats.Where(v => v.Date.Month == 2).ToList();
            var bccrange2 = _context.BonCommandeClients.Where(v => v.Date.Month == 2).ToList();
            var bcfrange2 = _context.BonCommandeFournisseurs.Where(v => v.Date.Month == 2).ToList();
            var fprange2 = _context.factureProformats.Where(v => v.Date.Month == 2).ToList();

            // March
            var vcRange3 = _context.VenteComptoirs.Where(v => v.Date.Month == 3).ToList();
            var facturesRange3 = _context.Factures.Where(v => v.Date.Month == 3).ToList();
            var blsrange3 = _context.Bls.Where(v => v.Date.Month == 3).ToList();
            var barange3 = _context.BonAchats.Where(v => v.Date.Month == 3).ToList();
            var bccrange3 = _context.BonCommandeClients.Where(v => v.Date.Month == 3).ToList();
            var bcfrange3 = _context.BonCommandeFournisseurs.Where(v => v.Date.Month == 3).ToList();
            var fprange3 = _context.factureProformats.Where(v => v.Date.Month == 3).ToList();


            // March
            var vcRange4 = _context.VenteComptoirs.Where(v => v.Date.Month == 4).ToList();
            var facturesRange4 = _context.Factures.Where(v => v.Date.Month == 4).ToList();
            var blsrange4 = _context.Bls.Where(v => v.Date.Month == 4).ToList();
            var barange4 = _context.BonAchats.Where(v => v.Date.Month == 4).ToList();
            var bccrange4 = _context.BonCommandeClients.Where(v => v.Date.Month == 4).ToList();
            var bcfrange4 = _context.BonCommandeFournisseurs.Where(v => v.Date.Month == 4).ToList();
            var fprange4 = _context.factureProformats.Where(v => v.Date.Month == 4).ToList();

            // March
            var vcRange5 = _context.VenteComptoirs.Where(v => v.Date.Month == 5).ToList();
            var facturesRange5 = _context.Factures.Where(v => v.Date.Month == 5).ToList();
            var blsrange5 = _context.Bls.Where(v => v.Date.Month == 5).ToList();
            var barange5 = _context.BonAchats.Where(v => v.Date.Month == 5).ToList();
            var bccrange5 = _context.BonCommandeClients.Where(v => v.Date.Month == 5).ToList();
            var bcfrange5 = _context.BonCommandeFournisseurs.Where(v => v.Date.Month == 5).ToList();
            var fprange5 = _context.factureProformats.Where(v => v.Date.Month == 5).ToList();

            // March
            var vcRange6 = _context.VenteComptoirs.Where(v => v.Date.Month == 6).ToList();
            var facturesRange6 = _context.Factures.Where(v => v.Date.Month == 6).ToList();
            var blsrange6 = _context.Bls.Where(v => v.Date.Month == 6).ToList();
            var barange6 = _context.BonAchats.Where(v => v.Date.Month == 6).ToList();
            var bccrange6 = _context.BonCommandeClients.Where(v => v.Date.Month == 6).ToList();
            var bcfrange6 = _context.BonCommandeFournisseurs.Where(v => v.Date.Month == 6).ToList();
            var fprange6 = _context.factureProformats.Where(v => v.Date.Month == 6).ToList();

            // March
            var vcRange7 = _context.VenteComptoirs.Where(v => v.Date.Month == 7).ToList();
            var facturesRange7 = _context.Factures.Where(v => v.Date.Month == 7).ToList();
            var blsrange7 = _context.Bls.Where(v => v.Date.Month == 7).ToList();
            var barange7 = _context.BonAchats.Where(v => v.Date.Month == 7).ToList();
            var bccrange7 = _context.BonCommandeClients.Where(v => v.Date.Month == 7).ToList();
            var bcfrange7 = _context.BonCommandeFournisseurs.Where(v => v.Date.Month == 7).ToList();
            var fprange7 = _context.factureProformats.Where(v => v.Date.Month == 7).ToList();

            // March
            var vcRange8 = _context.VenteComptoirs.Where(v => v.Date.Month == 8).ToList();
            var facturesRange8 = _context.Factures.Where(v => v.Date.Month == 8).ToList();
            var blsrange8 = _context.Bls.Where(v => v.Date.Month == 8).ToList();
            var barange8 = _context.BonAchats.Where(v => v.Date.Month == 8).ToList();
            var bccrange8 = _context.BonCommandeClients.Where(v => v.Date.Month == 8).ToList();
            var bcfrange8 = _context.BonCommandeFournisseurs.Where(v => v.Date.Month == 8).ToList();
            var fprange8 = _context.factureProformats.Where(v => v.Date.Month == 8).ToList();

            // March
            var vcRange9 = _context.VenteComptoirs.Where(v => v.Date.Month == 9).ToList();
            var facturesRange9 = _context.Factures.Where(v => v.Date.Month == 9).ToList();
            var blsrange9 = _context.Bls.Where(v => v.Date.Month == 9).ToList();
            var barange9 = _context.BonAchats.Where(v => v.Date.Month == 9).ToList();
            var bccrange9 = _context.BonCommandeClients.Where(v => v.Date.Month == 9).ToList();
            var bcfrange9 = _context.BonCommandeFournisseurs.Where(v => v.Date.Month == 9).ToList();
            var fprange9 = _context.factureProformats.Where(v => v.Date.Month == 9).ToList();

            // March
            var vcRange10 = _context.VenteComptoirs.Where(v => v.Date.Month == 10).ToList();
            var facturesRange10 = _context.Factures.Where(v => v.Date.Month == 10).ToList();
            var blsrange10 = _context.Bls.Where(v => v.Date.Month == 10).ToList();
            var barange10 = _context.BonAchats.Where(v => v.Date.Month == 10).ToList();
            var bccrange10 = _context.BonCommandeClients.Where(v => v.Date.Month == 10).ToList();
            var bcfrange10 = _context.BonCommandeFournisseurs.Where(v => v.Date.Month == 10).ToList();
            var fprange10 = _context.factureProformats.Where(v => v.Date.Month == 10).ToList();

            // March
            var vcRange11 = _context.VenteComptoirs.Where(v => v.Date.Month == 11).ToList();
            var facturesRange11 = _context.Factures.Where(v => v.Date.Month == 11).ToList();
            var blsrange11 = _context.Bls.Where(v => v.Date.Month == 11).ToList();
            var barange11 = _context.BonAchats.Where(v => v.Date.Month == 11).ToList();
            var bccrange11 = _context.BonCommandeClients.Where(v => v.Date.Month == 11).ToList();
            var bcfrange11 = _context.BonCommandeFournisseurs.Where(v => v.Date.Month == 11).ToList();
            var fprange11 = _context.factureProformats.Where(v => v.Date.Month == 11).ToList();
            // March
            var vcRange12 = _context.VenteComptoirs.Where(v => v.Date.Month == 12).ToList();
            var facturesRange12 = _context.Factures.Where(v => v.Date.Month == 12).ToList();
            var blsrange12 = _context.Bls.Where(v => v.Date.Month == 12).ToList();
            var barange12 = _context.BonAchats.Where(v => v.Date.Month == 12).ToList();
            var bccrange12 = _context.BonCommandeClients.Where(v => v.Date.Month == 12).ToList();
            var bcfrange12 = _context.BonCommandeFournisseurs.Where(v => v.Date.Month == 12).ToList();
            var fprange12 = _context.factureProformats.Where(v => v.Date.Month == 12).ToList();





            //var venteComptoirIds = vcRange.Select(vc => vc.Id).ToList();
            //var FacIds = vcRange.Select(fac => fac.Id).ToList();
            //var BlsIds = vcRange.Select(bl => bl.Id).ToList();
            //var BAIds = barange.Select(ba => ba.Id).ToList();


            MonthStatsDto MonthStats = new MonthStatsDto()
            {
                ProduitsVendus=allProducts,
                ProduitsAchetes= baProductsCurrentMonth,
                Top10ProductsV=top10ProductsV,
                JanuaryVCA = (vcRange1.Select(q => q.MontantTotalTTC).Sum())
            + (facturesRange1.Select(q => q.MontantTotalTTC).Sum()) +
            (blsrange1.Select(q => q.MontantTotalTTC).Sum()),

                FebruaryVCA = (vcRange2.Select(q => q.MontantTotalTTC).Sum())
            + (facturesRange2.Select(q => q.MontantTotalTTC).Sum()) +
            (blsrange2.Select(q => q.MontantTotalTTC).Sum()),

                MarchVCA = (vcRange3.Select(q => q.MontantTotalTTC).Sum())
        + (facturesRange3.Select(q => q.MontantTotalTTC).Sum())
        + (blsrange3.Select(q => q.MontantTotalTTC).Sum()),

                AprilVCA = (vcRange4.Select(q => q.MontantTotalTTC).Sum())
        + (facturesRange4.Select(q => q.MontantTotalTTC).Sum())
        + (blsrange4.Select(q => q.MontantTotalTTC).Sum()),

                MayVCA = (vcRange5.Select(q => q.MontantTotalTTC).Sum())
        + (facturesRange5.Select(q => q.MontantTotalTTC).Sum())
        + (blsrange5.Select(q => q.MontantTotalTTC).Sum()),
                JuneVCA = (vcRange6.Select(q => q.MontantTotalTTC).Sum())
        + (facturesRange6.Select(q => q.MontantTotalTTC).Sum())
        + (blsrange6.Select(q => q.MontantTotalTTC).Sum()),
                JulyVCA = (vcRange7.Select(q => q.MontantTotalTTC).Sum())
        + (facturesRange7.Select(q => q.MontantTotalTTC).Sum())
        + (blsrange7.Select(q => q.MontantTotalTTC).Sum()),
                AugustVCA = (vcRange8.Select(q => q.MontantTotalTTC).Sum())
        + (facturesRange8.Select(q => q.MontantTotalTTC).Sum())
        + (blsrange8.Select(q => q.MontantTotalTTC).Sum()),
                SeptemberVCA = (vcRange9.Select(q => q.MontantTotalTTC).Sum())
        + (facturesRange9.Select(q => q.MontantTotalTTC).Sum())
        + (blsrange9.Select(q => q.MontantTotalTTC).Sum()),
                OctoberVCA = (vcRange10.Select(q => q.MontantTotalTTC).Sum())
        + (facturesRange10.Select(q => q.MontantTotalTTC).Sum())
        + (blsrange10.Select(q => q.MontantTotalTTC).Sum()),
                NovemberVCA = (vcRange11.Select(q => q.MontantTotalTTC).Sum())
        + (facturesRange11.Select(q => q.MontantTotalTTC).Sum())
        + (blsrange11.Select(q => q.MontantTotalTTC).Sum()),
                DecemberVCA = (vcRange12.Select(q => q.MontantTotalTTC).Sum())
        + (facturesRange12.Select(q => q.MontantTotalTTC).Sum())
        + (blsrange12.Select(q => q.MontantTotalTTC).Sum()),

                JanuaryACA = (barange1.Select(q => q.MontantTotalTTC).Sum()),
          

                FebruaryACA = (barange2.Select(q => q.MontantTotalTTC).Sum()),
           

                MarchACA = (barange3.Select(q => q.MontantTotalTTC).Sum())
      ,

                AprilACA = (barange4.Select(q => q.MontantTotalTTC).Sum())
        ,

                MayACA = (barange5.Select(q => q.MontantTotalTTC).Sum())
       ,
                JuneACA = (barange6.Select(q => q.MontantTotalTTC).Sum())
        ,
                JulyACA = (barange7.Select(q => q.MontantTotalTTC).Sum())
        ,
                AugustACA = (barange8.Select(q => q.MontantTotalTTC).Sum())
        ,
                SeptemberACA = (barange9.Select(q => q.MontantTotalTTC).Sum())
        ,
                OctoberACA = (barange10.Select(q => q.MontantTotalTTC).Sum())
        ,
                NovemberACA = (barange11.Select(q => q.MontantTotalTTC).Sum())
        ,
                DecemberACA = (barange12.Select(q => q.MontantTotalTTC).Sum())
       ,











            };
            // Total Quantity Vendu



            return MonthStats;
        }

       
            }
        }
    