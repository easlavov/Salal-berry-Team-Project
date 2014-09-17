using Photogaleries.Data.Repositories;
using Photogaleries.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photogaleries.Data
{
    public class PhotogaleriesData : IPhotogaleriesData
    {
        
        public IRepository<Photo> Photos
        {
            get { throw new NotImplementedException(); }
        }

        public IRepository<PhotoAlbum> PhotoAlbums
        {
            get { throw new NotImplementedException(); }
        }

        public IRepository<Comment> Comments
        {
            get { throw new NotImplementedException(); }
        }

        public IRepository<User> Users
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
