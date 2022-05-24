using SmartRestaurant.Application.Common.Dtos.ValueObjects;
using SmartRestaurant.Application.Zones.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;
    public class ZoneTestTools
    {

        public static async Task<CreateZoneCommand> CreateZone(Domain.Entities.FoodBusiness fastFood,string Title= "zone 45",bool withDeffirentTranslation=false)
        {
            var createZoneCommand = new CreateZoneCommand
            {
                FoodBusinessId = fastFood.FoodBusinessId,
                ZoneTitle = Title,
                Names = new NamesDto() { 
                    AR = withDeffirentTranslation ? Title + "AR":"AR", 
                    EN = withDeffirentTranslation ? Title + "EN" : "EN",
                    FR = withDeffirentTranslation ? Title + "FR" : "FR",
                    TR = withDeffirentTranslation ? Title + "TR" : "TR",
                    RU = withDeffirentTranslation ? Title + "RU" : "RU"},
            };
            await SendAsync(createZoneCommand);
            return createZoneCommand;
        }
    }
}
