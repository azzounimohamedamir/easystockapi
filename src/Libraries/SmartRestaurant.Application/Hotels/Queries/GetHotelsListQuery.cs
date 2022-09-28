using FluentValidation;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Tools;
using System;
using System.Collections.Generic;

namespace SmartRestaurant.Application.Hotels.Queries
{
    public class GetHotelsListQuery : IRequest<IEnumerable<HotelsDto>>
    {
        public Guid Id { get; set; }
    }
}
