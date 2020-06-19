using Android.Content;
using Android.Views;
using Android.Widget;
using SmartRestaurant.Diner.Droid.CustomControlsRenderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ScrollView), typeof(RtlFixScrollViewRenderer))]
namespace SmartRestaurant.Diner.Droid.CustomControlsRenderers
{
    public class RtlFixScrollViewRenderer : ScrollViewRenderer
    {
        LayoutDirection currentDirection;

        public RtlFixScrollViewRenderer(Context context) : base(context)
        {
            currentDirection = LayoutDirection;
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            UpdateFlowDirection();

            if (e.OldElement != null)
            {
                e.OldElement.PropertyChanged -= OnElementPropertyChanged;
            }

            if (e.NewElement != null)
            {
                e.NewElement.PropertyChanged += OnElementPropertyChanged;
            }
        }

        private void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == VisualElement.FlowDirectionProperty.PropertyName)
            {
                UpdateFlowDirection();
            }
        }

        void UpdateFlowDirection()
        {
            if (Element is IVisualElementController controller)
            {
                Rtl = controller.EffectiveFlowDirection.IsRightToLeft();
                LayoutDirection = controller.EffectiveFlowDirection.IsLeftToRight()
                    ? LayoutDirection.Ltr
                    : LayoutDirection.Rtl;
            }
        }
        bool Rtl;
        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            base.OnLayout(changed, left, top, right, bottom);

            if (Element is Xamarin.Forms.ScrollView scrollView && (scrollView.Orientation == ScrollOrientation.Horizontal || scrollView.Orientation == ScrollOrientation.Both))
            {
                if (Rtl)
                {

                    var horizontal = (HorizontalScrollView)GetChildAt(0);
                    var container = (ViewGroup)horizontal.GetChildAt(0);


                    if (container.ChildCount == 1)
                    {
                        var content = (ViewGroup)container.GetChildAt(0);
                        var desiredWidth = content.Width;

                        container.Layout(0, 0, content.Width, content.Height);
                        content.Layout(0, 0, desiredWidth, content.Height);
                    }



                    horizontal.ScrollX = container.Right;
                    Rtl = false;
                }
            }
        }
    }
}
