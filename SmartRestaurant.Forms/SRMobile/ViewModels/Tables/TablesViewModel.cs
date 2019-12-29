using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Resources;
using SmartRestaurant.Diner.ViewModels.Sections;
using SmartRestaurant.Diner.Views;
using System;
using System.Collections.Generic;
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

        public SeatsListViewModel Seats
        {
            get
            {
                return new SeatsListViewModel(this);
                
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
    }
}
