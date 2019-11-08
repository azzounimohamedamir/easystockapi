using GalaSoft.MvvmLight.Command;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Restaurants.Tables.Queries.GetById;
using SmartRestaurant.Forms.Interfaces;
using SmartRestaurant.Forms.Models;
using SmartRestaurant.Forms.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartRestaurant.Forms.ViewModels
{
    public class EnterViewModel : BaseViewModel
    {
        private readonly IAPIService iAPIService;
        private readonly IQrScanningService qrScanning;

        public EnterViewModel(IAPIService iAPIService, IQrScanningService qrScanning)
        {
            this.iAPIService = iAPIService;
            this.qrScanning = qrScanning;
            ScanQrCommand = new RelayCommand(ScanQrCommand_Ex);
            Refrech();
        }

        private async void ScanQrCommand_Ex()
        {
            try
            {

                var result = await qrScanning.ScanAsync();
                if (result != null)
                {
                    QrValue = result;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<LanguageCulture>> GetLaguagesAsync()
        {
            return Languages = await iAPIService.GetLanguagesAsync();

        }

        public async void Refrech()
        {
            Tables = await iAPIService.GetRestaurantTablesAsync("");
        }

        public LanguageCulture SelectedLanguage { get; set; }
        public string SelectedChair { get; set; }
        public TableItemModel SelectedTable { get; set; }

        public List<TableItemModel> Tables { get; set; }
        public List<LanguageCulture> Languages { get; set; }
      
        private LanguageCulture _selecteditem;

        public LanguageCulture selecteditem
        {
            get { return _selecteditem; }

            set { _selecteditem = value;
              

            }


        }

        public RelayCommand ScanQrCommand { get; set; }
        public string QrValue { get; set; }

    }
}
