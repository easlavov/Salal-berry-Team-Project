using Photogaleries.Data.Repositories;
using Photogaleries.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Photogaleries.Data
{
    public interface IPhotogaleriesData
    {
        IRepository<Photo> Photos { get; }

        IRepository<PhotoAlbum> PhotoAlbums { get; }

        IRepository<Comment> Comments { get; }

        IRepository<User> Users { get;  }
        
        int SaveChanges();
    }
}