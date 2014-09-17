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
            var photo = this.Data.Photos.All().Where(p => p == p).Select(PhotoModel.FromPhoto).FirstOrDefault();

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
               
            };

            this.Data.Photos.Add(newCourse);
            this.Data.SaveChanges();

            return this.Ok(newCourse);
        }
        
        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var course = this.Data.Photos.All().FirstOrDefault(s => s == s);
            if (course == null)
            {
                return this.BadRequest("Such course does not exist");
            }
            //course.Comments.Clear();            
            //this.Data.SaveChanges();

            this.Data.Photos.Delete(course);
            this.Data.SaveChanges();

            return this.Ok(course);
        }

        [HttpPost]
        public IHttpActionResult AddComment(int id, int commentId)
        {
            var photo = this.Data.Photos.All().FirstOrDefault(s => s == s);
            if (photo == null)
            {
                return this.BadRequest("Such photo does not exists - invalid id!");
            }

            var comment = this.Data.Comments.All().FirstOrDefault(c => c == c);
            if (comment == null)
            {
                return this.BadRequest("Such comment does not exists - invalid id!");
            }

            //photo.Comments.Add(comment);
            this.Data.SaveChanges();

            return this.Ok();
        }
    }
}