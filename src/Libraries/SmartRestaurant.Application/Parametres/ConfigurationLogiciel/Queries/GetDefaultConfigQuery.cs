using FluentValidation;
using MediatR;

namespace SmartRestaurant.Application.Parametres.ConfigurationLogiciel.Queries
{
    public class GetDefaultConfigQuery : IRequest<Domain.Entities.DefaultConfigLog>
    {
    }

    public class GetDefaultConfigQueryValidator : AbstractValidator<GetDefaultConfigQuery>
    {
        public GetDefaultConfigQueryValidator()
        {

        }
    }
}