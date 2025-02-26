using FluentValidation;
using MediatR;

namespace SmartRestaurant.Application.Parametres.SocieteInfo.Queries
{
    public class GetSocieteInfoQuery : IRequest<Domain.Entities.SocieteInfo>
    {
    }

    public class GetSocieteInfoQueryValidator : AbstractValidator<GetSocieteInfoQuery>
    {
        public GetSocieteInfoQueryValidator()
        {

        }
    }
}