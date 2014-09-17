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
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
            }

            var currentUserId = this.userIdProvider.GetUserId();

            var newComment = new Comment()
            {
                Text = comment.Text,
                Date = comment.Date,
                UserId = currentUserId,
                PhotoId = comment.PhotoId
            };
            
            this.Data.Comments.Add(newComment);
            this.Data.SaveChanges();

            return this.Ok(newComment);
        }
        
        [Authorize]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var comment = this.Data.Comments.All().FirstOrDefault(c => c.Id == id);
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