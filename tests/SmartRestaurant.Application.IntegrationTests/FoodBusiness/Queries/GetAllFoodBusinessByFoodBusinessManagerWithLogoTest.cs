using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.FoodBusiness.Queries;
using SmartRestaurant.Application.Images.Commands;
using SmartRestaurant.Application.Images.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using SmartRestaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.FoodBusiness.Queries
{
    using static Testing;

    [TestFixture]
    public class GetAllFoodBusinessByFoodBusinessManagerWithLogoTest : TestBase
    {
        MultipartFormDataContent formDataContent;
        MemoryStream stream;
        MemoryStream castStream;
        StreamContent file1;

        [SetUp]
        public void Setup()
        {
            var foodImage = Properties.Resources.food;
            formDataContent = new MultipartFormDataContent();
            stream = new MemoryStream(foodImage);
            file1 = new StreamContent(stream);
        }

        [TearDown]
        public void TearDown()
        {
            if (formDataContent != null)
                formDataContent.Dispose();

            if (stream != null)
                stream.Dispose();

            if (castStream != null)
                castStream.Dispose();

            if (file1 != null)
                file1.Dispose();
        }

        [Test]
        public async Task WhenUploadLogoInFoodBuisenessSholdBeGetInThePayLoadOfFoodBuisness()
        {
            await RolesTestTools.CreateRoles();
   
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var tacosDz1 = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id, "tacos Dz 01");
            var tacosDz2 = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id, "tacos Dz 02");
            var aissaFoodBusinessManager = _authenticatedUserId;
            var assignAissaFoodBusinessManagerToTacosDz1 = new FoodBusinessUser
            {
                ApplicationUserId = aissaFoodBusinessManager,
                FoodBusinessId = tacosDz1.FoodBusinessId
            };
            await AddAsync(assignAissaFoodBusinessManagerToTacosDz1);

            var assignAissaFoodBusinessManagerToTacosDz2 = new FoodBusinessUser
            {
                ApplicationUserId = aissaFoodBusinessManager,
                FoodBusinessId = tacosDz2.FoodBusinessId
            };
            await AddAsync(assignAissaFoodBusinessManagerToTacosDz2);
            
            CreateFakeMultiPartFormData(tacosDz1);

            var uploadLogoCommand = CastMultiPartFormData();

            await SendAsync(uploadLogoCommand).ConfigureAwait(false);
            
            var result = await SendAsync(new GetAllFoodBusinessByFoodBusinessManagerQuery());

            foreach (var foodBuiseness in result)
            {
                if(foodBuiseness.Name=="tacos Dz 01")
                {
                    foodBuiseness.Logo.Should().NotBeNull();
                }
                if (foodBuiseness.Name == "tacos Dz 02")
                {
                    foodBuiseness.Logo.Should().BeNull();
                }
            }
        }

        private UploadLogoCommand CastMultiPartFormData()
        {
            var uploadLogoCommand = new UploadLogoCommand();

            foreach (var dataContent in formDataContent)
            {
                var name = dataContent.Headers.ContentDisposition.Name;
                var value = dataContent.ReadAsStringAsync().Result;
                switch (name)
                {
                    case "logo":
                        byte[] imageBytes = Encoding.Unicode.GetBytes(value);
                        castStream = new MemoryStream(imageBytes);
                        uploadLogoCommand.Logo = new FormFile(castStream, 0, imageBytes.Length, "logo", "food.png");
                        break;

                    case "entityId":
                        uploadLogoCommand.EntityId = value;
                        break;

                    case "entityName":
                        uploadLogoCommand.EntityName = value;
                        break;
                }
            }
            return uploadLogoCommand;
        }

        private void CreateFakeMultiPartFormData(Domain.Entities.FoodBusiness fastFood)
        {
            file1.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            file1.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
            file1.Headers.ContentDisposition.FileName = "food.png";
            file1.Headers.ContentDisposition.Name = "logo";
            formDataContent.Add(file1);
            formDataContent.Add(new StringContent(fastFood.FoodBusinessId.ToString()), name: "entityId");
            formDataContent.Add(new StringContent(UploadImagesEntities.FoodBusiness), name: "entityName");
        }
    }
}
