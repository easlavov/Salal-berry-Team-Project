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
        private readonly DbContext context;

        private readonly IDictionary<Type, object> repositories;

        public PhotogaleriesData():this(new PhotogaleriesDbContext())
        {

        }

        public PhotogaleriesData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Photo> Photos
        {
            get
            {
                return this.GetRepository<Photo>();
            }
        }

        public IRepository<PhotoAlbum> PhotoAlbums
        {
            get
            {
                return this.GetRepository<PhotoAlbum>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(Repository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}