namespace SmartRestaurant.Application.Common.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException() : base(401, "Unauthorized")
        {
        }
    }
}