using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using SmartRestaurant.Application.Commun.Galleries.Pictures.Models;
using SmartRestaurant.Client.Web.Extensions;
using System;

namespace SmartRestaurant.Client.Web.Models.Utils
{
    public enum FileType
    {
        Document,
        Image
    }

    public class FileViewModel
    {
        string uniqueId;

        public FileViewModel()
        {
            uniqueId = Guid.NewGuid().ToString();
        }
        public FileViewModel(FileType type = FileType.Image) : this()
        {

            uniqueId = Guid.NewGuid().ToString();
            Name = Guid.NewGuid().ToString();
            Multiple = false;
            switch (type)
            {
                case FileType.Image:
                    Accept = "image/*";
                    HasPreview = true;
                    break;
                case FileType.Document:
                    //TODO: Ajouter les type de document pdf,doc,....
                    Accept = "";
                    break;
                default:
                    Accept = "image/*";
                    break;
            }
        }

        public FileViewModel(
            string pictureId,
            string pictureUrl,
            FileType type = FileType.Image) : this(type)
        {
            uniqueId = Guid.NewGuid().ToString();
            ImageId = pictureId;
            OldUrl = pictureUrl;

            if (!string.IsNullOrEmpty(pictureUrl))
            {
                HasImage = true;
                Uri = new Uri(pictureUrl);
            }
        }

        public FileViewModel(PictureModel picture) : this(FileType.Image)
        {
            if (picture != null)
            {
                ImageId = picture.Id;
                OldUrl = picture.Url;

                if (!string.IsNullOrEmpty(picture.Url))
                {
                    HasImage = true;
                    Uri = new Uri(picture.Url);
                }
            }
        }

        public string UniqueId { get; private set; }
        public FileType Type { get; set; } = FileType.Image;
        public string ImageId { get; private set; }
        public string OldUrl { get; private set; }
        public Uri Uri { get; set; }
        public string Url
        {
            get
            {
                if (Uri == null)
                {
                    return null;
                }
                return Uri.ToString();
            }
        }
        public IFormFile File { get; set; }
        public bool Multiple { get; set; }
        public string Name { get; private set; }
        public string Accept { get; private set; }

        public bool IsChanged
        {
            get
            {
                return File != null;
            }
        }

        public bool HasPreview { get; private set; } = false;
        public bool HasImage { get; private set; } = false;

        public string Save(
            IHostingEnvironment hostingEnvironement,
            HttpRequest request,
            string path)
        {
            return File.Save(hostingEnvironement, request, path).ToString();
        }

        public string ChangeFileText { get; set; }
        public string RemoveFileText { get; set; }

        public int ImageHeight { get; set; } = 600;
        public int ImageWidth { get; set; } = 600;
        public string ImageSize
        {
            get
            {
                return $"{ImageHeight.ToString()}*{ImageWidth.ToString()}";
            }
        }
    }
}
