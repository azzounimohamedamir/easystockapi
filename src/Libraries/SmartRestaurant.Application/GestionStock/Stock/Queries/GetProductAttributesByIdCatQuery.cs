using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;
using System.Collections.Generic;

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