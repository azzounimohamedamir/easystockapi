using SmartRestaurant.Diner.ViewModels.Orders;
using SmartRestaurant.Diner.ViewModels.Sections;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Diner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DinerCommandRecap : ContentPage
    {
        public OrderViewModel viewmodel { get; private set; }
        public DinerCommandRecap(OrderViewModel _model)
        {
            InitializeComponent();
            var sections = _model.Lines.Select(d => d.SubSection.Section.Name);
            var sorted = from d in _model.Lines
                         orderby d.SubSection.Section.Name
                         group d by d.SubSection.Section.Name into DishGroup
                             select new Grouping<string, DishViewModel>(DishGroup.Key, DishGroup);

            //create a new collection of groups
            _model.DishesGrouped = new ObservableCollection<Grouping<string, DishViewModel>>(sorted);
            BindingContext = _model;
            viewmodel = (OrderViewModel)BindingContext;
        }
    }
    public class Grouping<K, T> : ObservableCollection<T>
    {
        public K Key { get; private set; }

        public Grouping(K key, IEnumerable<T> items)
        {
            Key = key;
            foreach (var item in items)
                this.Items.Add(item);
        }
    }
    
}