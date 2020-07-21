using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Droid.CustomControlsRenderers;
using Xamarin.Forms;

[assembly: Dependency(typeof(CheckFilePermission))]
namespace SmartRestaurant.Diner.Droid.CustomControlsRenderers
{
    public class CheckFilePermission : ICheckFilePermission
    {
        MainActivity mainActivity;

        public bool CheckPermission()
        {
            mainActivity = (SmartRestaurant.Diner.Droid.MainActivity)App.ParentWindow;
            if (mainActivity.CheckAppPermissions())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}  