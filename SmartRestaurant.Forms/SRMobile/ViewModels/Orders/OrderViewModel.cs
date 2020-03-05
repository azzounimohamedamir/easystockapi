using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.ViewModels.Sections;
using SmartRestaurant.Diner.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private double total;
        public double Total
        {
            get
            {
                total= Order.Total;
                return total;
            }
            set
            {
                total = value;
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
        public ObservableCollection<Grouping<string, DishViewModel>> DishesGrouped { get; set; }
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
    }
}