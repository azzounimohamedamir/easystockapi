using System.Collections.Generic;

namespace SmartRestaurant.Client.Web.Models.Utils
{
    public class DeleteEntityViewModel
    {
        public DeleteEntityViewModel()
        {
            Error = new DeleteEntityErrorViewModel();
            Args = new List<string>();
        }
        public List<string> Args { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public bool HasError { get; set; } = false;
        public DeleteEntityErrorViewModel Error { get; set; }
    }
    public class DeleteEntityErrorViewModel
    {
        public string Message { get; set; }
    }
}
