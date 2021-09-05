using System.Collections.Generic;

namespace SmartRestaurant.Application.Common.Exceptions
{
    public class RolesCheckException : BaseException
    {
        public RolesCheckException(string error) : base(422, "Roles checking failed")
        {
            Errors = new List<string> { error };
        }
    }
}