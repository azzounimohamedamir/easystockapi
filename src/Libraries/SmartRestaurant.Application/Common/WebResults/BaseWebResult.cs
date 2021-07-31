namespace SmartRestaurant.Application.Common.WebResults
{
    public class BaseWebResult
    {
        public int StatusCode { get; set; }

        public BaseWebResult(int statusCode)
        {
            StatusCode = statusCode;
        }
    }
}