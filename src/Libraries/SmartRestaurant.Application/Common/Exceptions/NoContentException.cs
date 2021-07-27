namespace SmartRestaurant.Application.Common.Exceptions
{
    public class NoContentException : BaseException
    {
        public NoContentException() : base(204)
        {
        }

        public NoContentException(string message) : base(204, message)
        {
        }
    }
}