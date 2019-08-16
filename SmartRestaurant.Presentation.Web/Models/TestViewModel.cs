using SmartRestaurant.Resources.SharedValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Presentation.Web.Models
{
    public class TestViewModel
    {
        //[Range(1, 10)]
        public decimal ADecimal { get; set; }
    }

    public class TestViewModelMetaTypeProvider
    {
        [Required(AllowEmptyStrings = false,
             ErrorMessageResourceName = "Required",
             ErrorMessageResourceType = typeof(SharedValidationResource))]
        //[Range(1, 10)]
        public decimal ADecimal { get; set; }
    }
}
