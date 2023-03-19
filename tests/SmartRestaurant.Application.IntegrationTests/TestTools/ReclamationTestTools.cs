using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Menus.Commands;
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
    public class ReclamationTestTools
    {
        public static async Task<CreateTypeReclamationCommand> CreateTypeReclamation(string name,Guid hotelId,Guid serviceTechniqueId)
        {

            var createtypereclamationcommand = new CreateTypeReclamationCommand
            {
                HotelId=hotelId,
                Names = new NamesDto() { AR = "عطل", EN = "panne", FR = "panne", TR = "panne", RU = "panne" },
                Name = name,
                Delai=5,
                ServiceTechniqueId=serviceTechniqueId
            };
            await SendAsync(createtypereclamationcommand);
            return createtypereclamationcommand;
        }

        public static async Task<Domain.Entities.Reclamation> CreateReclamation(string checkinId ,string clientId , Guid hotelId , string roomId , DateTime reclamationTime , Guid typereclamationId)
        {


            var createreclamationcommand = new CreateReclamationCommand
            {
                ClientId = clientId,
                CheckinId = checkinId,
                RoomId = roomId,
                CreatedAt = reclamationTime,
                TypeReclamationId = typereclamationId.ToString(),
                
                ReclamationDescription = new NamesDto() { AR = "عطل", EN = "panne", FR = "panne", TR = "panne", RU = "panne" },
                Status=ReclamationStatus.NotResolved
    };

            byte[] imageBytes = Properties.Resources.food;
            using (var castStream = new MemoryStream(imageBytes))
            {
                createreclamationcommand.Picture = new FormFile(castStream, 0, imageBytes.Length, "logo", "climatiseur.png");
                await SendAsync(createreclamationcommand);
            };
            var reclamation = await FindAsync<Domain.Entities.Reclamation>(createreclamationcommand.Id);
            return reclamation;
          
        }
    }
}
