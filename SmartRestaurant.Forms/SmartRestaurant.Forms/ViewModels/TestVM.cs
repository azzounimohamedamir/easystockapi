



using SmartRestaurant.Forms.Models.SmartRestaurant.Forms.Models;
using SmartRestaurant.Forms.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SmartRestaurant.Forms.ViewModels
{
    public class TestVM : BaseViewModel
    {
        private int totalItems = 22;
        private ProductRepository productRepository;
        private int totalOrderedItems = 0;
        private double totalPrice = 0;
        public ObservableCollection<Product> Products { get; set; }

        public ObservableCollection<Product> Products1 { get; set; }

        public ObservableCollection<Product> Orders { get; set; }

        public Command<object> AddCommand { get; set; }

        public Command<object> LoadMoreItemsCommand { get; set; }

        public Command<object> OrderListCommand { get; set; }

        public Command<object> RemoveOrderCommand { get; set; }


        public Command CheckoutCommand { get; set; }

        public int TotalOrderedItems { get; set; }
         public double TotalPrice { get; set; }
        public TestVM()
        {
            productRepository = new ProductRepository();
            Products = new ObservableCollection<Product>();
            Products1 = new ObservableCollection<Product>();
            Orders = new ObservableCollection<Product>();

            GenerateSource();

            if (Device.Idiom == TargetIdiom.Tablet)
                AddProducts(0, 11);
            else
                AddProducts(0, 6);

            AddCommand = new Command<object>(AddQuantity);
            OrderListCommand = new Command<object>(NavigateOrdersPage);
            CheckoutCommand = new Command(CheckOut);
            RemoveOrderCommand = new Command<object>(RemoveOrder);
            LoadMoreItemsCommand = new Command<object>(LoadMoreItems, CanLoadMoreItems);
        }

        private void RemoveOrder(object obj)
        {
            var p = obj as Product;
            p.Quantity = 0;
        }

        private async void CheckOut(object obj)
        {
            var checkout = await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Checkout", "Do you want to checkout?", "Yes", "No");
          
            if (true)
            {
                while (Orders.Count > 0)
                {
                    Orders[Orders.Count - 1].Quantity = 0;
                }

                 await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("", "Your order has been placed.", "OK");

                Device.BeginInvokeOnMainThread(() =>
                {
                    if (obj != null)
                        (obj as ContentPage).Navigation.PopAsync();
                });
            }
        }

        private void NavigateOrdersPage(object obj)
        {
            var sampleView = obj as ContentPage;
            var ordersPage = new OrderedItemsPage();
           ordersPage.BindingContext = this;
            sampleView.Navigation.PushAsync(ordersPage);
        }


        /// <summary>
        ///  add dummy data from repository product 
        /// </summary>
        /// <param name="index"></param>
        /// <param name="count"></param>
        private void AddProducts(int index, int count)
        {
            Assembly assembly = typeof(Page1).GetTypeInfo().Assembly;
            for (int i = index; i < index + count; i++)
            {
                var name = productRepository.Names[i];
                var p = new Product()
                {
                    Name = name,
                    Weight = productRepository.Weights[i],
                    Price = productRepository.Prices[i],
                     #if COMMONSB
                    Image = ImageSource.FromResource("SampleBrowser.Icons.LoadMore." + name.Replace(" ", string.Empty) + ".jpg", assembly)
                            #else
                    Image = ImageSource.FromResource("SampleBrowser.SfListView.Icons.LoadMore." + name.Replace(" ", string.Empty) + ".jpg", assembly)
                                #endif
                };

                p.PropertyChanged += (s, e) =>
                {
                    var product = s as Product;
                    if (e.PropertyName == "Quantity")
                    {
                        if (Orders.Contains(product) && product.Quantity <= 0)
                            Orders.Remove(product);
                        else if (!Orders.Contains(product) && product.Quantity > 0)
                            Orders.Add(product);

                        TotalOrderedItems = Orders.Count;
                        TotalPrice = 0;
                        for (int j = 0; j < Orders.Count; j++)
                        {
                            var order = Orders[j];
                            TotalPrice += order.TotalPrice;
                        }
                    }
                };

                Products.Add(p);
            }
        }

        private void GenerateSource()
        {
            Assembly assembly = typeof(OrderedItemsPage).GetTypeInfo().Assembly;
            for (int i = 0; i < productRepository.Names.Count(); i++)
            {
                var name = productRepository.Names[i];
                var p = new Product()
                {
                    Name = name,
                    Weight = productRepository.Weights[i],
                    Price = productRepository.Prices[i],
                         #if COMMONSB
                    Image = ImageSource.FromResource("SampleBrowser.Icons.LoadMore." + name.Replace(" ", string.Empty) + ".jpg", assembly)
                                  #else
                    Image = ImageSource.FromResource("SampleBrowser.SfListView.Icons.LoadMore." + name.Replace(" ", string.Empty) + ".jpg", assembly)
#endif
                };

                Products1.Add(p);
            }
        }

        private bool CanLoadMoreItems(object obj)
        {
            if (Products.Count >= totalItems)
                return false;
            return true;
        }

        private async void LoadMoreItems(object obj)
        {
            var listview = obj as Syncfusion.ListView.XForms.SfListView;
            listview.IsBusy = true;
            await Task.Delay(2500);

            var index = Products.Count;
            var count = index + 3 >= totalItems ? totalItems - index : 3;
            AddProducts(index, count);

            listview.IsBusy = false;
        }

        private void AddQuantity(object obj)
        {
            var p = obj as Product;
            p.Quantity += 1;
        }
    }
}
