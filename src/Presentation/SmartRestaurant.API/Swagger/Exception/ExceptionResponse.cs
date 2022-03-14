using System.Collections.Generic;

namespace SmartRestaurant.API.Swagger.Exception
{
    public class ExceptionResponse
    {
        public string Message { get; set; }
        public IList<string> Errors { get; set; }
    }
}