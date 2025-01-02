using System;
using System.Collections.Generic;
using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Entities;

namespace SmartRestaurant.Application.Menus.Queries
{
    public class GetProductAttributesByIdCatQuery : IRequest<List<ProductAttributeDto>>
    {
        public Guid CategoryId { get; set; }

        public GetProductAttributesByIdCatQuery(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}