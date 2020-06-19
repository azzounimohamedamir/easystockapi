using Microsoft.AspNetCore.Mvc.Rendering;

namespace SmartRestaurant.Client.Web.Models.Commun
{
    public class SelectUnitModel
    {
        public SelectUnitModel()
        {

        }
        public SelectUnitModel(SelectList units, string text)
        {
            Units = units;
            Text = text;
        }
        public SelectList Units { get; set; }
        public string Text { get; set; }
    }
}
