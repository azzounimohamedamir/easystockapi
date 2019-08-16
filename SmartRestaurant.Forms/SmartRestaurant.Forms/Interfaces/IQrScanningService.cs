using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Forms.Interfaces
{
    public interface IQrScanningService
    {
        Task<string> ScanAsync();
    }
}
