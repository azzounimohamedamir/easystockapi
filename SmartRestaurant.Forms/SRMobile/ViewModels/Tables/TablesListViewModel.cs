using SmartRestaurant.Diner.Infrastructures;
using SmartRestaurant.Diner.Models;
using SmartRestaurant.Diner.Services;
using SmartRestaurant.Diner.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SmartRestaurant.Diner.ViewModels.Tables
{
    /// <summary>
    /// Used to bind tables liste with the View.
    /// </summary>
    public class TablesListViewModel: SimpleViewModel
    {
        /// <summary>
        /// Tables to bind with the View.
        /// </summary>
        public IList<TablesViewModel> Tables { get; set; }
        
        /// <summary>
        /// Constructor to Fill the List of tables from the Database or Json file stored locally.
        /// </summary>
        public TablesListViewModel()
        {

            ObservableCollection<TableModel> listTables = TableService.GetListTables();
            Tables = new ObservableCollection<TablesViewModel>();
            foreach (var item in listTables)
            {
                Tables.Add(new TablesViewModel(item));
            }
        }

        /// <summary>
        /// The TableViewModel selected by the user to serve  the customer
        /// </summary>
        private TablesViewModel selectedTable;
        public TablesViewModel SelectedTable
        {
            get { return selectedTable; }
            set
            {
                SetPropertyValue(ref selectedTable, value);
                if (SelectedTable != null)
                    SelectedTable.IsSelected = !SelectedTable.IsSelected;
            }
        }

        /// <summary>
        /// Command to navigate to the next page or view.
        /// </summary>
        public ICommand NextCommand
        {
            get
            {
                return new Command(() => {
                    try
                    {
                        App.Current.MainPage.Navigation.PushAsync(new WelcomePage(new WelcomeViewModel()));
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                });
            }
        }
    }
}
