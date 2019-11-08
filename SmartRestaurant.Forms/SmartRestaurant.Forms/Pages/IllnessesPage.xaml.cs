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
    public partial class IllnessesPage : ContentPage
    {
        bool check = true;
        SelectionIllnessesViewModel view = new SelectionIllnessesViewModel();
        public IllnessesPage()
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


    public class Illnesslist : BaseViewModel
    {

        public string IllnessImage { get; set; }


        public string IllnessName
        {
            get;
            set;
        }

        public string Date
        {
            get;
            set;
        }
    }
    public class SelectionIllnessesViewModel : BaseViewModel
    {

        public ObservableCollection<Illnesslist> IllnessCollection { get; set; }



        public List<object> SelectedItem1 { get; set; }


        public SelectionIllnessesViewModel()
        {
            IllnessCollection = new ObservableCollection<Illnesslist>();

            IllnessCollection.Add(new Illnesslist() { IllnessImage = "Illnesses", IllnessName = "Hepatitis B", Date = "Updated 2 days ago" });
            IllnessCollection.Add(new Illnesslist() { IllnessImage = "Illnesses", IllnessName = "Diabetes", Date = "Updated 4 days ago" });
            IllnessCollection.Add(new Illnesslist() { IllnessImage = "Illnesses", IllnessName = "Fever", Date = "Updated 4 days ago" });
          
        }
    }
}