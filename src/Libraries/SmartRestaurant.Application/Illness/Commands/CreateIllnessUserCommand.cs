using FluentValidation;
using SmartRestaurant.Application.Common.Commands;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Common.Tools;
using SmartRestaurant.Application.Common.Validators;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Illness.Commands
{
    public class CreateIllnessUserCommand : CreateCommand
    {
       public  List<string> IllnessIds { get; set; }
      
    }


    public class CreateIllnessUserCommandValidator : AbstractValidator<CreateIllnessUserCommand>
    {
        public CreateIllnessUserCommandValidator()
        {
            RuleForEach(ilness => ilness.IllnessIds)
                 .ChildRules(ilnessid => ilnessid.RuleFor(x => x).NotEmpty().NotEqual(Guid.Empty.ToString())
                     .Must(ValidatorHelper.ValidateGuid).WithMessage("'IllnessId' must be a valid GUID"));
        }
    }
}
