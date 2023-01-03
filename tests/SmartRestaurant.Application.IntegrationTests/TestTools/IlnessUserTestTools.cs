using SmartRestaurant.Application.Common.Dtos;
using SmartRestaurant.Application.Illness.Commands;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.TestTools
{
    using static Testing;
    public class IllnessUserTestTools
    {
        public static async Task<CreateIllnessUserCommand> CreateIllnessUser(List<string> ilnessIds)
        {
            var IllnessUser = new CreateIllnessUserCommand
            {
                IllnessIds = ilnessIds
            };
            await SendAsync(IllnessUser);


            return IllnessUser;
        }
    }
}
