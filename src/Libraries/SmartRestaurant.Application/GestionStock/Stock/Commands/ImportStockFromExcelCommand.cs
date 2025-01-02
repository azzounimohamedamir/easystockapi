using MediatR;
using SmartRestaurant.Application.Common.WebResults;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Stock.Commands
{
    public class ImportStockFromExcelCommand :IRequest
    {
       public byte[] ExcelFileData { get; set; }
    }
}
