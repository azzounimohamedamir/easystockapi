using MediatR;

namespace SmartRestaurant.Application.Stock.Commands
{
    public class ImportStockFromExcelCommand : IRequest
    {
        public byte[] ExcelFileData { get; set; }
    }
}
