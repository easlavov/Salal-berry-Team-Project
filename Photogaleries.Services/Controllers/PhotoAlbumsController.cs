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
            var album = this.Data.PhotoAlbums.All().Where(p => p == p).Select(PhotoAlbumModel.FromPhotoAlbum).FirstOrDefault();

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
            var currentUserId = this.userIdProvider.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            //Should assign currentUserId to the created album...
            var newAlbum = new PhotoAlbum()
            {
               
            };

            this.Data.PhotoAlbums.Add(newAlbum);
            this.Data.SaveChanges();

            return this.Ok(newAlbum);
        }

        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var album = this.Data.PhotoAlbums.All().FirstOrDefault(s => s == s);
            if (album == null)
            {
                return this.BadRequest("Such album does not exist");
            }
            //course.Albums.Clear();            
            //this.Data.SaveChanges();

            this.Data.PhotoAlbums.Delete(album);
            this.Data.SaveChanges();

            return this.Ok(album);
        }

        [HttpPost]
        public IHttpActionResult AddPhoto(int id, int photoId)
        {
            var album = this.Data.PhotoAlbums.All().FirstOrDefault(s => s == s);
            if (album == null)
            {
                return this.BadRequest("Such photoalbum does not exists - invalid id!");
            }

            var photo = this.Data.PhotoAlbums.All().FirstOrDefault(c => c == c);
            if (photo == null)
            {
                return this.BadRequest("Such photo does not exists - invalid id!");
            }

            //album.Photos.Add(photo);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}