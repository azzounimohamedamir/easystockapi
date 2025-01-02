using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionAchats.BonsAchat.Queries
{
    public class GetListOfRegAcompteFournisseurByBaIdQuery : IRequest<PagedListDto<Reglement_Acompte_BA_Fournisseur>>
    {
        public Guid FournisseurId { get; set; }
        public Guid BaId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
       
    }

    public class GetListOfRegAcompteFournisseurByBaIdQueryValidator : AbstractValidator<GetListOfRegAcompteFournisseurByBaIdQuery>
    {
        public GetListOfRegAcompteFournisseurByBaIdQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}