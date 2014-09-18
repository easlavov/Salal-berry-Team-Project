namespace Photogaleries.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Photogaleries.Data;
    using Photogaleries.Models;
    using Photogaleries.Services.Models;


    public class CommentsController : BaseApiController
    {
        private readonly AspNetUserIdProvider userIdProvider;

        public CommentsController(IPhotogaleriesData data) : base(data)
        {
            this.userIdProvider = new AspNetUserIdProvider();
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var comments = this.Data.Comments.All().Select(CommentModel.FromComment);
            return this.Ok(comments);
        }

        [HttpGet]
        public IHttpActionResult GetByPhotoId(int photoId)
        {
            var photo = this.Data.Comments.All().Where(p => p.PhotoId == photoId).Select(CommentModel.FromComment);

            return Ok(photo);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Create(CommentModel comment)
        {
            var currentUserId = this.userIdProvider.GetUserId();
            
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

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