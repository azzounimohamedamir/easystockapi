using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace SmartRestaurant.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                 .UseKestrel()  
                 
                 // important!
                 .UseIISIntegration()
                 .UseContentRoot(Directory.GetCurrentDirectory())
                // important!
                .UseStartup<Startup>();
        }
    }
}