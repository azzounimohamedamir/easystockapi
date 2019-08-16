using GalaSoft.MvvmLight.Command;

using SmartRestaurant.Forms.Interfaces;
using SmartRestaurant.Forms.Pages;
using SmartRestaurant.Resources.Xamarin.Client;
using SmartRestaurant.Views.Login;
using SmartRestaurant.Views.SignUp;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using static SmartRestaurant.Forms.Services.LoginService;

namespace SmartRestaurant.Forms.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        public RelayCommand RegisterCommand { get; set; }
        public RelayCommand LogInCommand { get; set; }
        public Page DishPage { get; set; }

        ILoginService loginService;

        public Page page { get; set; }

        public Page FirstPage { get; set; }

        public MainViewModel(ILoginService loginService)
        {
            this.loginService = loginService;

            RegisterCommand = new RelayCommand(RegisterCommand_Ex);
            LogInCommand = new RelayCommand(LogInCommand_Ex);
            RefreshMenuItems();

        }

        public void RefreshMenuItems()
        {
            MenuItems = new ObservableCollection<MenuList>()
            {
                new MenuList {Title = UIRes.WAITERTxt , PageName ="Waiters",IconUrl = "Waiters.png" , TargetType = typeof(WaiterPage)}
               ,new MenuList {Title = UIRes.CHEFTxt ,PageName ="Cheffs" , IconUrl = "chef.png", TargetType = typeof(ChefPage)}
               ,new MenuList {Title = UIRes.ASKFORACHAIRTxt , PageName ="Ask Chairs" , IconUrl = "Chair.png", TargetType = typeof(AskForChairPage)}
               ,new MenuList {Title = UIRes.ALLEGRIESTxt  ,PageName ="ALLEGRIES" , IconUrl = "Allergic.png" , TargetType = typeof(AllergiesPage)}
               ,new MenuList {Title = UIRes.ILLNESSESTxt ,PageName ="ILLNESSES" , IconUrl = "Illnesses.png" , TargetType = typeof(IllnessesPage)}
               ,new MenuList {Title = UIRes.TodayMenuTxt ,PageName ="TodaysMenu" , IconUrl = "img1.png" , TargetType = typeof(ServicesPage)}
               ,new MenuList {Title = UIRes.ChangeLanguageTxt ,PageName ="TodaysMenu" , IconUrl = "img1.png" , TargetType = typeof(EnterPage),IsMainPage=true}
            };
        }

        private async void LogInCommand_Ex()
        {

        }

        private async void RegisterCommand_Ex()
        {
            //var id = await loginService.RegisterAsync(new CreateUserModel
            //{
            //    Email = "test@gmai.com",
            //    UserName = "testusername",
            //    Password = "Test@com123",
            //    FirstName = "okba",
            //    LastName = "kadi"
            //});


        }

        private void execute()
        {
            // page.DisplayAlert("Clicked", "button list clicked", "ok"); 
        }
    }

    public partial class MainViewModel : BaseViewModel
    {
        #region Proprieties
        public ObservableCollection<MenuList> MenuItems { get; set; }
        #endregion
    }


    public class MenuList
    {
        public string Title { get; set; }
        public string IconUrl { get; set; }
        public string PageName { get; set; }
        public Type TargetType { get; set; }
        public bool IsMainPage { get; set; }
    }
}