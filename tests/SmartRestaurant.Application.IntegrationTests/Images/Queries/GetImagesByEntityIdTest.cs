using FluentAssertions;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using SmartRestaurant.Application.Common.Enums;
using SmartRestaurant.Application.Images.Commands;
using SmartRestaurant.Application.Images.Queries;
using SmartRestaurant.Application.IntegrationTests.TestTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmartRestaurant.Application.IntegrationTests.Images.Commands
{
    using static Testing;

    [TestFixture]
    public class GetImagesByEntityIdTest : TestBase
    {
        MultipartFormDataContent formDataContent;
        MemoryStream stream1;
        MemoryStream castStream1;
        StreamContent file1;

        MemoryStream stream2;
        MemoryStream castStream2;
        StreamContent file2;
        byte[] foodImage1 = Properties.Resources.food;
        byte[] foodImage2 = Properties.Resources.food_business;


        [SetUp]
        public void Setup()
        {
            formDataContent = new MultipartFormDataContent();
            stream1 = new MemoryStream(foodImage1);
            file1 = new StreamContent(stream1);

            stream2 = new MemoryStream(foodImage2);
            file2 = new StreamContent(stream2);
        }

        [TearDown]
        public void TearDown()
        {
            if (formDataContent != null)
                formDataContent.Dispose();

            if (stream1 != null)
                stream1.Dispose();

            if (castStream1 != null)
                castStream1.Dispose();

            if (file1 != null)
                file1.Dispose();

            if (stream2 != null)
                stream2.Dispose();

            if (castStream2 != null)
                castStream2.Dispose();

            if (file2 != null)
                file2.Dispose();
        }

        [Test]
        public async Task ShouldGetListOfImagesByEntityId()
        {
            await RolesTestTools.CreateRoles();
            var foodBusinessAdministrator = await UsersTestTools.CreateFoodBusinessAdministrator();
            var fastFood = await FoodBusinessTestTools.CreateFoodBusiness(foodBusinessAdministrator.Id);
       
            CreateFakeMultiPartFormData(fastFood);
            var uploadListOfImagesCommand = CastMultiPartFormData();
            await SendAsync(uploadListOfImagesCommand).ConfigureAwait(false);


            var getImagesByEntityIdQuery = new GetImagesByEntityIdQuery
            {
                EntityId = fastFood.FoodBusinessId.ToString(),
                EntityName = UploadImagesEntities.FoodBusiness
            };
            var images = await SendAsync(getImagesByEntityIdQuery).ConfigureAwait(false);
            images.Should().NotBeNull();
            images.Should().HaveCount(2);
           
            foreach (var image in images)
            {
                Assert.True(IsBase64(image), "image must be in format of Base64 ");
            }    
        }

        private UploadListOfImagesCommand CastMultiPartFormData()
        {
            var uploadListOfImagesCommand = new UploadListOfImagesCommand();
            uploadListOfImagesCommand.Images = new List<IFormFile>();

            foreach (var dataContent in formDataContent)
            {
                var name = dataContent.Headers.ContentDisposition.Name;
                var value = dataContent.ReadAsStringAsync().Result;

                switch (name)
                {
                    case "images":
                        byte[] imageBytes = Encoding.Unicode.GetBytes(value);
                        var fileName = dataContent.Headers.ContentDisposition.FileName;
                        if (fileName == "food.png")
                        {
                            castStream1 = new MemoryStream(imageBytes);
                            var iamge1 = new FormFile(castStream1, 0, imageBytes.Length, name, fileName);
                            uploadListOfImagesCommand.Images.Add(iamge1);
                        }
                        else
                        {
                            castStream2 = new MemoryStream(imageBytes);
                            var iamge2 = new FormFile(castStream2, 0, imageBytes.Length, name, fileName);
                            uploadListOfImagesCommand.Images.Add(iamge2);
                        }
                    break;

                    case "entityId":
                        uploadListOfImagesCommand.EntityId = value;
                    break;

                    case "entityName":
                        uploadListOfImagesCommand.EntityName = value;
                    break;
                }
            }
            return uploadListOfImagesCommand;
        }

        private  void CreateFakeMultiPartFormData(Domain.Entities.FoodBusiness fastFood)
        {
            file1.Headers.ContentType = new MediaTypeHeaderValue("image/png");
            file1.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
            file1.Headers.ContentDisposition.FileName = "food.png";
            file1.Headers.ContentDisposition.Name = "images";
            formDataContent.Add(file1);

            file2.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");
            file2.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data");
            file2.Headers.ContentDisposition.FileName = "food_business.jpg";
            file2.Headers.ContentDisposition.Name = "images";
            formDataContent.Add(file2);

            formDataContent.Add(new StringContent(fastFood.FoodBusinessId.ToString()), name: "entityId");
            formDataContent.Add(new StringContent(UploadImagesEntities.FoodBusiness), name: "entityName");
        }

        private bool IsBase64(string base64String)
        {
            // Credit: oybek https://stackoverflow.com/users/794764/oybek
            if (string.IsNullOrEmpty(base64String) || base64String.Length % 4 != 0
               || base64String.Contains(" ") || base64String.Contains("\t") || base64String.Contains("\r") || base64String.Contains("\n"))
                return false;

            try
            {
                Convert.FromBase64String(base64String);
                return true;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }


 
}
