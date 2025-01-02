using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Extensions;
using SmartRestaurant.Application.Stock.Queries;
using SmartRestaurant.Domain.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace SmartRestaurant.Application.GestionAchats.BonsAchat.Queries.FilterStrategy
{
    public class FilterBAbyName : IBAFilterStrategy
    {
        public PagedResultBase<Domain.Entities.BonAchats> FetchData(DbSet<Domain.Entities.BonAchats> bon, GetBAListQuery request)
        {

            if(string.IsNullOrEmpty(request.CurrentFilter))
            {
                return bon
               .Include(v => v.BAProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Fournisseur)
               .OrderBy(s => s.Date)
               .GetPaged(request.Page, request.PageSize);
            }
            else
            {
                return bon.Where(bon=>bon.CreatedBy== request.CurrentFilter)
              .Include(v => v.BAProducts).ThenInclude(p => p.SelectedStock).Include(c => c.Fournisseur)
              .OrderBy(s => s.Date)
              .GetPaged(request.Page, request.PageSize);
            }
           
            
        }

        public PagedResultBase<Reglement_Acompte_BA_Fournisseur> FetchRegelementsOfFournisseurByBA(DbSet<Reglement_Acompte_BA_Fournisseur> reg, GetListOfRegAcompteFournisseurByBaIdQuery request)
        {



            return reg.Where(a => a.FournisseurId == request.FournisseurId && a.BAId == request.BaId)
                .OrderByDescending(s => s.Montant)
                .GetPaged(request.Page, request.PageSize);

        }


        public PagedResultBase<Reglement_Acompte_BA_Fournisseur> FetchAllReglementsFr(DbSet<Reglement_Acompte_BA_Fournisseur> reg, GetListOfRegAcompteFournisseurs request)
        {



            return reg
                .Include(c => c.Ba).Include(f => f.Fournisseur)
                .OrderByDescending(s => s.Fournisseur.FullName)
                .GetPaged(request.Page, request.PageSize);

        }




    }
}
