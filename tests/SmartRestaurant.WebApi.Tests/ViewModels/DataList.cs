using System.Collections.Generic;

namespace SmartRestaurant.WebApi.Tests.ViewModels
{
    public class DataList<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int RowCount { get; set; }
        public List<T> Data { get; set; }
    }
}