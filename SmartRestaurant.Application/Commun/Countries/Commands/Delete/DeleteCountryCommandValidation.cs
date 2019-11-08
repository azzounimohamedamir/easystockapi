using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

public class DeleteCountryCommandValidation : AbstractValidator<IDeleteCountryModel>
{
    public DeleteCountryCommandValidation()
    {
        RuleFor(x => x.Id)
             .NotEmpty()
             .WithMessage(string.Format(SharedValidationResource.RequiredErrorMessage,
             BaseResource.Id));
    }
}