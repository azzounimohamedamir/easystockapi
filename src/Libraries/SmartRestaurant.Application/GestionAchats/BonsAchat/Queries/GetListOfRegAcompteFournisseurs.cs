using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.GestionAchats.BonsAchat.Queries
{
    public class GetListOfRegAcompteFournisseurs : IRequest<PagedListDto<Reglement_Acompte_BA_Fournisseur>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

    }

    public class GetListOfRegAcompteFournisseursValidator : AbstractValidator<GetListOfRegAcompteFournisseurs>
    {
        public GetListOfRegAcompteFournisseursValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}