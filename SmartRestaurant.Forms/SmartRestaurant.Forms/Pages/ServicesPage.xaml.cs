using SmartRestaurant.Application.Services.Models;
using SmartRestaurant.Forms.Helpers;
using SmartRestaurant.Forms.Models;
using SmartRestaurant.Forms.Models.SmartRestaurant.Forms.Models;
using SmartRestaurant.Forms.Services;
using SmartRestaurant.Forms.Templates;
using SmartRestaurant.Forms.ViewModels;
using Syncfusion.ListView.XForms;
using Syncfusion.XForms.TabView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServicesPage : ContentPage
    {
        ServiceViewModel viewModel;
        SelectionIndicatorSettings selectionIndicatorSettings = new SelectionIndicatorSettings();
      


        public ServicesPage()
        {
            InitializeComponent();
            this.BackgroundImageSource = "background.jpg";
          
            viewModel = BindingContext as ServiceViewModel;
            viewModel.result = null;
            selectionIndicatorSettings.Color = Color.FromHex("#62E249");
            selectionIndicatorSettings.Position = SelectionIndicatorPosition.Bottom;
            selectionIndicatorSettings.StrokeThickness = 1;


        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();

            BusyIndicator.IsBusy = true;

            int tries = 1;
            while (viewModel.result == null && tries <= 3)
            {
                await GetMenueTabView();
            }

            if (viewModel.menue != null)
            {
                Menue.Content = viewModel.menue;
            }

            BusyIndicator.IsBusy = false;
            BusyIndicator.IsVisible = false;
        }

        public async Task GetMenueTabView()
        {
            try
            {
                if (viewModel == null)
                {
                    viewModel.result = null;
                    return;
                }

                var isNewService = await viewModel.RefrechServices();
                var service = viewModel.ServiceModel;

                if (!isNewService)
                {
                    viewModel.result = false;
                    return;
                }

                viewModel.menue = await GetTabView(service);
                viewModel.result = true;
            }
            catch (Exception)
            {
                viewModel.result = null;
            }
        }

        private Task<SfTabView> GetTabView(ServiceModel service)
        {
            return Task.Run(() =>
             {
                 SfTabView main = new SfTabView();
                 main.SelectionIndicatorSettings = selectionIndicatorSettings;
                 main.VisibleHeaderCount = service.Sections.Count;
               
                   
                 foreach (var section in service.Sections)
                 {
                     RecDishCall(section, main);
                 }
                 return main;
             });
        }

        private void RecDishCall(SectionModel section, SfTabView tabed)
        {

            var datatempalte = new DishTemplate();
           
            if (section.Childs == null)
            {
                ContentView menuItemsList = null;
                List<MenuItemModelDto> items = new List<MenuItemModelDto>();

                if (section.Dishes != null && section.Dishes.Count > 0)
                {
                    foreach (var dish in section.Dishes)
                    {
                        MenuItemModelDto dtoItem = dish;
                        dtoItem.QuantityPropertyChanged =
                            () => QuantityChangedEvent(dtoItem);
                        items.Add(dtoItem);
                    }
                    ContentPage contentpage = this;
                    menuItemsList = new DishesList() { Items = items };

                    menuItemsList.BindingContext = viewModel;

                }
                else if (section.Products != null && section.Products.Count > 0)
                {
                    foreach (var product in section.Products)
                    {
                        MenuItemModelDto dtoItem = product;
                        dtoItem.QuantityPropertyChanged =
                            () => QuantityChangedEvent(dtoItem);
                        items.Add(dtoItem);
                    }
                    menuItemsList = new DishesList() { Items = items };

                    menuItemsList.BindingContext = viewModel;
                    menuItemsList.FlowDirection = viewModel.FlowDirection;
                }

                tabed.Items.Add(new SfTabItem()
                {
                    Content = menuItemsList,
                    Title = section.Name,
                    TitleFontColor = Color.White ,
                    TitleFontSize = 14 ,
                    TitleFontAttributes = FontAttributes.Bold,
                    SelectionColor = Color.White,
                    //SelectionColor = Color.FromHex("#62E249"),

                });
            }
            else
            {
                var subTubed = new SfTabView();
                subTubed.SelectionIndicatorSettings = selectionIndicatorSettings;
                subTubed.VisibleHeaderCount = section.Childs.Count;
                foreach (var subFamily in section.Childs)
                {
                    RecDishCall(subFamily, subTubed);
                }
                tabed.Items.Add(new SfTabItem
                {
                    Title = section.Name,
                    Content = subTubed,
                    TitleFontColor = Color.White,
                    TitleFontSize = 14,
                    TitleFontAttributes = FontAttributes.Bold,
                    SelectionColor = Color.White,
                    //SelectionColor = Color.FromHex("#62E249"),

                }); ;
            }
        }

        private void QuantityChangedEvent(MenuItemModelDto p)
        {
            if (viewModel.OrderedItems.Contains(p) && p.Quantity <= 0)
                viewModel.OrderedItems.Remove(p);
            else if (!viewModel.OrderedItems.Contains(p) && p.Quantity > 0)
                viewModel.OrderedItems.Add(p);

            viewModel.TotalOrderedItems = viewModel.OrderedItems.Count;
            viewModel.TotalPrice = 0;
            for (int j = 0; j < viewModel.OrderedItems.Count; j++)
            {
                var order = viewModel.OrderedItems[j];
                viewModel.TotalPrice += order.TotalPrice;
            }
        }
    }
}

