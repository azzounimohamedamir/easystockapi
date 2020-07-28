using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using SmartRestaurant.API.Models;

namespace SmartRestaurant.API.Helpers
{
    public static class FileHelper
    {
	   private static readonly string RootDir = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);

        public static string RestaurantImagesPath =>  RootDir + "\\uploads\\restaurants\\photo\\";
        public static string RestaurantLogoPath =>  RootDir + "\\uploads\\restaurants\\logo\\";

        public static async Task SaveImagesAsync(FIleUploadAPI images, bool logo)
        {
            var path  = !logo?  RestaurantImagesPath:
                RestaurantLogoPath;
            if (!Directory.Exists($"{path}{images.RestaurantId}\\"))
                Directory.CreateDirectory($"{path}{images.RestaurantId}\\");

            foreach (var file in images.Files)
            {
                await using (FileStream fileStream =
                    File.Create($"{path}{images.RestaurantId}\\" + file.FileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }
        }
    }
}
