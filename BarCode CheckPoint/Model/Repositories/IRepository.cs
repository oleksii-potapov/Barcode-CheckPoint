using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Model.Repositories
{
    public interface IRepository<T>
    {
        int Add(T entity);
        int Add(IList<T> entities);
        int Update(T entity);
        int Delete(T entity);
        T GetOne(object id);
        List<T> GetSome(Expression<Func<T, bool>> where);
        List<T> GetAll();
        List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool ascending);
    }
}