using Photogaleries.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Photogaleries.Services.Models;
using Photogaleries.Models;

namespace Photogaleries.Services.Controllers
{
    public class PhotoAlbumsController : BaseApiController
    {
        private AspNetUserIdProvider userIdProvider;
        
        public PhotoAlbumsController(IPhotogaleriesData data) : base(data)
        {
            userIdProvider = new AspNetUserIdProvider();
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var albums = this.Data.PhotoAlbums.All().Select(PhotoAlbumModel.FromPhotoAlbum);
            return Ok(albums);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var album = this.Data.PhotoAlbums.All().Where(p => p.Id == id).Select(PhotoAlbumModel.FromPhotoAlbum).FirstOrDefault();

            if (album == null)
            {
                return BadRequest("There is no such album - invalid id");
            }

            return Ok(album);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Create(PhotoAlbumModel photo)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var currentUserId = this.userIdProvider.GetUserId();

            var newAlbum = new PhotoAlbum()
            {
                Name = photo.Name,
                UserId = currentUserId
            };

            this.Data.PhotoAlbums.Add(newAlbum);
            this.Data.SaveChanges();

            return this.Ok(newAlbum);
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var album = this.Data.PhotoAlbums.All().FirstOrDefault(a => a.Id == id);
            if (album == null)
            {
                return this.BadRequest("Such album does not exist");
            }
            album.Photos.Clear();            
            this.Data.SaveChanges();

            this.Data.PhotoAlbums.Delete(album);
            this.Data.SaveChanges();

            return this.Ok(album);
        }
    }
}