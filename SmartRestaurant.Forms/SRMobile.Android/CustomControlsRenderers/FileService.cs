using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SmartRestaurant.Diner.CustomControls;
using SmartRestaurant.Diner.Droid.CustomControlsRenderers;
using Xamarin.Forms;
using Environment = System.Environment;

[assembly: Dependency(typeof(FileService))]
namespace SmartRestaurant.Diner.Droid.CustomControlsRenderers
{
        public class FileService : IFileService
        {
        public void DownloadImage(string URL)
        {
            var webClient = new WebClient();
            webClient.DownloadDataCompleted += (s, e) =>
            {
                byte[] bytes = new byte[e.Result.Length];
                bytes = e.Result; // get the downloaded data
                string documentsPath = Android.OS.Environment.DirectoryDcim;

                var partedURL = URL.Split('/');
                string localFilename = partedURL[partedURL.Length - 1];
                string localPath = System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath, documentsPath, "SmartRestaurant", localFilename);
                File.Create(localPath);
                File.WriteAllBytes(localPath, bytes); // writes to local storage
            };
            var url = new Uri(URL);
            webClient.DownloadDataAsync(url);
        }
        public string GetImage(string name)
        {
            string documentsPath = Android.OS.Environment.DirectoryDcim;
            if( File.Exists(System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.
                AbsolutePath,documentsPath,"SmartRestaurant"
                , name)))
            {
                return System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath,documentsPath, "SmartRestaurant", name);
            }
            else
            {
                DownloadImage(App.base_url_images+name);
                return System.IO.Path.Combine(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath,documentsPath,   name);
            }
        }
    }

    }