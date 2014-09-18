using Photogaleries.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Photogaleries.Services.Models
{
    public class PhotoModel
    {
        public static Expression<Func<Photo, PhotoModel>> FromPhoto
        {
            get
            {
                return p => new PhotoModel()
                {
                    Id=p.Id,
                    Name = p.Name,
                    PhotoAlbumId = p.PhotoAlbumId,
                    Url=p.Url,
                    Comments = p.Comments.Select(c=>c.Id)
                };
            }
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Url { get; set; }

        public int? PhotoAlbumId { get; set; }

        public IEnumerable<int> Comments { get; set; }
    }
}