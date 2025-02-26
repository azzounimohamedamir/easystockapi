using MediatR;
using SmartRestaurant.Application.Common.Dtos;

namespace SmartRestaurant.Application.GestionStock.Stock.Queries
{

    public class GetProductByCodebarQuery : IRequest<StockDto>
    {
        public string CodeBar { get; set; }
    }
}
