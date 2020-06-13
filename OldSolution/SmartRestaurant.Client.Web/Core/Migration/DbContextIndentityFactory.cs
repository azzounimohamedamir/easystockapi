using System.Diagnostics;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Persistance.Identity;

namespace SmartRestaurant.Client.Web.Core.Migration
{
    public class DbContextIndentityFactory : IDesignTimeDbContextFactory<SmartRestaurantTeamIdentityDbContext>
    {
        public SmartRestaurantTeamIdentityDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<SmartRestaurantTeamIdentityDbContext>();

            var connectionString = configuration.GetConnectionString("SmartRestaurantIdentityDbContext");
            Trace.WriteLine(connectionString);
            dbContextBuilder.UseSqlServer(connectionString);

            return new SmartRestaurantTeamIdentityDbContext(dbContextBuilder.Options);
        }

    }
}
