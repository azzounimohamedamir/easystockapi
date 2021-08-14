using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.API.Swagger.Exception
{
    public class ExceptionResponse
    {
        public string Message { get; set; }
        public IList<string> Errors { get; set; }
    }
}
