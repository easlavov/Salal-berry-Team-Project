namespace Photogaleries.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class PhotoAlbum
    {
        private ICollection<Photo> photos;

        public PhotoAlbum()
        {
            this.photos = new HashSet<Photo>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Photo> Photos
        {
            get
            {
                return this.photos;
            }
            set
            {
                this.photos = value;
            }
        }
    }
}