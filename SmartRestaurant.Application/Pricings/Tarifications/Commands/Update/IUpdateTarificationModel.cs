using System.Collections.Generic;
using SmartRestaurant.Application.Helpers;
using SmartRestaurant.Application.Pricings.Tarifications.Commands.Create;

namespace SmartRestaurant.Application.Pricings.Tarifications.Commands.Update
{
    public interface IUpdateTarificationModel : ICreateTarificationModel
    {
        string Id { get; set; }
       
    }
}