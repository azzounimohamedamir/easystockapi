using System;
using MediatR;
using System.Collections.Generic;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.Sections.Queries
{
    public class GetAllSectionsListQuery : IRequest<List<SectionDto>>
    {
        public string FoodBusinessId { get; set; }

    }
}