using SmartRestaurant.Application.Common.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Application.GestionStock.Stock.Commands
{
    public class AddProductToFavorite : UpdateCommand
    {
        public Guid Id { get; set; }
    }
}
