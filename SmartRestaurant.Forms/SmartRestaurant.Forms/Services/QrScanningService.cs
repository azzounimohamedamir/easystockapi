using SmartRestaurant.Forms.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

[assembly: Dependency(typeof(SmartRestaurant.Forms.Services.QrScanningService))]
namespace SmartRestaurant.Forms.Services
{
    public class QrScanningService : IQrScanningService
    {
        public async Task<string> ScanAsync()
        {
            return "";
         }
    }
}
