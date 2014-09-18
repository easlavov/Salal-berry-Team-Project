namespace Photogaleries.Services.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Photogaleries.Data;
    using Photogaleries.Models;
    using Photogaleries.Services.Models;
    using System.Web.Http.Cors;
   

    public class PhotoAlbumsController : BaseApiController
    {
        private readonly AspNetUserIdProvider userIdProvider;
        
        public PhotoAlbumsController(IPhotogaleriesData data) : base(data)
        {
            this.userIdProvider = new AspNetUserIdProvider();
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var albums = this.Data.PhotoAlbums.All().Select(PhotoAlbumModel.FromPhotoAlbum);
            return this.Ok(albums);
        }

        [HttpGet]
        public IHttpActionResult GetById(int id)
        {
            var album = this.Data.PhotoAlbums.All().Where(p => p.Id == id).Select(PhotoAlbumModel.FromPhotoAlbum).FirstOrDefault();

            if (album == null)
            {
                return this.BadRequest("There is no such album - invalid id");
            }

            return this.Ok(album);
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Create(PhotoAlbumModel photo)
        {
            var currentUserId = this.userIdProvider.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

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