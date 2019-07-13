using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Model.Repositories
{
    public class BaseRepository<T> : IDisposable, IRepository<T> where T : class, new()
    {
        private readonly DbSet<T> _dbSet;
        private readonly ApplicationContext _context;
        protected ApplicationContext Context => _context;

        public BaseRepository() : this(new ApplicationContext())
        {
        }

        public BaseRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public int Add(T entity)
        {
            _dbSet.Add(entity);
            return SaveChanges();
        }

        public int Add(IList<T> entities)
        {
            _dbSet.AddRange(entities);
            return SaveChanges();
        }

        public int Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return SaveChanges();
        }

        public int Delete(T entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            return SaveChanges();
        }

        public T GetOne(object id)
        {
            return _dbSet.Find(id);
        }

        public List<T> GetSome(Expression<Func<T, bool>> @where)
        {
            return _dbSet.Where(where).AsNoTracking().ToList();
        }

        public virtual List<T> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public List<T> GetAll<TSortField>(Expression<Func<T, TSortField>> orderBy, bool @ascending)
        {
            if (ascending)
                return _dbSet.OrderBy(orderBy).AsNoTracking().ToList();
            else
                return _dbSet.OrderByDescending(orderBy).AsNoTracking().ToList();
        }

        internal int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}