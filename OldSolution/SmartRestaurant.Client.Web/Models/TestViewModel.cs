using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
