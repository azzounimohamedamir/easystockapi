namespace SmartRestaurant.WebApi.Tests.ViewModels
{
    public class ApiResult<T> where T : class
    {
        public int StatusCode { get; set; }
        public T Content { get; set; }
    }
}