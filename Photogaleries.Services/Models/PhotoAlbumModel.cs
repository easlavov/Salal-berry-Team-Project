using Photogaleries.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
                    Id=pa.Id,
                    Name = pa.Name,
                    UserId = pa.UserId,
                    Photos = pa.Photos.Select(p => p.Id)
                };
            }
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string UserId { get; set; }

        public IEnumerable<int> Photos { get; set; }
    }
}