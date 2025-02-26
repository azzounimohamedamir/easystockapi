using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.GestionVentes.VenteParFac.Queries
{
    public class GetListOfRegAcompteClients : IRequest<PagedListDto<Reglement_Acompte_Facture_Client_Dto>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

    }

    public class GetListOfRegAcompteClientsValidator : AbstractValidator<GetListOfRegAcompteClients>
    {
        public GetListOfRegAcompteClientsValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}