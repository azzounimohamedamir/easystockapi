using GalaSoft.MvvmLight.Ioc;
using SmartRestaurant.Forms.Interfaces;
using SmartRestaurant.Forms.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SmartRestaurant.Forms.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<IAPIService, FakeAPIService>();
            SimpleIoc.Default.Register<ILoginService, LoginService>();
            SimpleIoc.Default.Register<IQrScanningService, QrScanningService>();
      
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<ServiceViewModel>();
            SimpleIoc.Default.Register<EnterViewModel>();
        }

        public MainViewModel Main => SimpleIoc.Default.GetInstance<MainViewModel>();
        public ServiceViewModel Service  => SimpleIoc.Default.GetInstance<ServiceViewModel>();
        public EnterViewModel Enter  => SimpleIoc.Default.GetInstance<EnterViewModel>();
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
