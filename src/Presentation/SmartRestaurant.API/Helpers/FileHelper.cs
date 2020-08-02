using System.Collections.Generic;
using System.IO;
using SmartRestaurant.API.Models;

namespace SmartRestaurant.API.Helpers
{
    public static class FileHelper
    {
	    public static IEnumerable<ImageModel> SaveImagesAsync(FIleUploadApi fileUploadApi)
        {
            
            foreach (var file in fileUploadApi.Files)
            {
                var  imageModel = new ImageModel();
                imageModel.ImageBytes = FileToByteArray(file.FileName);
                imageModel.ImageTitle = file.FileName;
                imageModel.IsLogo = fileUploadApi.IsLogo;
                yield return imageModel;
            }
            
        }
        private static byte[] FileToByteArray(string fileName)
        {
            byte[] fileData = null;

            using (FileStream fs = File.OpenRead(fileName))
            {
                var binaryReader = new BinaryReader(fs);
                fileData = binaryReader.ReadBytes((int)fs.Length);
            }
            return fileData;
        }
    }
}
