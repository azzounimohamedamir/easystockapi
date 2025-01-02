using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Queries;
using SmartRestaurant.Application.GestionVentes.VenteParFac.Queries.FilterStrategy;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.GestionVentes.VenteParBl.Queries.FilterStrategy
{
    public class FilterFacByName : IFacFilterStrategy
    {
        public PagedResultBase<Facture> FetchData(DbSet<Facture> fac, GetFacturesListQuery request)
        {



            //return fac
            //    .Include(v => v.FacProducts).ThenInclude(p => p.SelectedStock).Include(c=>c.Client)
            //    //.Include(v => v.FactureAvoirs).ThenInclude(m => m.MotifsAvoir)
            //    //.Include(v => v.FactureAvoirs).ThenInclude(m => m.ProduitsAjouterAuStock)
            //    //.Include(v => v.FactureAvoirs).ThenInclude(m => m.ProduitsRetournes)
            //    .Include(c=>c.Client)
            //    .OrderByDescendingDescending(s => s.Date)
            //    .GetPaged(request.Page, request.PageSize);

            if (request.Caisse == 0 && string.IsNullOrEmpty(request.CurrentFilter))
            {
                return fac

               .Include(v => v.FacProducts).ThenInclude(p => p.SelectedStock).Include(c=>c.Client)
               .OrderByDescending(s => s.Date)

                      .GetPaged(request.Page, request.PageSize);
            }
            else if (request.Caisse != 0 && request.CurrentFilter == null)
            {
                return fac.Where(v => v.Caisse == request.Caisse)
             .Include(v => v.FacProducts).ThenInclude(p => p.SelectedStock).Include(c=>c.Client)
             .OrderByDescending(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }
            else if (request.Caisse != 0 && !string.IsNullOrEmpty(request.CurrentFilter))
            {
                return fac.Where(v => v.Caisse == request.Caisse && v.NomCaissier.Contains(request.CurrentFilter))
             .Include(v => v.FacProducts).ThenInclude(p => p.SelectedStock).Include(c=>c.Client)
             .OrderByDescending(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }
            else if (request.Caisse == 0 && !string.IsNullOrEmpty(request.CurrentFilter))
            {
                return fac.Where(v => v.NomCaissier.Contains(request.CurrentFilter))
             .Include(v => v.FacProducts).ThenInclude(p => p.SelectedStock).Include(c=>c.Client)
             .OrderByDescending(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }
            else if (request.Caisse == 0 && string.IsNullOrEmpty(request.CurrentFilter))
            {
                return fac.Where(v => v.Caisse == request.Caisse)
             .Include(v => v.FacProducts).ThenInclude(p => p.SelectedStock).Include(c=>c.Client)
             .OrderByDescending(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }
            else
            {
                return fac
             .Include(v => v.FacProducts).ThenInclude(p => p.SelectedStock).Include(c=>c.Client)
             .OrderByDescending(s => s.Date)
             .GetPaged(request.Page, request.PageSize);
            }

        }

        public PagedResultBase<Reglement_Acompte_Facture_Client> FetchRegelementsOfClientByFacture(DbSet<Reglement_Acompte_Facture_Client> reg, GetListOfRegAcompteClientByFactureIdQuery request)
        {



            return reg.Where(a=>a.ClientId==request.ClientId && a.FactureId==request.FactureId)
                .OrderByDescending(s => s.Montant)
                .GetPaged(request.Page, request.PageSize);

        }


        public PagedResultBase<Reglement_Acompte_Facture_Client> FetchAllReglements(DbSet<Reglement_Acompte_Facture_Client> reg, GetListOfRegAcompteClients request)
        {



            return reg
                .Include(c => c.Facture).Include(f=>f.Client)
                .OrderByDescending(s =>s.Client.FullName)
                .GetPaged(request.Page, request.PageSize);

        }



    }
}
