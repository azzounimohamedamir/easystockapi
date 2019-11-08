



using Microsoft.AspNetCore.SignalR.Client;
using SmartRestaurant.Application.Commun.Languages.Factory;
using SmartRestaurant.Application.Services;
using SmartRestaurant.Application.Services.Models;
using SmartRestaurant.Domain.Enumerations;
using SmartRestaurant.Forms.Helpers;
using SmartRestaurant.Forms.Interfaces;
using SmartRestaurant.Forms.Models;
using SmartRestaurant.Forms.Models.SmartRestaurant.Forms.Models;
using SmartRestaurant.Forms.Pages;
using SmartRestaurant.Forms.Services;
using SmartRestaurant.Resources.Xamarin.Client;
using Syncfusion.XForms.TabView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartRestaurant.Forms.ViewModels
{
    public partial class ServiceViewModel : BaseViewModel
    {
        ViewModelLocator locator = Xamarin.Forms.Application.Current.Resources["Locator"] as ViewModelLocator;
        IAPIService api;
        public SfTabView menue;
        public bool? result = null;
        HubConnection hub;
        public FlowDirection FlowDirection { get; set; } = FlowDirection.RightToLeft;
        private const string ip = "192.168.1.22:40000";
        public ServiceViewModel(IAPIService api)
        {
            InitHub();

            this.api = api;
            RestaurantId = Settings.RestaurantId;

            OrderedItems = new ObservableCollection<MenuItemModelDto>();
            OrdersList = new ObservableCollection<OrderModel>();

            AddCommand = new Command<object>(AddQuantity);
            OrderListCommand = new Command<object>(OrderListCommand_Ex);
            CheckoutCommand = new Command(CheckOut);
            RemoveOrderCommand = new Command<object>(RemoveOrder);
            NavigateOrdersPage = new Command<object>(NavigateOrdersPage_Ex);
            CancelOrderItemCommand = new Command<object>(CancelOrderItemCommand_Ex);

            DishDetailsPage = new Command<object>(DishDetailsPage_Ex);

        }

        private  async void DishDetailsPage_Ex(object obj )
        {
            MenuItemModelDto DishDetailsInfo = obj as MenuItemModelDto;

            //TODO:open new page and pass arg to it 
            await locator.Main.DishPage.Navigation.PushAsync(new DishDetails(DishDetailsInfo));



        }


        #region Ex


        private async void CancelOrderItemCommand_Ex(object obj)
        {
            try
            {
                OrderItemStateDto state = obj as OrderItemStateDto;
                if (state == null) return;

                if (state.State.State != EnumState.Waitting)
                {
                    await Xamarin.Forms.Application.Current.MainPage
                .DisplayAlert("", UIRes.CantCancelTxt, UIRes.OkTxt);
                    return;
                }

                var sure = await Xamarin.Forms.Application.Current.MainPage
          .DisplayAlert(UIRes.ValidationTxt,
          UIRes.SureTxt, UIRes.YesTxt, UIRes.NoTxt);

                if (!sure) return;

                // Puch using signalR
                var orderItem = OrdersList.LastOrDefault()
                    .OrderItems
                    .FirstOrDefault(x => x.Id == state.OrderItemId);

                CanceledOrderItemModel canceled = new CanceledOrderItemModel
                {
                    ItemModel = orderItem,
                    Causes = "",
                    UserId = "",
                    Whom = EnumWhom.Guest
                };


                await ConnectHubAsync();
                await hub.InvokeAsync("CanceledOrderItem", canceled);
            
                await DisconnectHubAsync();

                await Xamarin.Forms.Application.Current.MainPage
               .DisplayAlert("", UIRes.ItemCanceledTxt, UIRes.OkTxt);

            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// Get Service that contain the menue from Api
        /// </summary>
        /// <returns></returns>
        public async Task<bool> RefrechServices()
        {

            var serviceId = await api.GetRestaurantServiceIdAsync(RestaurantId);
            if (serviceId != Settings.LastServiceId)
            {
                ServiceModel = await api.GetRestaurantServiceAsync(RestaurantId,
                    locator.Enter.SelectedLanguage?.CultureIso ?? EnumLaguangeIso.En);
                Settings.LastServiceId = serviceId;
                return true;
            }
            return false;
        }
        /// <summary>
        /// remove order from the list
        /// </summary>
        /// <param name="obj"></param>
        private void RemoveOrder(object obj)
        {
            var p = obj as MenuItemModelDto;
            p.Quantity = 0;
        }
        /// <summary>
        /// Confirme the Order
        /// </summary>
        /// <param name="obj"></param>
        private async void CheckOut(object obj)
        {
            var checkout = await Xamarin.Forms.Application.Current.MainPage
            .DisplayAlert(UIRes.ValidationTxt,
            UIRes.ValidationQuestionTxt, UIRes.YesTxt, UIRes.NoTxt);

            if (checkout)
            {
                var order = new OrderModel();
                order.RestaurantId = "R01";
                order.PlaceId = "P01";
                order.AddRangeItems(
                    MenuItemModelDto.ToModeList(OrderedItems.ToList()));
                OrdersList.Add(order);

                // Puch using signalR
                await ConnectHubAsync();
                await hub.InvokeAsync("PushOrder", order);
                //await DisconnectHubAsync();

                await Xamarin.Forms.Application.Current.MainPage
                  .DisplayAlert("", UIRes.OrderPlacedTxt, UIRes.OkTxt);

                // show UI of orderStatus
                var sampleView = obj as ContentPage;
                var ordersPage = new OrderStatusPage();
                OrderItemStates = ToStatesList(order.OrderItems);
                ordersPage.BindingContext = this;
                await sampleView.Navigation.PushAsync(ordersPage);

                // Reinitialize  the next order
                while (OrderedItems.Count > 0)
                {
                    OrderedItems[OrderedItems.Count - 1].Quantity = 0;
                }


            }
        }

        private List<OrderItemStateDto> ToStatesList(List<OrderItemModel> orderItems)
        {
            return orderItems.ConvertAll((item) =>
            {
                var temp = new OrderItemStateDto
                {
                    OrderItemName = item.Name,
                    OrderItemId = item.Id,
                };
                temp.ChangeState(item.LastState);
                return temp;
            });
        }

        private void OrderListCommand_Ex(object obj)
        {
            var sampleView = obj as ContentPage;
            var ordersPage = new OrderedItemsPage();
            ordersPage.BindingContext = this;
            sampleView.Navigation.PushAsync(ordersPage);
        }
        private void NavigateOrdersPage_Ex(object obj)
        {
            var sampleView = obj as ContentPage;
            var page = new OrdersListPage();
            page.BindingContext = this;
            sampleView.Navigation.PushAsync(page);
        }
        /// <summary>
        /// increase item quantity by 1 so it will apeare in ordered items list
        /// </summary>
        /// <param name="obj"></param>
        private void AddQuantity(object obj)
        {
            var p = obj as MenuItemModelDto;
            p.Quantity += 1;
        }
        #endregion

        #region CanEx

        #endregion

        #region Methods
        public async Task ConnectHubAsync()
        {
            await hub.StartAsync();
            await hub.InvokeAsync("JoinGroup", "P01");
        }
        public async Task DisconnectHubAsync()
        {
            await hub.StopAsync();
        }

        private void InitHub()
        {
            const string url = "http://" + ip + "/restaurants/ordershub";
            hub = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();


             hub.On<string, OrderItemState>("feedBack", (orderItemId, state) =>
             {
                 var orderitem = OrderItemStates.FirstOrDefault(x => x.OrderItemId == orderItemId);
                 orderitem.ChangeState(state);
             });

        }
        #endregion
    }


    public partial class ServiceViewModel
    {

        #region Properties
        public ObservableCollection<MenuItemModelDto> OrderedItems { get; set; }
        public ObservableCollection<OrderModel> OrdersList { get; set; }
        public List<OrderItemStateDto> OrderItemStates { get; set; }
        public ObservableCollection<OrderModel> ItemsList { get; set; }
        public ServiceModel ServiceModel { get; set; }
        public string RestaurantId { get; set; }
        public int TotalOrderedItems { get; set; }
        public double TotalPrice { get; set; }


        #endregion

        #region Commands
        public Command<object> AddCommand { get; set; }
        public Command<object> CancelOrderItemCommand { get; set; }
        public Command CheckoutCommand { get; set; }
        public Command<object> LoadMoreItemsCommand { get; set; }
        public Command<object> OrderListCommand { get; set; }
        public Command<object> RemoveOrderCommand { get; set; }
        public Command<object> NavigateOrdersPage { get; set; }
        public Command<object> DishDetailsPage { get; set; }
        #endregion
    }
}