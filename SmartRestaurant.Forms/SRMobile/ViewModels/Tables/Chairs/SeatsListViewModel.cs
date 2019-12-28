using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Services;
using SmartRestaurant.Diner.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Tables
{
    /// <summary>
    /// Used to bind tables liste with the View.
    /// </summary>
    public class SeatsListViewModel : SimpleViewModel
    {
        /// <summary>
        /// Tables to bind with the View.
        /// </summary>
        public IList<SeatViewModel> Seats { get; set; }
        public string Numero_Table { get; set; }
        /// <summary>
        /// Constructor to Fill the List of tables from the Database or Json file stored locally.
        /// </summary>
        public SeatsListViewModel(TablesViewModel table)
        {
            Numero_Table = table.Numero;
            Seats = new List<SeatViewModel>();
            for(int i=1;i<=table.NombreChaises;i++)
            {
                Seats.Add(new SeatViewModel(table.Id, i));
            }
        }
 


        /// <summary>
        /// The TableViewModel selected by the user to serve  the customer
        /// </summary>
        private SeatViewModel selectedSeat;
        public SeatViewModel SelectedSeat
        {
            get { return selectedSeat; }
            set
            {
                SetPropertyValue(ref selectedSeat, value);
                if (SelectedSeat != null)
                    SelectedSeat.IsSelected = !SelectedSeat.IsSelected;
            }
        }


    }
}
