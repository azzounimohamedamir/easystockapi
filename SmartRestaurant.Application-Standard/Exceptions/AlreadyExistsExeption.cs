using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Exceptions
{
    public class AlreadyExistsExeption:Exception
    {
        public AlreadyExistsExeption(string message):base(message)
        {

        }
        public AlreadyExistsExeption(string message,Exception ex):base(message,ex)
        {
                
        }
    }
}
