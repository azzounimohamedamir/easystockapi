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
    public class SeatViewModel : SimpleViewModel
    {
        public readonly int table_Id;
        public readonly int numero;

        /// <summary>
        /// Get the TableModel from the Model.
        /// </summary>
        /// <param name="_table"></param>
        public SeatViewModel(int _table_Id,int _numero)
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
                if(IsTaken)
                    BackgroundColor = Color.FromHex("#FFA374");
                else
                if (IsSelected)
                        BackgroundColor = Color.FromHex("#F2FBFB");
                    else
                        BackgroundColor = Color.White;
                RaisePropertyChanged("BackgroundColor");
                if (IsTaken)
                    BorderColor= Color.FromHex("#EEEEEE");
                else
                if (isSelected) BorderColor = Color.FromHex("#3CBDBF");
                    else
                    BorderColor = Color.FromHex("#EEEEEE");
                    RaisePropertyChanged("BorderColor");
                    
            }
        }
        private Color bordercolor;
        public Color BorderColor
        {
            get
            {                                                   
                if (IsTaken)
                    return Color.FromHex("#EEEEEE");
                else

                if (isSelected)
                    return Color.FromHex("#3CBDBF");
                else
                    return Color.FromHex("#EEEEEE");
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
                    if (IsSelected)
                    BackgroundColor= Color.FromHex("#F2FBFB");
                else
                    BackgroundColor= Color.White;
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
                    if(IsSelected)
                    return Color.FromHex("#F2FBFB");
                else
                    return Color.White;
            }
            set
            {
                if (backgroundcolor != value)

                    backgroundcolor = value;
            }
        }
    }
}
