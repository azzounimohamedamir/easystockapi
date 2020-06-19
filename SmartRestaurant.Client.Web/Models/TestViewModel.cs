using System.ComponentModel.DataAnnotations;

namespace SmartRestaurant.Client.Web.Models
{
    public class TestViewModel
    {
        [Range(1, 10)]
        public decimal ADecimal { get; set; }
    }

    public class TestViewModelMetaTypeProvider
    {
        [Range(1, 10)]
        public decimal ADecimal { get; set; }
    }
}
