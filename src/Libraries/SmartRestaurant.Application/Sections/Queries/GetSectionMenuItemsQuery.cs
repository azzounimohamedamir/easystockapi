using System;
using FluentValidation;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;
using SmartRestaurant.Application.Common.Tools;

namespace SmartRestaurant.Application.Sections.Queries
{
    public class GetSectionMenuItemsQuery : IPagedListQuery<MenuItemDto>
    {
        public string SectionId { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string SearchKey { get; set; }
    }
    public class GetSectionMenuItemsQueryValidator : AbstractValidator<GetSectionMenuItemsQuery>
    {
        public GetSectionMenuItemsQueryValidator()
        {
            RuleFor(v => v.PageSize)
                .LessThanOrEqualTo(100);

            RuleFor(section => section.SectionId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEqual(Guid.Empty.ToString())
                .Must(ValidatorHelper.ValidateGuid).WithMessage("'{PropertyName}' must be a valid GUID");
        }
    }
}