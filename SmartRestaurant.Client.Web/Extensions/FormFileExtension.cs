using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace SmartRestaurant.Client.Web.Extensions
{
    public static class FormFileExtension
    {

        public static async Task<Uri> SaveAsync(this IFormFile file, IHostingEnvironment hostingEnvironment, HttpRequest request,string path)
        {
            if (path.Contains(","))
            {
                path = Path.Combine("uploads", path.Replace(",", "\\"));
            }
            else
            {
                path = Path.Combine("uploads", path);
            }    
            
            var serverPath = path; 
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, serverPath);
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
            string uri = $"{path.Replace("\\","/")}/{file.FileName}";
            return new Uri(request.Scheme + "://" + request.Host + "/" + uri);
        }
        
        public static  Uri Save(this IFormFile file, IHostingEnvironment hostingEnvironment, HttpRequest request, string path)
        {
            ///if (file == null) ;
            if (path.Contains(","))
            {
                path = Path.Combine("uploads", path.Replace(",", "\\"));
            }
            else
            {
                path = Path.Combine("uploads", path);
            }

            var serverPath = path;
            var uploads = Path.Combine(hostingEnvironment.WebRootPath, serverPath);
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }

            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            string uri = $"{path.Replace("\\", "/")}/{file.FileName}";
            return new Uri(request.Scheme + "://" + request.Host + "/" + uri);
        }
        
    }
}
