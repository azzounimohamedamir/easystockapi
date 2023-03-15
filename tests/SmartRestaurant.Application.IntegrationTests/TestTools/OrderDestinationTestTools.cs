using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.OrderDestination.Commands;
using SmartRestaurant.Application.Reclamation.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.TypeReclamation.Commands;
using SmartRestaurant.Application.Zones.Commands;
using SmartRestaurant.Domain.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;
    public class OrderDestinationTestTools
    {
        public static async Task<CreateOrderDestinationCommand> CreateOrderDestination( Guid hotelId)
        {

            var creatOrderDestinationcommand = new CreateOrderDestinationCommand
            {
                HotelId = hotelId,
                Names = new NamesDto() { AR = "خدمات صحية", EN = "Healthy Service", FR = "Healthy Service", TR = "Healthy Service", RU = "Healthy Service" },
            };
            await SendAsync(creatOrderDestinationcommand);
            return creatOrderDestinationcommand;
        }

       
    }
}
