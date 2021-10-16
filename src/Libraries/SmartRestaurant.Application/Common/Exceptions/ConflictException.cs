namespace SmartRestaurant.Application.Common.Exceptions
{
    public class ConflictException : BaseException
    {
        public ConflictException(string message) : base(409, "Conflict")
        {
            Errors.Add(message);
        }
    }  
}