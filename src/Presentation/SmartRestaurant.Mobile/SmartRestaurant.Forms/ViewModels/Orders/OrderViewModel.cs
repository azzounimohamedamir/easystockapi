using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.ViewModels.Sections;
using SmartRestaurant.Diner.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Orders
{
    public class OrderViewModel:SimpleViewModel
    {
        public readonly OrderModel Order;
        
        /// <summary>
        /// Get the OrderModel from the Model.
        /// </summary>
        /// <param name="_Order"></param>
        public OrderViewModel(OrderModel _Order)
        {
            this.Order = _Order;            
        }

        public int Id
        {
            get
            {
                return Order.Id;
            }
        }
        private double _ConvertedTotalDollar;
        public double ConvertedTotalDollar
        {
            get
            {
                return (Math.Round(Total / (SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 2).
                    ExchangeRate == 0 ? 1 : SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 2).ExchangeRate), 2));
            }
            set
            {
                _ConvertedTotalDollar = value;
                RaisePropertyChanged();
            }
        }
        private double _ConvertedTotalEuro;
        public double ConvertedTotalEuro
        {
            get
            {
                return (Math.Round(Total / (SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 1).
                    ExchangeRate == 0 ? 1 : SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 1).ExchangeRate), 2));
            }
            set
            {
                _ConvertedTotalDollar = value;
                RaisePropertyChanged();
            }
        }
        private string _Euro;
        public string Euro
        {
            get
            {
                return SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 1).
                    Name;
            }
            set
            {
                _Euro = value;
                RaisePropertyChanged();
            }
        }
        private string _Dollar;
        public string Dollar
        {
            get
            {
                return SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 2).
                    Name;
            }
            set
            {
                _Dollar = value;
                RaisePropertyChanged();
            }
        }
        private double total;
        public double Total
        {
            get
            {
                return total;
            }
            set
            {
                total = value;
                ConvertedTotalEuro =
(Math.Round(Total / (SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 1).
ExchangeRate == 0 ? 1 : SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 1).ExchangeRate), 2));
                ConvertedTotalDollar =
(Math.Round(Total / (SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 2).
    ExchangeRate == 0 ? 1 : SectionsListViewModel.Currencies.Currencies.FirstOrDefault(c => c.Id == 2).ExchangeRate), 2));
                
                RaisePropertyChanged();
            }
        }
        public int TableId { get
            {
                return Order.TableId;
            }
        }
        
        public string TableNumber { get {
                return Order.TableNumber;
            } }
        public int SeatNumber { get
            {
                return Order.SeatNumber;
            }  }
        public List<DishViewModel> Lines { get; set; }
        private ObservableCollection<Grouping<string, DishViewModel>> _DishesGrouped;
        public ObservableCollection<Grouping<string, DishViewModel>> DishesGrouped { get { return _DishesGrouped; }
            set { _DishesGrouped = value;RaisePropertyChanged(); }
                }
        public FlowDirection FlowDirectionValue
        {

            get
            {
                if (AppResources.Culture != null)
                {
                    return AppResources.Culture.Name == "ar" ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
                }
                else
                {
                    return FlowDirection.LeftToRight;
                }
            }
        }
        private double calories;
        private double carbo;
        private double fat;
        private double protein;
        public double Calories
        {
            get => calories; set
            {
                calories = value;
                RaisePropertyChanged();
            }
        }
        public double Carbo
        {
            get => carbo;
            set
            {
                carbo = value;
                RaisePropertyChanged();
            }
        }
        public double Fat
        {
            get => fat; set
            {
                fat = value;
                RaisePropertyChanged();
            }
        }
        public double Protein
        {
            get => protein; set
            {
                protein = value;
                RaisePropertyChanged();
            }

        }
    }
}