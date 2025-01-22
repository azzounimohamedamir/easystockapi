using MediatR;
using SmartRestaurant.Application.Common.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.GestionStock.Stock.Queries
{
   
    public class GetProductByCodebarQuery : IRequest<StockDto>
    {
        public string CodeBar { get; set; }
    }
}
