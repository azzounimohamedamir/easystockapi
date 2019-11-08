using SmartRestaurant.Forms.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Forms.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllergiesPage : ContentPage
    {
        bool check = true;
        SelectionAllergiesViewModel view = new SelectionAllergiesViewModel();
        public AllergiesPage()
        {
            InitializeComponent();
            this.BindingContext = view;
            //check = false;
            //listView.SeparatorColor = Color.Transparent;
            //check = true;

        }

        void Handle_SelectionChanged(object sender, Syncfusion.XForms.ComboBox.SelectionChangedEventArgs e)
        {
            //List<object> items = new List<object>();
            //var temp = view.selct;
            //if (e.Value != null && (((e.Value is string && (string)e.Value != string.Empty)) || (e.Value is IList && (e.Value as IList).Count > 0)) && check)
            //{
            //    if (Device.RuntimePlatform == Device.UWP)
            //    {
            //        items = new List<object>(e.Value as ObservableCollection<object>);
            //    }
            //    else
            //    {
            //        for (int ii = 0; ii < (e.Value as List<object>).Count; ii++)
            //        {
            //            var collection = (e.Value as List<object>)[ii];
            //            items.Add(collection);
            //        }
            //    }
            //    view.SelectedItem1 = items;
            //    if (items.Count > 0)
            //    {
            //        listView.SeparatorColor = Color.Black;
            //    }
            //    else
            //    {
            //        listView.SeparatorColor = Color.Transparent;
            //    }
            //}
            //else
            //{
            //    view.SelectedItem1 = null;
            //}

        }
    }

    public class Allergielist : BaseViewModel
    {
       
        public string AllergieImage { get; set; }
       
      
        public string AllergieName
        {
            get ;
            set ;
        }
      
        public string Date
        {
            get ;
            set ;
        }
    }
    public class SelectionAllergiesViewModel : BaseViewModel
    {
       
        public ObservableCollection<Allergielist> AllergieCollection { get; set; }
       

        
        public List<object> SelectedItem1 { get; set; }
        ///public object selct { get; set; }
     

        public SelectionAllergiesViewModel()
        {
            AllergieCollection = new ObservableCollection<Allergielist>();

            AllergieCollection.Add(new Allergielist() { AllergieImage = "Allergic", AllergieName = "Nuts", Date = "Updated 2 days ago" });
            AllergieCollection.Add(new Allergielist() { AllergieImage = "Allergic", AllergieName = "Hurbs", Date = "Updated 4 days ago" });
            AllergieCollection.Add(new Allergielist() { AllergieImage = "Allergic", AllergieName = "peanuts", Date = "Updated 9 days ago" });
            AllergieCollection.Add(new Allergielist() { AllergieImage = "Allergic", AllergieName = "sesame seeds", Date = "Updated 9 days ago" });
            AllergieCollection.Add(new Allergielist() { AllergieImage = "Allergic", AllergieName = "cereals containing gluten", Date = "Updated 9 days ago" });
        
        }
    }
}