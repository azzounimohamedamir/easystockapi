﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Exceptions
{
    public class ApplicationGlobalException:Exception
    {
        public ApplicationGlobalException():base()
        {

        }
        public ApplicationGlobalException(string message,Exception ex) : base(message,ex)
        {

        }
    }
}
