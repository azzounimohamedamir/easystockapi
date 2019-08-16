using System;
using Xamarin.Forms;

namespace SmartRestaurant.Forms.Helpers
{
   

   /// <summary>
    /// try to implement a custome stepper 
    /// </summary>
        public class CustomStepper : StackLayout
        {

        Image PlusBtn;
        Image MinusBtn;
            Entry Entry;
            StackLayout bttcontainer; 

            public static readonly BindableProperty TextProperty =
              BindableProperty.Create(
                 propertyName: "Text",
                  returnType: typeof(int),
                  declaringType: typeof(CustomStepper),
                  defaultValue: 0,
                  defaultBindingMode: BindingMode.TwoWay);

            public int Text
            {
                get { return (int)GetValue(TextProperty); }
                set { SetValue(TextProperty, value); }
            }
            public CustomStepper()
            {
                PlusBtn = new Image { WidthRequest = 5  };
                MinusBtn = new Image { WidthRequest = 5};
                bttcontainer = new StackLayout();
                PlusBtn.Source = "plus.png";
                MinusBtn.Source = "minus.png";
             
                switch (Device.RuntimePlatform)
                {
                    case Device.UWP:
                    case Device.Android:
                        {
                        PlusBtn.BackgroundColor = Color.Transparent;
                        MinusBtn.BackgroundColor = Color.Transparent;
                        break;
                        }
                    case Device.iOS:
                        {
                        PlusBtn.BackgroundColor = Color.Transparent;
                        MinusBtn.BackgroundColor = Color.Transparent;
                        break;
                        }
                }
          Orientation = StackOrientation.Horizontal;
         bttcontainer.Orientation = StackOrientation.Vertical;
         bttcontainer.BackgroundColor = Color.Yellow;
         bttcontainer.Margin = new Thickness(20, 20);
            

            var tabreconize = new TapGestureRecognizer(); 
            tabreconize.Tapped += PlusBtn_Clicked;
            var tabreconize2 = new TapGestureRecognizer();
            tabreconize2.Tapped += MinusBtn_Clicked;
            PlusBtn.GestureRecognizers.Add(tabreconize);
            MinusBtn.GestureRecognizers.Add(tabreconize2);

          
                Entry = new Entry { PlaceholderColor = Color.Gray, Keyboard = Keyboard.Numeric, WidthRequest = 200, BackgroundColor = Color.Transparent, FontSize = 24   };
                Entry.Keyboard = Keyboard.Numeric;
               // Entry.Behaviors.Add(new NumericValidationBehavior());
                Entry.SetBinding(Entry.TextProperty, new Binding(nameof(Text), BindingMode.TwoWay, source: this));
                Entry.HorizontalTextAlignment = TextAlignment.Center;
          
            Entry.TextChanged += Entry_TextChanged;
            // add in vertical line 
            //var box = new BoxView();
            //box.HeightRequest = 5;
            //box.WidthRequest = 2;
            //box.BackgroundColor = Color.Transparent;
                bttcontainer.Children.Add(PlusBtn);
            //bttcontainer.Children.Add(box);
                bttcontainer.Children.Add(MinusBtn);
                //Children.Add(MinusBtn);
                Children.Add(Entry);
                Children.Add(bttcontainer); 
                //Children.Add(PlusBtn);
            }
            private void Entry_TextChanged(object sender, TextChangedEventArgs e)
            {
                if (!string.IsNullOrEmpty(e.NewTextValue) && e.NewTextValue != ".")
                    this.Text = int.Parse(e.NewTextValue);
            }

            private void MinusBtn_Clicked(object sender, EventArgs e)
            {
                if (Text > 0)
                    Text--;
            }

            private void PlusBtn_Clicked(object sender, EventArgs e)
            {
                Text++;
            }

        }
    }

