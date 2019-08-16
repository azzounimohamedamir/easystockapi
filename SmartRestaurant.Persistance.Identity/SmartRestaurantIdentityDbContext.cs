using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Clients.Identity;
using SmartRestaurant.Persistance.Identity.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistance.Identity
{
    public class SmartRestaurantIdentityDbContext:
        IdentityDbContext<
            SRIdentityUser,
            SRIdentityRole,
            string,
            SRIdentityUserClaim,
            SRIdentityUserRole,
            SRIdentityUserLogin,
            SRIdentityRoleClaim,
            SRIdentityUserToken>
    {
        private string strConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SRIdentitydb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //pour la migration
        public SmartRestaurantIdentityDbContext()
        {

        }
        
        public SmartRestaurantIdentityDbContext(DbContextOptions<SmartRestaurantIdentityDbContext> options)
            : base(options)
        {
        }

        //Utilisé uniquement pour générée une migration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Une seule fois juste pour généré la migration
            optionsBuilder.UseSqlServer(strConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SRIdentityUser>(new SRIdentityUserConfiguration().Configure);
            modelBuilder.Entity<SRIdentityUserClaim>(new SRIdentityUserClaimConfiguration().Configure);
            modelBuilder.Entity<SRIdentityUserLogin>(new SRIdentityUserLoginConfiguration().Configure);
            modelBuilder.Entity<SRIdentityUserToken>(new SRIdentityUserTokenConfiguration().Configure);
            modelBuilder.Entity<SRIdentityRole>(new SRIdentityRoleConfiguration().Configure);
            modelBuilder.Entity<SRIdentityRoleClaim>(new SRIdentityRoleClaimConfiguration().Configure);
            modelBuilder.Entity<SRIdentityUserRole>(new SRIdentityUserRoleConfiguration().Configure);

            
        }
    }
}
