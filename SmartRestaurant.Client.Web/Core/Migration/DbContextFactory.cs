using System.Diagnostics;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SmartRestaurant.Persistence.ApplicationDataBase;

namespace SmartRestaurant.Client.Web.Core.Migration
{
    public class DbContextFactory : IDesignTimeDbContextFactory<SmartRestaurantDbContext>
    {
        public SmartRestaurantDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<SmartRestaurantDbContext>();

            var connectionString = configuration.GetConnectionString("SmartRestaurantSqlConnection");
            Trace.WriteLine(connectionString);
            dbContextBuilder.UseSqlServer(connectionString);

            return new SmartRestaurantDbContext(dbContextBuilder.Options);
        }
    
    }
}
