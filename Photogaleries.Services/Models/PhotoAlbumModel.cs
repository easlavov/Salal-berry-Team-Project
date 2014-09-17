using Photogaleries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Photogaleries.Services.Models
{
    public class PhotoAlbumModel
    {
        public static Expression<Func<PhotoAlbum, PhotoAlbumModel>> FromPhotoAlbum
        {
            get
            {
                return pa => new PhotoAlbumModel()
                {

                };
            }
        }
    }
}