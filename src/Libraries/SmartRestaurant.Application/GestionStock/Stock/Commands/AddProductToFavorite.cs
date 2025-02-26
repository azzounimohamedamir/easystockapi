using SmartRestaurant.Application.Common.Commands;
using System;

namespace SmartRestaurant.Application.GestionStock.Stock.Commands
{
    public class AddProductToFavorite : UpdateCommand
    {
        public Guid Id { get; set; }
    }
}
