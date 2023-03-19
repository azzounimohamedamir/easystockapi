using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Menus.Commands;
using SmartRestaurant.Application.Reclamation.Commands;
using SmartRestaurant.Application.Sections.Commands;
using SmartRestaurant.Application.ServiceTechniqueDestination.Commands;
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
    public class ServiceTechniqueTestTools
    {
        public static async Task<CreateServiceTechniqueCommand> CreateServiceTechnique(Guid hotelId)
        {

            var createServiceTechniquecommand = new CreateServiceTechniqueCommand
            {
                HotelId=hotelId,
                Names = new NamesDto() { AR = "الترصيص و الصيانة", EN = "Plomberie", FR = "Plomberie", TR = "Plomberie", RU = "Plomberie" },
            };
            await SendAsync(createServiceTechniquecommand);
            return createServiceTechniquecommand;
        }

       
    }
}
