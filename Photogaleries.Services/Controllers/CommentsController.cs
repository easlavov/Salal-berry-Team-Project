using Photogaleries.Data;
using Photogaleries.Models;
using Photogaleries.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Photogaleries.Services.Controllers
{
    public class CommentsController : BaseApiController
    {
        private AspNetUserIdProvider userIdProvider;

        public CommentsController(IPhotogaleriesData data) : base(data)
        {
            userIdProvider = new AspNetUserIdProvider();
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var comments = this.Data.Comments.All().Select(CommentModel.FromComment);
            return Ok(comments);
        }

        //[HttpGet]
        //public IHttpActionResult GetById(int id)
        //{
        //    var photo = this.Data.Photos.All().Where(p => p == p).Select(PhotoModel.FromPhoto).FirstOrDefault();

        //    if (photo == null)
        //    {
        //        return BadRequest("There is no such comment - invalid id");
        //    }

        //    return Ok(photo);
        //}

        [Authorize]
        [HttpPost]
        public IHttpActionResult Create(CommentModel comment)
        {
            var currentUserId = this.userIdProvider.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            //Add user id to the comment and get the picture id as well...
            var newComment = new Comment()
            {
               
            };

            this.Data.Comments.Add(newComment);
            this.Data.SaveChanges();

            return this.Ok(newComment);
        }
        
        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var comment = this.Data.Comments.All().FirstOrDefault(s => s == s);
            if (comment == null)
            {
                return this.BadRequest("Such course does not exist");
            }

            this.Data.Comments.Delete(comment);
            this.Data.SaveChanges();

            return this.Ok(comment);
        }
    }
}