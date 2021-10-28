using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.SubSections.Queries
{
    public class GetSubSectionMenuItemsQuery : IPagedListQuery<MenuItemDto>
    {
        public string SubSectionId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
    }
    public class GetSubSectionMenuItemsQueryValidator : AbstractValidator<GetSubSectionMenuItemsQuery>
    {
        public GetSubSectionMenuItemsQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);

            RuleFor(section => section.SubSectionId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}