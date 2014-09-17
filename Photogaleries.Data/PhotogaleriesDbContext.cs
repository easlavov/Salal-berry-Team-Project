using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Text;
using System.Threading.Tasks;
using Photogaleries.Models;
using System.Data.Entity;
using Photogaleries.Data.Migrations;

namespace Photogaleries.Data
{
    public class PhotogaleriesDbContext : IdentityDbContext<User>
    {
        public PhotogaleriesDbContext()
            : base("PhotogaleriesConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PhotogaleriesDbContext, Configuration>());
        }
        public static PhotogaleriesDbContext Create()
        {
            return new PhotogaleriesDbContext();
        }

        public IDbSet<PhotoAlbum> PhotoAlbums { get; set; }

        public IDbSet<Photo> Photos { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}