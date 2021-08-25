using System;
using System.Collections.Generic;
using SmartRestaurant.Infrastructure.Persistence;
using Swashbuckle.AspNetCore.Filters;

namespace SmartRestaurant.API.Swagger.Examples.Reservation
{
    public class CreateReservationCommandForSwaggerExamples
    {
        public string ReservationName { get; set; }
        public int NumberOfDiners { get; set; }
        public DateTime ReservationDate { get; set; }
        public Guid FoodBusinessId { get; set; }
        public string CreatedBy { get; set; }
    }

    public class
        CreateReservationCommandExamples : IMultipleExamplesProvider<CreateReservationCommandForSwaggerExamples>
    {
        public IEnumerable<SwaggerExample<CreateReservationCommandForSwaggerExamples>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "FoodBusinessManager creates a reservation for (Aissa) in BigMama restaurant.",
                new CreateReservationCommandForSwaggerExamples
                {
                    ReservationName = "_Aissa_",
                    NumberOfDiners = 6,
                    ReservationDate = DateTime.Now.AddDays(3),
                    FoodBusinessId = Guid.Parse(SeedData.BigMama_FoodBusinessId),
                    CreatedBy = SeedData.BigMama_SalimFoodBusinessManager_UserId
                }
            );
            yield return SwaggerExample.Create(
                "FoodBusinessManager creates a reservation for (Kamel) in Mcdonald restaurant.",
                new CreateReservationCommandForSwaggerExamples
                {
                    ReservationName = "_Kamel_",
                    NumberOfDiners = 3,
                    ReservationDate = DateTime.Now.AddDays(1),
                    FoodBusinessId = Guid.Parse(SeedData.Mcdonald_FoodBusinessId),
                    CreatedBy = SeedData.Mcdonald_FoodBusinessManager_UserId
                }
            );
            yield return SwaggerExample.Create(
                "Client (Amine) creates a reservation in TajMhal restaurant.",
                new CreateReservationCommandForSwaggerExamples
                {
                    ReservationName = "_Amine_",
                    NumberOfDiners = 2,
                    ReservationDate = DateTime.Now.AddHours(2),
                    FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                    CreatedBy = SeedData.Diner_UserId_01
                }
            );
            yield return SwaggerExample.Create(
                "Client (Salim) creates a reservation in TajMhal restaurant.",
                new CreateReservationCommandForSwaggerExamples
                {
                    ReservationName = "_Salim_",
                    NumberOfDiners = 4,
                    ReservationDate = DateTime.Now.AddDays(1),
                    FoodBusinessId = Guid.Parse(SeedData.TajMhal_FoodBusinessId),
                    CreatedBy = SeedData.Diner_UserId_02
                }
            );
        }
    }
}