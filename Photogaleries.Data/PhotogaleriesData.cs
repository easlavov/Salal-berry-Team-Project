using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photogaleries.Data
{
    public class PhotogaleriesData : IPhotogaleriesData
    {
        public Repositories.IRepository<Models.Photo> Photos
        {
            get { throw new NotImplementedException(); }
        }

        public Repositories.IRepository<Models.PhotoAlbum> PhotoAlbums
        {
            get { throw new NotImplementedException(); }
        }

        public Repositories.IRepository<Models.Comment> Comments
        {
            get { throw new NotImplementedException(); }
        }

        public Repositories.IRepository<Models.User> Users
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
