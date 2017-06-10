using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace MvcStarter01.DataAccess
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetQuery();
        IQueryable<TEntity> Find(Expression<Func<TEntity, Boolean>> predicate);
        TEntity Single(Expression<Func<TEntity, Boolean>> predicate);
        TEntity First(Expression<Func<TEntity, Boolean>> predicate);
        int Count(Expression<Func<TEntity, Boolean>> predicate);

        void Add(TEntity entity);
        void Remove(TEntity entity);
        int SaveChanges();
    }

    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly MyContext _context;
        private IDbSet<TEntity> Entities
        {
            get { return _context.Set<TEntity>(); }
        }
        
        public Repository(MyContext context)
        {
            _context = context;
        }
        public IQueryable<TEntity> GetQuery()
        {
            return Entities.AsQueryable();
        }

        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate);
        }

        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Single(predicate);
        }

        public TEntity First(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.First(predicate);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate).Count();
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            Entities.Remove(entity);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
