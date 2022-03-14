using SmartRestaurant.Application.Common.Enums;

namespace SmartRestaurant.API.Helpers
{
    public class JsonResponseModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

    public class HttpResponseHelper
    {
        public static JsonResponseModel Respond(ResponseType response)
        {
            return new JsonResponseModel
            {
                StatusCode = (int) response,
                Message = response.ToString()
            };
        }
    }
}