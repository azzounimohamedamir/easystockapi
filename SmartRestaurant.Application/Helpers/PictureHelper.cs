using SmartRestaurant.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Helpers;
using System.Linq;
using SmartRestaurant.Domain.Commun;

namespace SmartRestaurant.Application.Helpers
{
    public static class PictureHelper
    {
        public static Guid? AddPictureToEntity(ISmartRestaurantDatabaseService db,
            string PictureUrl)
        {
            if (PictureUrl.IsNullOrEmpty()) return null;

            var picture = db.Pictures.FirstOrDefault(x => x.ImageUrl == PictureUrl);
            //Picture exist
            if (picture != null)
                return picture.Id;
            else // create picture
            {
                var picId = Guid.NewGuid();
                Picture pic = new Picture
                {
                    Id = picId,
                    Name="Not defined",
                    ImageUrl = PictureUrl
                };
                db.Pictures.Add(pic);
                return picId;
            }

        }

        public static Guid? UpdateEntityPicture(ISmartRestaurantDatabaseService db,
            string PictureUrl)
        {
            // 1.from pic to  null
            // 2.from null to  null
            if (PictureUrl.IsNullOrEmpty())
            {
                return null;
            }
            // model.PictureUrl != null ---->
            var pic = db.Pictures.FirstOrDefault(x => x.ImageUrl == PictureUrl);
            if (pic != null)
                return pic.Id;
            else
            {
                Guid picGuid = Guid.NewGuid();
                Picture newPic = new Picture
                {
                    Id = picGuid,
                    Name="Not Defined",                    
                    ImageUrl = PictureUrl
                };
                db.Pictures.Add(newPic);
                return picGuid;
            }

        }
    }
}
