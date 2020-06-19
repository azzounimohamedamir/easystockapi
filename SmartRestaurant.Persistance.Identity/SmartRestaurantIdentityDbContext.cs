using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Clients.Identity;
using SmartRestaurant.Persistance.Identity.Configuration;

namespace SmartRestaurant.Persistance.Identity
{
    public class SmartRestaurantIdentityDbContext :
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


        public SmartRestaurantIdentityDbContext(DbContextOptions options)
            : base(options)
        {
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
