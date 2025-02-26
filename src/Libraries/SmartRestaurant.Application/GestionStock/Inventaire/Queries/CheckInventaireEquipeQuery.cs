using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.Menus.Queries
{
    public class CheckInventaireEquipeQuery : IRequest<CheckInventoryResultDto>
    {
    }

    public class CheckInventaireEquipeQueryValidator : AbstractValidator<CheckInventaireEquipeQuery>
    {
        public CheckInventaireEquipeQueryValidator()
        {

        }
    }
}