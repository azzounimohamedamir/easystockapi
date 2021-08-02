namespace SmartRestaurant.Application.Common.WebResults
{
    public class BaseWebResult
    {
        public BaseWebResult(int statusCode)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; set; }
    }
}