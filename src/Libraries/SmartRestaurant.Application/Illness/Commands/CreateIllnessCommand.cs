using FluentValidation;
using SmartRestaurant.Application.Common.Commands;

namespace SmartRestaurant.Application.Illness.Commands
{
    public class CreateIllnessCommand : CreateCommand
    {
        public string Name { get; set; }
    }


    public class CreateIllnessCommandValidator : AbstractValidator<CreateIllnessCommand>
    {
        public CreateIllnessCommandValidator()
        {
            RuleFor(product => product.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .MaximumLength(200);
        }
    }
}
