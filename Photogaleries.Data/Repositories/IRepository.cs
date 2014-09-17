using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Photogaleries.Data.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> All();

        IQueryable<T> SearchFor(Expression<Func<T, bool>> conditions);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        void Detach(T entity);
    }
}
