using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
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
    public class ChairsViewModel: SimpleViewModel
    {
        public readonly int table_Id;
        public readonly int numero;

        /// <summary>
        /// Get the TableModel from the Model.
        /// </summary>
        /// <param name="_table"></param>
        public ChairsViewModel(int _table_Id,int _numero)
        {
            table_Id = _table_Id;
            numero = _numero;

        }

        public int Id { get; }
        
        public int Numero
        {
            get { return numero; }
            set
            {
                if (numero != value)
                {
                    Numero = value;
                    RaisePropertyChanged();
                }
            }
        }
 

   

        /// <summary>
        /// Used to indicate when a chair is selected.
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
                    isSelected = value;
                    RaisePropertyChanged();
                    if (isSelected) BorderColor = Color.LightBlue;
                    else
                    BorderColor = Color.Transparent;
                    RaisePropertyChanged("BorderColor");
                    
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
                    return Color.LightGray;
            }
            set
            {
                if (bordercolor != value)

                    bordercolor = value;
            }
        }


        private bool isTaken;
        public bool IsTaken
        {
            get
            {
                return isTaken;
            }
            set
            {
                isTaken = value;
                RaisePropertyChanged();
                if (isTaken)
                    BackgroundColor = Color.FromHex("#FFA374");
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
                if (IsTaken)
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
