using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Model.Repository
{
    interface IGenericRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(TEntity item);
        TEntity FindById(object id);
        IEnumerable<TEntity> GetItems();
        IEnumerable<TEntity> GetItems(Func<TEntity, bool> predicate);
    }
}
