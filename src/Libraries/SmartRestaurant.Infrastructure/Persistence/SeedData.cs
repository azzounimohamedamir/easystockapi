using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Entities;
using System;

namespace SmartRestaurant.Infrastructure.Persistence
{
    public static class SeedData
    {

        public static void Seed(this ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Client>().HasData(new Client
            {
                Id = Guid.Parse("52a857b7-ee3c-42db-96a7-76d3042818ac"),
                RaisonSociale = "Client Anonyme",
                Commerce = "Client Comptoir",
                Email = "guest-client@gmail.com",
                DateEcheance = DateTime.Now.AddYears(10),
                IsDisabled = false,
                Addresse = "",
                FullName = "Client Comptoir",
                IsBanned = false,
                Nic = 45421845214,
                Nif = 845784545,
                Nrc = 548512451,
                Numarticle = 0,
                Tel = "0561596837",
                TotalAvances = 0,
                TotalCredits = 0
            });


        }

    }
}
    
