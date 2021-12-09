using System;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos.BillDtos;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Bills.Queries
{
    public class GetBillByIdQuery : IRequest<BillDto>
    {
        public string Id { get; set; }
    }

    public class GetBillByIdQueryValidator : AbstractValidator<GetBillByIdQuery>
    {
        public GetBillByIdQueryValidator()
        {
            RuleFor(bill => bill.Id)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotEmpty()
              .NotEqual(Guid.Empty.ToString())
              .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}