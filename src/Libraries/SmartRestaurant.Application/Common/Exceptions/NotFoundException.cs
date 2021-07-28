namespace SmartRestaurant.Application.Common.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException() : base(404)
        {
        }

        public NotFoundException(string name, object key)
            : base(404, $"Entity \"{name}\" ({key}) was not found.")
        {
        }
    }
}