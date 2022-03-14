using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string name, object key) : base(404, "Not found error")
        {
            Errors = new List<string> { $"Entity \"{name}\" ({key}) was not found." };
        }
    }
}