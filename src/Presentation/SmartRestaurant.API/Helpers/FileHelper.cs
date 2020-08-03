using SmartRestaurant.API.Models;
using System.Collections.Generic;
using System.IO;

namespace SmartRestaurant.API.Helpers
{
    public static class FileHelper
    {
        public static IEnumerable<ImageModel> SaveImagesAsync(FIleUploadApi fileUploadApi)
        {

            foreach (var file in fileUploadApi.Files)
            {

                if (file.Length <= 0) continue;
                var imageModel = new ImageModel();
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    imageModel.ImageBytes = ms.ToArray();
                    imageModel.ImageTitle = file.FileName;
                    imageModel.IsLogo = fileUploadApi.IsLogo;
                    yield return imageModel;
                }

            }

        }

    }
}
