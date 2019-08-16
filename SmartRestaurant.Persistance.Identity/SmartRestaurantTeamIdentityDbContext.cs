using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.BaseIdentity;
using SmartRestaurant.Persistance.Identity.Configuration;
using SmartRestaurant.Persistance.Identity.GuestConfiguration;
using SmartRestaurant.Persistance.Identity.TeamConfiguration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartRestaurant.Persistance.Identity
{
    public class SmartRestaurantTeamIdentityDbContext :IdentityDbContext<
           BaseIdentityUser,
           BaseIdentityRole,
            string,
           BaseIdentityUserClaim,
           BaseIdentityUserRole,
           BaseIdentityUserLogin,
           BaseIdentityRoleClaim,
           BaseIdentityUserToken>
    {

        private string strConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SRTeamIdentitydb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public SmartRestaurantTeamIdentityDbContext()
        {

        }
        public SmartRestaurantTeamIdentityDbContext(DbContextOptions<SmartRestaurantTeamIdentityDbContext> options)
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

            modelBuilder.Entity<BaseIdentityUser>(new BaseIdentityUserConfiguration().Configure);
            modelBuilder.Entity<BaseIdentityUserClaim>(new BaseIdentityUserClaimConfiguration().Configure);
            modelBuilder.Entity<BaseIdentityUserLogin>(new BaseIdentityUserLoginConfiguration().Configure);
            modelBuilder.Entity<BaseIdentityUserToken>(new BaseIdentityUserTokenConfiguration().Configure);
            modelBuilder.Entity<BaseIdentityRole>(new BaseIdentityRoleConfiguration().Configure);
            modelBuilder.Entity<BaseIdentityRoleClaim>(new BaseIdentityRoleClaimConfiguration().Configure);
            modelBuilder.Entity<BaseIdentityUserRole>(new BaseIdentityUserRoleConfiguration().Configure);


        }



    }
}
