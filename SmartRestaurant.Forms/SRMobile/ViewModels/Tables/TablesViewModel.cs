using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using System;
using System.Collections.Generic;
using System.Text;
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
        public short NombreChaises
        {
            get { return table.NombreChaises; }
            set
            {
                if (table.NombreChaises != value)
                {
                    table.NombreChaises = value;
                    RaisePropertyChanged();
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
        private int takenChairs;
        public  int TakenChairs
        {
            get
            {
                //if (takenChairs == null) **** if we consider that chairs are numbered
                //    takenChairs = new List<int>();
                return takenChairs;
            }
            
            set
            {
                

                    takenChairs = value;
                    if (takenChairs >0)
                    {

                    BackgroundColor = Color.FromHex("#FFA374"); }

                        else
                    BackgroundColor = Color.Transparent;
                        RaisePropertyChanged("BackgroundColor");
                   
                
            }
        }
        private Color backgroundcolor;
        public Color BackgroundColor
        {
            get
            {
                if (takenChairs > 0)
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

    }
}
