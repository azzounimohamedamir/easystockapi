using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.Exceptions
{
    /// <summary>
    /// ce produit lors de tentative de suppression d'un element 
    /// qui à des elments ou enfants
    /// </summary>
    public class NestedDeleteException: Exception
    {
        public NestedDeleteException()
        {

        }
        public NestedDeleteException(string message) : base(message)
        {

        }

    }
}
