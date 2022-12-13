using System;
using MediatR;
using System.Collections.Generic;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Common.Interfaces;

namespace SmartRestaurant.Application.SubSections.Queries
{
    public class GetAllSubSectionsListQuery : IRequest<List<SubSectionDto>>
    {
        public string FoodBusinessId { get; set; }
    }
}