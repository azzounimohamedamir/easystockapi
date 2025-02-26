using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Identity.Entities;

namespace SmartRestaurant.Application.AdminArea.Queries
{
#pragma warning disable CS0246 // Le nom de type ou d'espace de noms 'LicenceKeys' est introuvable (vous manque-t-il une directive using ou une référence d'assembly ?)
    public class GetAllLicencesClientsListQuery : IRequest<PagedListDto<LicenceKeys>>
#pragma warning restore CS0246 // Le nom de type ou d'espace de noms 'LicenceKeys' est introuvable (vous manque-t-il une directive using ou une référence d'assembly ?)
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string CurrentFilter { get; set; }

    }

    public class GetAllLicencesClientsListQueryValidator : AbstractValidator<GetAllLicencesClientsListQuery>
    {
        public GetAllLicencesClientsListQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);
        }
    }
}
