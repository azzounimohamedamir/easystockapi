using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartRestaurant.Domain.Identity.Guests;
using SmartRestaurant.Persistance.Identity.GuestConfiguration;

namespace SmartRestaurant.Persistance.Identity
{
    public class SmartRestaurantGuestIdentityDbContext : IdentityDbContext<
            GuestIdentityUser,
            GuestIdentityRole,
            string,
            GuestIdentityUserClaim,
            GuestIdentityUserRole,
            GuestIdentityUserLogin,
            GuestIdentityRoleClaim,
            GuestIdentityUserToken>
    {
        //        private string strConnection = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SRGuestIdentitydb1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public SmartRestaurantGuestIdentityDbContext()
        {

        }
        public SmartRestaurantGuestIdentityDbContext(DbContextOptions<SmartRestaurantGuestIdentityDbContext> options)
            : base(options)
        {
        }

        //Utilisé uniquement pour générée une migration
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //Une seule fois juste pour généré la migration
        //    optionsBuilder.UseSqlServer(strConnection);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<GuestIdentityUser>(new GuestIdentityUserConfiguration().Configure);
            modelBuilder.Entity<GuestIdentityUserClaim>(new GuestIdentityUserClaimConfiguration().Configure);
            modelBuilder.Entity<GuestIdentityUserLogin>(new GuestIdentityUserLoginConfiguration().Configure);
            modelBuilder.Entity<GuestIdentityUserToken>(new GuestIdentityUserTokenConfiguration().Configure);
            modelBuilder.Entity<GuestIdentityRole>(new GuestIdentityRoleConfiguration().Configure);
            modelBuilder.Entity<GuestIdentityRoleClaim>(new GuestIdentityRoleClaimConfiguration().Configure);
            modelBuilder.Entity<GuestIdentityUserRole>(new GuestIdentityUserRoleConfiguration().Configure);


        }
    }
}
