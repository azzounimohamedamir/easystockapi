using FluentValidation;
using SmartRestaurant.Resources.Commun.BaseEntity;
using SmartRestaurant.Resources.SharedValidation;

namespace SmartRestaurant.Application.Commun.Specialites.Commands.Update
{
    public class UpdateSpecialityModelValidation:AbstractValidator<IUpdateSpecialityModel>
    {
        public UpdateSpecialityModelValidation()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, BaseResource.Id));

            RuleFor(x => x.Alias)
                .MaximumLength(5)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "5"));

            RuleFor(x => x.Name)                
                .NotEmpty()
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, BaseResource.Name));

            RuleFor(x => x.Name)
                .NotNull()                
                .WithMessage(string.Format(SharedValidationResource.RemoteErrorMessage, BaseResource.Name));

            RuleFor(x => x.Name)
                .MaximumLength(256)
                .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "256"));

            RuleFor(x => x.Description)
               .MaximumLength(380)
               .WithMessage(string.Format(SharedValidationResource.MaxlengthNotValideErrorMessage, "380"));

           

        }
    }
}
