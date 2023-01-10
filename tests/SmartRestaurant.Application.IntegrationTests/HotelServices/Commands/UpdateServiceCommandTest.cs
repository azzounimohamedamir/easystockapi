using NUnit.Framework;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SmartRestaurant.Domain.Entities;
using SmartRestaurant.Application.HotelServices.Commands;
using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Domain.Enums;
using SmartRestaurant.Domain.ValueObjects;
using FluentAssertions;

namespace SmartRestaurant.Application.IntegrationTests.HotelServices.Commands
{
    using static Testing;

    [TestFixture]
    public class UpdateServiceCommandTest:TestBase
    {
        [Test]

        public async Task UpdateServiceTest()
        {
            var service = await HotelServicesTestTools.createHotelService();
            var query = await updateService(service);

            var editedService = await FindAsync<HotelService>(service.Id);
            editedService.Should().NotBeNull();
            editedService.Names.Should().BeEquivalentTo(query.Names);
            editedService.Id.Should().Be(query.Id);
         

        }

        public static async Task<UpdateHotelServiceCommand> updateService(HotelService service)
        {
            var command = new UpdateHotelServiceCommand
            {
               SectionId = new Guid("3cbf3570-4444-4673-8746-29b7cf568093"),
               Id = service.Id,
                Names=new Names() {
    
                AR = "updated",
                EN = "updated",
                FR = "updated",
                TR = "updated",
                RU = "updated"
                },
                isSmartrestaurantMenue= false,
                DetailServce= new Names(){
                AR= "رحلة بالقارب",
                EN= "Boat trip",
                FR= "francais",
                TR= "Picanto",
                RU= "прокат автомобилей"
                },
            TitelSeccesResponce= new Names() {
                 AR= "رحلة بالقارب",
                 EN= "sss55",
                FR= "Balade en mer premiere classe",
                TR= "Araba kiralama",
                RU= "Picanto"
            },
            TitelFailureResponce= new Names(){
                 AR= "azz",
                EN = "Boat trip",
                FR= "Balade en mer",
                TR= "turque",
                RU= "Picanto"
            },
                Parametres = new List<CreateServiceParametreDto>()
            };

            var parametre = new CreateServiceParametreDto()
            {
                IsRequired = true,
                IsShowing = true,
                Names = new Names()
                {
                    AR = "updated",
                    FR = "updated",
                    EN = "updated",
                    TR = "updated",
                    RU = "updated"
                },
                ServiceParametreType = ServiceParametreType.Date
            };

             await SendAsync(command);

            return command;
        }
    }
}
