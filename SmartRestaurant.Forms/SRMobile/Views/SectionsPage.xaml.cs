using FFImageLoading.Forms;
using FFImageLoading.Transformations;
using IntelliAbb.Xamarin.Controls;
using SmartRestaurant.Diner.ViewModels.Sections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;

namespace SmartRestaurant.Diner.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SectionsPage : ContentPage
    {
        SectionsListViewModel model;

        /// <summary>
        /// Constructor to bind an object of type SectionsListViewModel to the context.
        /// </summary>
        /// <param name="_model"></param>
        public SectionsPage(SectionsListViewModel _model)
        {
            InitializeComponent();
            model = _model;
            Title = "Accueil";
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#E0E0E0");
            ((NavigationPage)Application.Current.MainPage).BarTextColor = Color.FromHex("#000000");

            SetContent();
        }

        /// <summary>
        /// Set the content of the View programmatically, to put sections on three columns.
        /// </summary>
        public void SetContent()
        {
            var stack = new StackLayout();
            stack.Padding = new Thickness(10);
            stack.HorizontalOptions = LayoutOptions.Center;
            var label = new Label();
            label.Text = "Catégories";
            label.VerticalOptions = LayoutOptions.Start;
            label.HorizontalOptions = LayoutOptions.Start;
            label.FontSize = 28;
            label.FontFamily = "Roboto";
            label.TextColor = Color.FromHex("#3C536A");
            label.FontAttributes = FontAttributes.Bold;
            stack.Children.Add(label);

            Grid grid = new Grid();
            var col = new ColumnDefinition();
            col.Width = new GridLength(.1, GridUnitType.Auto);
            grid.ColumnDefinitions.Add(col);

            col = new ColumnDefinition();
            col.Width = new GridLength(.1, GridUnitType.Auto);
            grid.ColumnDefinitions.Add(col);

            col = new ColumnDefinition();
            col.Width = new GridLength(.1, GridUnitType.Auto);
            grid.ColumnDefinitions.Add(col);

            var row = new RowDefinition();
            
            int rowNumber = 0;
            
            for (int i = 0; i < model.Sections.Count; i++)
            {
                row = new RowDefinition();
                row.Height = new GridLength(.1, GridUnitType.Auto);
                grid.RowDefinitions.Add(row);

                var absoluteLayout = new  AbsoluteLayout();
                absoluteLayout.WidthRequest = 240;
                absoluteLayout.HeightRequest = 320;
                absoluteLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
                absoluteLayout.VerticalOptions = LayoutOptions.FillAndExpand;
                absoluteLayout.Padding = new Thickness(7);

                var image = new CachedImage();
                image.WidthRequest = 240;
                image.HeightRequest = 320;
                image.HorizontalOptions = LayoutOptions.Center;
                image.VerticalOptions = LayoutOptions.Center;
                image.Aspect = Aspect.AspectFill;
                image.DownsampleToViewSize = true;
                image.Source = model.Sections[i].Image;
                image.BackgroundColor = Color.Transparent;
                AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0, 0, 240, 320));
                absoluteLayout.Children.Add(image);

                PancakeView pancake = new PancakeView();
                pancake.HeightRequest = 50;
                pancake.WidthRequest = 240;
                pancake.HorizontalOptions = LayoutOptions.FillAndExpand;
                pancake.VerticalOptions = LayoutOptions.End;
                pancake.BackgroundGradientEndColor = Color.FromHex("#343d46");
                pancake.BackgroundGradientStartColor = Color.Transparent;
                AbsoluteLayout.SetLayoutBounds(pancake, new Rectangle(0, 220, 240, 100));
                absoluteLayout.Children.Add(pancake);

                label = new Label();
                label.Text = model.Sections[i].Name;
                label.VerticalOptions = LayoutOptions.End;
                label.HorizontalOptions = LayoutOptions.Center;
                label.FontSize = 28;
                label.FontFamily = "Roboto";
                label.TextColor = Color.White;
                label.FontAttributes = FontAttributes.Bold;
                AbsoluteLayout.SetLayoutBounds(label, new Rectangle(0, 270, 240, 50));
                absoluteLayout.Children.Add(label);

                grid.Children.Add(absoluteLayout, 0, rowNumber);

                i++;
                if(i < model.Sections.Count)
                {
                    image = new CachedImage();
                    image.WidthRequest = 240;
                    image.HeightRequest = 320;
                    image.HorizontalOptions = LayoutOptions.Center;
                    image.VerticalOptions = LayoutOptions.Center;
                    image.Aspect = Aspect.AspectFill;
                    image.DownsampleToViewSize = true;

                    image.Source = model.Sections[i].Image;
                    //image.StartColor = Color.Black;
                    //image.EndColor = Color.White;

                    absoluteLayout = new AbsoluteLayout();
                    absoluteLayout.WidthRequest = 240;
                    absoluteLayout.HeightRequest = 320;
                    absoluteLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
                    absoluteLayout.VerticalOptions = LayoutOptions.FillAndExpand;
                    absoluteLayout.Padding = new Thickness(7);

                    AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0, 0, 240, 320));
                    absoluteLayout.Children.Add(image);

                    pancake = new PancakeView();
                    pancake.HeightRequest = 50;
                    pancake.WidthRequest = 240;
                    pancake.HorizontalOptions = LayoutOptions.FillAndExpand;
                    pancake.VerticalOptions = LayoutOptions.End;
                    pancake.BackgroundGradientEndColor = Color.FromHex("#343d46");
                    pancake.BackgroundGradientStartColor = Color.Transparent;
                    AbsoluteLayout.SetLayoutBounds(pancake, new Rectangle(0, 220, 240, 100));
                    absoluteLayout.Children.Add(pancake);

                    label = new Label();
                    label.Text = model.Sections[i].Name;
                    label.VerticalOptions = LayoutOptions.End;
                    label.HorizontalOptions = LayoutOptions.Center;
                    label.FontSize = 28;
                    label.FontFamily = "Roboto";
                    label.TextColor = Color.White;
                    label.FontAttributes = FontAttributes.Bold;

                    AbsoluteLayout.SetLayoutBounds(label, new Rectangle(0, 270, 240, 50));
                    absoluteLayout.Children.Add(label);

                    grid.Children.Add(absoluteLayout, 1, rowNumber);

                    i++;

                    if(i < model.Sections.Count)
                    {
                    
                        image = new CachedImage();
                        image.WidthRequest = 240;
                        image.HeightRequest = 320;
                        image.HorizontalOptions = LayoutOptions.Center;
                        image.VerticalOptions = LayoutOptions.Center;
                        image.Aspect = Aspect.AspectFill;
                        image.DownsampleToViewSize = true;

                        image.Source = model.Sections[i].Image;
                        
                        absoluteLayout = new  AbsoluteLayout();
                        absoluteLayout.WidthRequest = 240;
                        absoluteLayout.HeightRequest = 320;
                        absoluteLayout.HorizontalOptions = LayoutOptions.FillAndExpand;
                        absoluteLayout.VerticalOptions = LayoutOptions.FillAndExpand;
                        absoluteLayout.Padding = new Thickness(7);

                        AbsoluteLayout.SetLayoutBounds(image, new Rectangle(0, 0, 240, 320));
                        absoluteLayout.Children.Add(image);

                        pancake = new PancakeView();
                        pancake.HeightRequest = 50;
                        pancake.WidthRequest = 240;
                        pancake.HorizontalOptions = LayoutOptions.FillAndExpand;
                        pancake.VerticalOptions = LayoutOptions.End;
                        pancake.BackgroundGradientEndColor = Color.FromHex("#343d46");
                        pancake.BackgroundGradientStartColor = Color.Transparent;
                        AbsoluteLayout.SetLayoutBounds(pancake, new Rectangle(0, 220, 240, 100));
                        absoluteLayout.Children.Add(pancake);

                        label = new Label();
                        label.Text = model.Sections[i].Name;
                        label.VerticalOptions = LayoutOptions.End;
                        label.HorizontalOptions = LayoutOptions.Center;
                        label.FontSize = 28;
                        label.FontFamily = "Roboto";
                        label.TextColor = Color.White;
                        label.FontAttributes = FontAttributes.Bold;
                        AbsoluteLayout.SetLayoutBounds(label, new Rectangle(0, 270, 240, 50));
                        absoluteLayout.Children.Add(label);

                        grid.Children.Add(absoluteLayout, 2, rowNumber);

                    }
                }
                rowNumber++;
            }
            stack.Children.Add(grid);
            scrollView.Content = stack;
        }
    }
}