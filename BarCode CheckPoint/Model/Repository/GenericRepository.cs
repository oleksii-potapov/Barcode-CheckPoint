using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckPoint.Model.Repository
{
    public enum OrderType
    {
        Asc,
        Desc
    }

    class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(TEntity item)
        {
            _context.Entry(item).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public TEntity FindById(object id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<TEntity> GetItems()
        {
            return _dbSet.ToList();
        }

        public IEnumerable<TEntity> GetItems(Func<TEntity, bool> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetOrderedItems(Func<TEntity, bool> order, OrderType orderType)
        {
            if (orderType == OrderType.Desc)
                return _dbSet.OrderByDescending(order).ToList();
            return _dbSet.OrderBy(order).ToList();
        }
    }
}