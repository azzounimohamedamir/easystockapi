using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Models
{
    public class BodyModelView<T>
    {
        public string ViewName { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public SearchFilter<T> Filter { get; set; }
        public List<T> Items { get; set; }
        public T Model { get; set; }
    }
}