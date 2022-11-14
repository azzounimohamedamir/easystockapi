using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
namespace SmartRestaurant.Application.Illness.Queries
{
    public class GetIlnessessbyUserQuery :IRequest<PagedListDto<IllnessUserDto>>
        {
            public int Page { get; set; }
            public int PageSize { get; set; }
            public string SearchKey { get; set; }
            public string SortOrder { get; set; }
            public string CurrentFilter { get; set; }
        }
        public class GetIlnessessbyUserQueryValidator : AbstractValidator<GetIlnessessbyUserQuery>
        {
            public GetIlnessessbyUserQueryValidator()
            {
                RuleFor(v => v.PageSize)
                    .LessThanOrEqualTo(100);
            }
        }
    }



