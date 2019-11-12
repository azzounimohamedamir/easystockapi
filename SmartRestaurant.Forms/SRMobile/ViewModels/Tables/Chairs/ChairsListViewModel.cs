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
    public class ChairsListViewModel : SimpleViewModel
    {
        /// <summary>
        /// Tables to bind with the View.
        /// </summary>
        public IList<ChairsViewModel> Chairs { get; set; }
        public string Numero_Table { get; set; }
        /// <summary>
        /// Constructor to Fill the List of tables from the Database or Json file stored locally.
        /// </summary>
        public ChairsListViewModel(TablesViewModel table)
        {

            //TableModel selectedtable = TableService.GetListTables().FirstOrDefault(t=>t.Id==table.Id);
            //Numero_Table = selectedtable.Numero;
            //Chairs = new ObservableCollection<ChairsViewModel>();
            //for(int i=1;i<=selectedtable.NombreChaises;i++)
            //{
            //    Chairs.Add(new ChairsViewModel(table.Id, i) { IsTaken=table.TakenChairs==null?false: table.TakenChairs.Contains(i)});
            //}
        }
 


        /// <summary>
        /// The TableViewModel selected by the user to serve  the customer
        /// </summary>
        private ChairsViewModel selectedChair;
        public ChairsViewModel SelectedChair
        {
            get { return selectedChair; }
            set
            {
                SetPropertyValue(ref selectedChair, value);
                if (SelectedChair != null)
                    SelectedChair.IsSelected = !SelectedChair.IsSelected;
            }
        }


    }
}
