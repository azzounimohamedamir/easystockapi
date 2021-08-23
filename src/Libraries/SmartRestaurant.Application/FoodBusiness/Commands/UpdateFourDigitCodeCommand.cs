using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.FoodBusiness.Commands
{
    public class UpdateFourDigitCodeCommand : UpdateCommand
    {
        public string FourDigitCode { get; set; }
        
    }


    public class UpdateFourDigitCodeCommandValidator : AbstractValidator<UpdateFourDigitCodeCommand>
    {
        public UpdateFourDigitCodeCommandValidator()
        {
            RuleFor(v => v.FourDigitCode).MaximumLength(4).MinimumLength(4).NotEmpty();
        }
    }
}