using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Photogaleries.Services.Models;
using Photogaleries.Data;
using Photogaleries.Models;

namespace Photogaleries.Services.Controllers
{
    public class PhotosController : BaseApiController
    {
        public PhotosController(IPhotogaleriesData data) : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var photos = this.Data.Photos.All().Select(PhotoModel.FromPhoto);
            return Ok(photos);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var photo = this.Data.Photos.All().Where(p => p.Id == id).Select(PhotoModel.FromPhoto).FirstOrDefault();

            if (photo == null)
            {
                return BadRequest("There is no such photo - invalid id");
            }

            return Ok(photo);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Create(PhotoModel photo)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var newCourse = new Photo()
            {
                Name = photo.Name,
                Url = photo.Url,
                PhotoAlbumId = photo.PhotoAlbumId
            };

            this.Data.Photos.Add(newCourse);
            this.Data.SaveChanges();

            return this.Ok(newCourse);
        }
        
        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var photo = this.Data.Photos.All().FirstOrDefault(p => p.Id == id);
            if (photo == null)
            {
                return this.BadRequest("Such photo does not exist");
            }

            photo.Comments.Clear();            
            this.Data.SaveChanges();

            this.Data.Photos.Delete(photo);
            this.Data.SaveChanges();

            return this.Ok(photo);
        }
       
    }
}