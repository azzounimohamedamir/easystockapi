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
using SmartRestaurant.Application.Menus.Queries;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Application.Stock.Queries.FilterStrategy;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Domain.Enums;

namespace SmartRestaurant.Application.Stock.Queries
{
    public class StockHandlerQueries :
        IRequestHandler<GetStockListQuery, PagedListDto<StockDto>>,
        IRequestHandler<GetCaisseStatsQuery,CaisseDto>,
        IRequestHandler<GetAllStockListQuery, List<StockDto>>,
        IRequestHandler<GetAllCategoriesListQuery, List<CategoryDto>>,

                IRequestHandler<GetProductAttributesByIdCatQuery, List<ProductAttributeDto>>

    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StockHandlerQueries(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

       
        public async Task<PagedListDto<StockDto>> Handle(GetStockListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetStockListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

           

            var filter = StockStrategies.GetFilterStrategy(request.CurrentFilter , request.FilterCriteriaData);
            var query = filter.FetchData(_context.Stocks, request);
            var data = _mapper.Map<List<StockDto>>(query.Data.ToList());
            data.ForEach(item =>
            {
                foreach (var pav in item.ProductAttributeValues)
                {
                    //get prod ATTR VALUE
                    var pavreal= _context.ProductAttributeValues.FirstOrDefault(a=>a.Id==pav.Id);
                    pav.AttributeName = _mapper.Map < ProductAttributeDto > (_context.ProductAttributes.FirstOrDefault(p => p.Id == pavreal.ProductAttributeId)).Name;
                    pav.AttributeValue = _context.AttributeValues.FirstOrDefault(av => av.Id == Guid.Parse(pavreal.Value)).Value;
                }
            });

            if (request.FilterCriteriaData.Count != 0)
            {
                // Create a dictionary to hold filter criteria
                var criteriaDict = request.FilterCriteriaData
                    .ToDictionary(item => item.Attribute, item => item.Value);

                 data= FilterStockList(data, criteriaDict);

   
            }
            return new PagedListDto<StockDto>(query.CurrentPage, query.PageCount, query.PageSize, query.RowCount, data);
        }




        public List<StockDto> FilterStockList(List<StockDto> data, Dictionary<string, string> criteriaDict)
        {
            var filteredData = new List<StockDto>();

            foreach (var stock in data)
            {
                bool allCriteriaMatched = true;

                foreach (var criteria in criteriaDict)
                {
                    bool criteriaMatched = false;

                    foreach (var pav in stock.ProductAttributeValues)
                    {
                        if (pav.AttributeName == criteria.Key && pav.AttributeValue == criteria.Value)
                        {
                            criteriaMatched = true;
                            break; // Exit the inner loop once a match is found
                        }
                    }

                    if (!criteriaMatched)
                    {
                        allCriteriaMatched = false;
                        break; // Exit the middle loop if any criteria is not matched
                    }
                }

                if (allCriteriaMatched)
                {
                    filteredData.Add(stock);
                }
            }

            return filteredData;
        }

        public async Task<List<StockDto>> Handle(GetAllStockListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAllStockListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var query = _context.Stocks.ToList();
            var data = _mapper.Map<List<StockDto>>(query);

            return  data;
        }

        public async Task<List<CategoryDto>> Handle(GetAllCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetAllCategoriesListQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);



            var query = _context.Categories.ToList();
            var data = _mapper.Map<List<CategoryDto>>(query);

            return data;
        }


        public async Task<List<ProductAttributeDto>> Handle(GetProductAttributesByIdCatQuery request, CancellationToken cancellationToken)
        {
            var categoryAttributes = await _context.CategoryAttribute
                       .Include(ca => ca.ProductAttribute)
                       .ThenInclude(pa => pa.AttributeValues)
                       .Where(ca => ca.CategoryId == request.CategoryId)
                       .ToListAsync();

            var result = categoryAttributes.Select(ca => new ProductAttributeDto
            {
                Id = ca.ProductAttributeId,
                Name = ca.ProductAttribute.Name,
                Values = ca.ProductAttribute.AttributeValues.Select(av => new AttributeValueDto
                {
                    Id = av.Id,
                    Value = av.Value
                }).ToList()
            }).ToList();

            return result;
        }


     

        public async Task<CaisseDto> Handle(GetCaisseStatsQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCaisseStatsQueryValidator();
            var result = await validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);
            if (!result.IsValid) throw new ValidationException(result);

            var vcRange = _context.VenteComptoirs.Where(v => v.Date.Date <= request.EndDate.Date && v.Date.Date >= request.StartDate.Date).ToList();
            var facturesRange = _context.Factures.Where(v => v.Date.Date <= request.EndDate.Date && v.Date.Date >= request.StartDate.Date).ToList();
            var blsrange = _context.Bls.Where(v => v.Date.Date <= request.EndDate.Date && v.Date.Date >= request.StartDate.Date).ToList();
            var barange = _context.BonAchats.Where(v => v.Date.Date <= request.EndDate.Date && v.Date.Date >= request.StartDate.Date).ToList();
            var bccrange = _context.BonCommandeClients.Where(v => v.Date.Date <= request.EndDate.Date && v.Date.Date >= request.StartDate.Date).ToList();
            var bcfrange = _context.BonCommandeFournisseurs.Where(v => v.Date.Date <= request.EndDate.Date && v.Date.Date >= request.StartDate.Date).ToList();
            var fprange = _context.factureProformats.Where(v => v.Date.Date <= request.EndDate.Date && v.Date.Date >= request.StartDate.Date).ToList();


            var venteComptoirIds = vcRange.Select(vc => vc.Id).ToList();
            var FacIds = vcRange.Select(fac => fac.Id).ToList();
            var BlsIds = vcRange.Select(bl => bl.Id).ToList();
            var BAIds = barange.Select(ba => ba.Id).ToList();


            CaisseDto CaisseState = new CaisseDto
            {
                TotalQteVendus = (_context.VenteComptoirProducts
            .Where(vp => venteComptoirIds.Contains(vp.VenteComptoirId))
            .Select(q => q.Qte)
            .Sum())
                + (_context.FacProducts.Where(vp => FacIds.Contains(vp.FactureId))
            .Select(q => q.Qte).Sum()) +
                (_context.BlProducts.Where(bl => BlsIds.Contains(bl.BlId))
            .Select(q => q.Qte).Sum()),
                // Bénifice
                BenificeNet = (vcRange.Select(q => q.MontantTotalTTC).Sum())
            + (facturesRange.Select(q => q.MontantTotalTTC).Sum()) +
            (blsrange.Select(q => q.MontantTotalTTC).Sum()) - ((barange.Select(q => q.MontantTotalTTC).Sum()) + (_context.Depenses.Where(v => v.CreatedAt.Date <= request.EndDate.Date && v.CreatedAt.Date >= request.StartDate.Date).Select(q => q.Somme).Sum())),
                // Total Quantity Acheté

                TotalQteAchete = _context.BAProducts.Where(vp => BAIds.Contains(vp.BAId)).Select(q => q.Qte).Sum(),


                // Total Produits Vendus

                TotalProduitsVendus = _context.VenteComptoirProducts.Where(vp => venteComptoirIds.Contains(vp.VenteComptoirId)).Distinct().Count()
            + _context.FacProducts.Distinct().Count() +
            _context.BlProducts.Distinct().Count(),
                //TOTAL REMISE

                MontantTotalRemises = (vcRange.Select(q => q.Remise).Sum())
            + (facturesRange.Select(q => q.Remise).Sum()) +
            (blsrange.Select(q => q.Remise).Sum()),

                MontantTotalDepenses = (_context.Depenses.Where(v => v.CreatedAt.Date <= request.EndDate.Date && v.CreatedAt.Date >= request.StartDate.Date).Select(q => q.Somme).Sum()),

                MontantTotalAvancementsC = (_context.Clients.Select(q => q.TotalAvances).Sum()),
                TotalBa = barange.Count(),
                TotalBca = bcfrange.Count(),
                TotalBcc = bccrange.Count(),
                TotalBl = blsrange.Count(),
                TotalFac = facturesRange.Count(),
                TotalFp = fprange.Count(),
                MontantTotalReglementsC = _context.Reglement_Acompte_Facture_Clients.Where(v => v.Date.Date <= request.EndDate.Date && v.Date.Date >= request.StartDate.Date).Select(r => r.Montant).Sum(),

                MontantTotalVentes = (vcRange.Select(q => q.MontantTotalTTC).Sum())
            + (facturesRange.Select(q => q.MontantTotalTTC).Sum()) +
            (blsrange.Select(q => q.MontantTotalTTC).Sum()),

                MontantTotalAchats = (barange.Select(q => q.MontantTotalTTC).Sum()),
                MontantTotalRegelementsF = 0,
                MontantCaisse = (vcRange.Select(q => q.MontantTotalTTC).Sum())
            + (facturesRange.Select(q => q.MontantTotalTTC).Sum()) +
            (blsrange.Select(q => q.MontantTotalTTC).Sum()),
                MontantTotalAvancementsF = (_context.Fournisseurs.Select(q => q.TotalAvances).Sum()),
                TotalVc = vcRange.Count(),
            };
            // Total Quantity Vendu



            return CaisseState;
        }



    }
}
    