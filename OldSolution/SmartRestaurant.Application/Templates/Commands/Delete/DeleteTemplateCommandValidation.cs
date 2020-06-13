using FluentValidation;

namespace SmartRestaurant.Application.Templates.Commands.Delete
{
    internal class DeleteTemplateCommandValidation : AbstractValidator<IDeleteTemplateModel>
    {
        public DeleteTemplateCommandValidation()
        {
        }
    }
}