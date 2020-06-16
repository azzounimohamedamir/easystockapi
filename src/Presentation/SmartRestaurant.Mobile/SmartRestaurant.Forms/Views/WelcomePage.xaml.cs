using SmartRestaurant.Diner.ViewModels;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Diner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomePage : ContentPage
    {
        /// <summary>
        /// Constructor to bind an object of type WelcomeViewModel to the context.
        /// </summary>
        /// <param name="_model"></param>
        public WelcomePage(WelcomeViewModel _model)
        {
            InitializeComponent();

            this.BindingContext = _model;
            Title = "Welcome";

        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await Task.Delay(3000);
            if (((WelcomeViewModel)BindingContext).NextCommand.CanExecute(null))
            {                
                LanguageViewModel.welcome_loaded = false;
                ((WelcomeViewModel)BindingContext).NextCommand.Execute(null);

            }
            
        }
    }
}