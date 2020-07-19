using SmartRestaurant.Diner.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Diner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordPage : ContentPage
    {
        /// <summary>
        /// Constructor to bind an object of type PasswordViewModel to the context.
        /// </summary>
        /// <param name="_model"></param>
        public PasswordPage(PasswordViewModel _model)
        {
            InitializeComponent();

            BindingContext = _model;

            Title = "Login";
        }

        /// <summary>
        /// Every time the text of an entry is changed than if the entry text lengh equal to one than the focus is placed in the next entry.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            Entry txtEntry = sender as Entry;
            var stack = txtEntry.Parent as StackLayout;
            int index = stack.Children.IndexOf(txtEntry);
            if (txtEntry.Text.Trim().Length == 1)
            {
                if (index >= 0)
                {
                    index++;
                    if (index < stack.Children.Count)
                    {
                        Entry nextEntry = stack.Children[index] as Entry;
                        if (nextEntry != null)
                        {
                            nextEntry.Focus();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Set the focus on the first entry on the View
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContentPage_Appearing(object sender, EventArgs e)
        {
            txtFirstChar.Focus();
        }
    }
}