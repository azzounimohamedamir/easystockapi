using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.ViewModels.Orders;
using SmartRestaurant.Diner.ViewModels.Sections;
using SmartRestaurant.Diner.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Tables
{
    /// <summary>
    /// Used to manage tables as a ViewModel
    /// </summary>
    public class TablesViewModel: SimpleViewModel
    {
        public readonly TableModel table;

        /// <summary>
        /// Get the TableModel from the Model.
        /// </summary>
        /// <param name="_table"></param>
        public TablesViewModel(TableModel _table)
        {
            this.table = _table;
        }

        public int Id { get { return table.Id; } }

        public string Numero
        {
            get { return table.Numero; }
            set
            {
                if (table.Numero != value)
                {
                    table.Numero = value;
                    RaisePropertyChanged();
                }
            }
        }
        public short SeatCount
        {
            get { return table.SeatCount; }
            set
            {
                if (table.SeatCount != value)
                {
                    table.SeatCount = value;
                    RaisePropertyChanged();

                    if (table.SeatCount>0) BackgroundColor = Color.FromHex("#FFA374");
                    else
                        BackgroundColor = Color.Transparent;
                    RaisePropertyChanged("BackgroundColor");
                }
            }
        }
        public int? ZoneId
        {
            get { return table.ZoneId; }
            set
            {
                if (table.ZoneId != value)
                {
                    table.ZoneId = value;
                    RaisePropertyChanged();
                }
            }
        }

        /// <summary>
        /// Used to indicate when a table is selected.
        /// </summary>
        private bool isSelected;
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                if (isSelected != value)
                {
                    isSelected = value;
                    RaisePropertyChanged();
                    if (isSelected) BorderColor = Color.LightBlue;
                    else
                        BorderColor = Color.FromHex("#E5E5E5");
                    RaisePropertyChanged("BorderColor");
                }
            }
        }
        private Color bordercolor;
        public Color BorderColor
        {
            get
            {
                if (isSelected)
                    return Color.LightBlue;
                else
                    return Color.FromHex("#E5E5E5");
            }
            set
            {
                if (bordercolor != value)
                    bordercolor = value;
            }
        }

        private Color backgroundcolor;
        public Color BackgroundColor
        {
            get
            {
                if (SeatCount > 0)
                    return Color.FromHex("#FFA374");
                else
                    return Color.Transparent;
            }
            set
            {
                if (backgroundcolor != value)

                    backgroundcolor = value;
            }
        }
        private SeatsListViewModel seats;
        public SeatsListViewModel Seats
        {
            get
            {
                if(seats==null)
                seats = new SeatsListViewModel(this);
                return seats;                
            }
            set
            {
                seats = value;
            }
        }
        private SeatViewModel selectedSeat;
        public SeatViewModel SelectedSeat
        {
            get { return selectedSeat; }
            set
            {
                if (selectedSeat != value)
                {
                    if (selectedSeat != null)
                        SelectedSeat.IsSelected = !SelectedSeat.IsSelected;
                    SetPropertyValue(ref selectedSeat, value);
                    if (SelectedSeat != null)
                        SelectedSeat.IsSelected = !SelectedSeat.IsSelected;
                }
            }
        }

        private OrderListViewModel currentOrders;
        public OrderListViewModel CurrentOrders
        {
            get
            {
                if (currentOrders == null) currentOrders = new OrderListViewModel();
                return currentOrders;
            }
            set
            {
                currentOrders = value;
            }
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


    }
}
